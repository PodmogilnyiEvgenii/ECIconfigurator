using System;
using System.Diagnostics.Metrics;
using System.IO.Ports;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace ECIconfigurator
{

    class Comport
    {
        private MainWindow mainWindow;
        private static SerialPort serialPort = new SerialPort();

        public bool isReadWhenOpen = true;
        public bool isReadOnline = false;
        public bool isWriteOnline = true;

        private bool isGoodAnswer = false;
        private int timeOutOpenPort = 500;
        private int timeOutSendMessage = 500;
        private int maxCounters = 5;

        public Comport(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public void OpenComport(string nameComport)
        {
            serialPort.PortName = nameComport;
            serialPort.BaudRate = 115200;
            serialPort.Parity = Parity.None;
            serialPort.DataBits = 8;
            serialPort.StopBits = StopBits.One;
            serialPort.ReadTimeout = timeOutSendMessage;
            serialPort.WriteTimeout = timeOutSendMessage;
            serialPort.ReadBufferSize = 2048;

            serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPortDataReceivedHandler);

            try
            {
                serialPort.Open();
                System.Threading.Thread.Sleep(timeOutOpenPort);
                mainWindow.ShowMessaage("comPortOpenMsg");
            }
            catch (UnauthorizedAccessException e)
            {
                System.Diagnostics.Trace.WriteLine("Serial Port open failed: " + e.Message);
                mainWindow.ShowMessaage("comPortFailMsg");
            }
            catch (System.IO.FileNotFoundException e)
            {
                System.Diagnostics.Trace.WriteLine("Serial Port not found: " + e.Message);
                mainWindow.ShowMessaage("comPortFailMsg");
            }
        }

        private void SerialPortDataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string data = serialPort.ReadLine();
                System.Diagnostics.Trace.WriteLine("New data from comport:");
                System.Diagnostics.Trace.WriteLine(data);

                //System.Diagnostics.Trace.WriteLine(Encoding.ASCII.GetBytes(data));

                if (JsonUtils.IsValidJson(data))
                {
                    System.Diagnostics.Trace.WriteLine("Valid json");
                    Device? device = JsonUtils.JsonStringToDevice(data);

                    //System.Diagnostics.Trace.WriteLine(device);               
                    if (device != null)
                    {
                        if (device.deviceType.Equals("ECI"))
                        {
                            isGoodAnswer = true;
                            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background,
                            new Action(() => mainWindow.ResponseReceived(device) ));
                            //mainWindow.ResponseReceived(device);
                        }
                    }
                }
                else if (data.Contains("Setup done"))
                {
                    isGoodAnswer = true;
                    /*Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background,
                    new Action(() => mainWindow.SetupResponseReceived()));*/
                    mainWindow.ShowMessaage("setupDoneMsg");
                }
                else if (data.Contains("InvalidInput"))
                {
                    System.Diagnostics.Trace.WriteLine("Setup failed. Try again");
                    //WriteToComport(lastMessage);
                }
            }
            catch (InvalidOperationException ex)
            {
                System.Diagnostics.Trace.WriteLine("Serial Port read failed: " + ex.Message);
            }
            catch (TimeoutException ex)
            {
                System.Diagnostics.Trace.WriteLine("Serial Port read timeout: " + ex.Message);
            }
            catch (OperationCanceledException ex)
            {
                System.Diagnostics.Trace.WriteLine("Serial operation canceled: " + ex.Message);
            }
        }

        public void CloseComport()
        {
            try
            {
                serialPort.Close();
                mainWindow.ShowMessaage("comPortCloseMsg");
            }
            catch (UnauthorizedAccessException e)
            {
                System.Diagnostics.Trace.WriteLine("Serial Port close failed: " + e.Message);

            }
        }

        public void WriteToComport(string message)
        {
            if (!isComportOpen())
            {
                OpenComport(serialPort.PortName);
            }

            if (isComportOpen())
            {
                try
                {
                    Task.Factory.StartNew(() =>
                    {
                        isGoodAnswer = false;
                        int counter = 0;

                        while (!isGoodAnswer && counter < maxCounters)
                        {
                            counter++;
                            serialPort.WriteLine(message);

                            System.Diagnostics.Trace.WriteLine("Try " + counter);
                            System.Diagnostics.Trace.WriteLine(message);
                            
                            if (counter>1) mainWindow.ShowMessaage("tryMsg", counter);

                            System.Threading.Thread.Sleep(timeOutSendMessage);
                        }
                    });

                }
                catch (UnauthorizedAccessException e)
                {
                    System.Diagnostics.Trace.WriteLine("Serial Port write failed: " + e.Message);
                }
            }
            else
            {                
                mainWindow.ShowMessaage("comPortFailMsg");
            }
        }

        public bool isComportOpen()
        {
            return serialPort.IsOpen;
        }

    }
}
