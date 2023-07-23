using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.IO;
using System.IO.Ports;
using System.Windows;
using System.Windows.Threading;

namespace ECIconfigurator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Device device = new Device();
        private Comport comport;
        private ViewUpdate viewUpdate;

        public MainWindow()
        {
            InitializeComponent();

            comport = new Comport((MainWindow)Application.Current.MainWindow);
            viewUpdate = new ViewUpdate((MainWindow)Application.Current.MainWindow);

            Localization.TranslateView(mainGrid);
            GetComports();
        }

        public void ShowMessaage(string message)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background,
                                new Action(() => statusMessage.Text = Localization.language.GetMessageTranslate(message)));
            //statusMessage.Text = Localization.language.GetMessageTranslate(message);
        }
        public void ShowMessaage(string message, int counter)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background,
                                new Action(() => statusMessage.Text = Localization.language.GetMessageTranslate(message) + counter));
            //statusMessage.Text = Localization.language.GetMessageTranslate(message) + counter;
        }


        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            comport.CloseComport();
        }

        private void OpenComport_Click(object sender, RoutedEventArgs e)
        {
            comport.OpenComport(comportBox.SelectedItem.ToString());

            if (comport.isComportOpen())
            {
                openButton.Visibility = Visibility.Collapsed;
                closeButton.Visibility = Visibility.Visible;
                comportBox.IsEnabled = false;
                readButton.IsEnabled = true;
                writeButton.IsEnabled = true;

                if (comport.isReadWhenOpen)
                {
                    GetDataFromComport();
                }
            }



        }

        private void CloseComport_Click(object sender, RoutedEventArgs e)
        {
            openButton.Visibility = Visibility.Visible;
            closeButton.Visibility = Visibility.Collapsed;
            comportBox.IsEnabled = true;
            readButton.IsEnabled = false;
            writeButton.IsEnabled = false;

            comport.CloseComport();

        }

        private void ReadComport_Click(object sender, RoutedEventArgs e)
        {
            GetDataFromComport();
        }

        private void WriteComport_Click(object sender, RoutedEventArgs e)
        {
            ShowMessaage("paramWriteMsg");
            comport.WriteToComport(JsonUtils.DeviceToJsonString(device));
        }

        private void ScanComport_Click(object sender, RoutedEventArgs e)
        {
            GetComports();
        }

        private void GetComports()
        {
            comportBox.Items.Clear();
            string[] comports = SerialPort.GetPortNames();
            foreach (string comport in comports)
            {
                comportBox.Items.Add(comport);
            }
            comportBox.SelectedIndex = 0;
        }

        private void GetDataFromComport()
        {
            ShowMessaage("paramRequestSendMsg");
            comport.WriteToComport(JsonUtils.GetRequestMessage());
        }

        internal void ResponseReceived(Device device)
        {
            this.device = device;
            ShowMessaage("responseReceivedMsg");
            UpdateView(device);
        }

        /*internal void SetupResponseReceived()
        {
            ShowMessaage("setupDoneMsg");
        }*/

        /*internal void ResponseFail(int counter)
        {
            ShowMessaage("setupDoneMsg" + counter);
        }*/

        internal void UpdateView(Device device)
        {
            viewUpdate.DeviceTableUpdate(deviceTable, device);
            viewUpdate.Option1TableUpdate(options1Table, device);
            viewUpdate.Option2TableUpdate(options2Table, device);
            viewUpdate.Text1TableUpdate(text1Table, device);
            viewUpdate.Text2TableUpdate(text2Table, device);
            viewUpdate.Text3TableUpdate(text3Table, device);
            viewUpdate.Text4TableUpdate(text4Table, device);
            viewUpdate.QrcodeTableUpdate(qrcodeTable, device);
        }

        internal void UpdateDevice(string parameter, string value)
        {
            device.GetType().GetField(parameter).SetValue(device, value);

            if (comport.isWriteOnline)
            {
                comport.WriteToComport(JsonUtils.DeviceToJsonString(device));
            }
        }

        private void ConfigurationSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "ECI cfg files (*.cfg) |*.cfg";
            if (saveFileDialog.ShowDialog() == true)
            {
                string fileName = saveFileDialog.FileName;

                using (TextWriter textWriter = new StreamWriter(fileName))                    
                {
                    string data = JsonConvert.SerializeObject(device);
                    try
                    {
                        textWriter.Write(data);
                        ShowMessaage("cfgSaved");

                    }
                    catch (IOException ex)
                    {
                        System.Diagnostics.Trace.WriteLine("Configuration save failed: " + ex.Message);
                    }

                }
            }
        }

        private void ConfigurationLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "ECI cfg files (*.cfg)|*.cfg";

            if (openFileDialog.ShowDialog() == true)
            {
                string fileName = openFileDialog.FileName;

                using (TextReader textReader = new StreamReader(fileName))                     
                {
                    try
                    {
                        Device device = JsonConvert.DeserializeObject<Device>(textReader.ReadToEnd());
                        this.device = device;
                        UpdateView(device);
                        ShowMessaage("cfgOpened");
                    }
                    catch (IOException ex)
                    {
                        System.Diagnostics.Trace.WriteLine("Configuration load failed: " + ex.Message);
                    }
                }
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }


        private void setReadWhenOpen_Click(object sender, RoutedEventArgs e)
        {
            comport.isReadWhenOpen = !comport.isReadWhenOpen;
        }

        private void setWriteOnline_Click(object sender, RoutedEventArgs e)
        {
            comport.isWriteOnline = !comport.isWriteOnline;
        }

        private void setReadOnline_Click(object sender, RoutedEventArgs e)
        {
            comport.isReadOnline = !comport.isReadOnline;
        }


        private void LanguageRu_Click(object sender, RoutedEventArgs e)
        {
            languageMenuRu.IsChecked = true;
            languageMenuEng.IsChecked = false;
            Localization.SetLanguageRu();
            Localization.TranslateView(mainGrid);
        }

        private void LanguageEng_Click(object sender, RoutedEventArgs e)
        {
            languageMenuEng.IsChecked = true;
            languageMenuRu.IsChecked = false;
            Localization.SetLanguageEng();
            Localization.TranslateView(mainGrid);
        }
    }
}
