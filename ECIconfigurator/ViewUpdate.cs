using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Data;

namespace ECIconfigurator
{
    internal class RowTable
    {
        public string Parameter { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
    }

    internal class ViewUpdate
    {

        private static MainWindow mainWindow;

        public ViewUpdate(MainWindow mainWindow1)
        {
            mainWindow = mainWindow1;
        }

        public void TableUpdate(DataGrid table, Device device, Dictionary<string, int> columns, List<string> rows)
        {
            table.AutoGenerateColumns = false;
            table.CanUserAddRows = false;
            table.Columns.Clear();
            table.CellEditEnding += tableCellEditEvent;


            foreach (string column in columns.Keys)
            {
                DataGridTextColumn dataGridTextColumn = new DataGridTextColumn();
                dataGridTextColumn.Header = column;
                dataGridTextColumn.Binding = new Binding(column);
                dataGridTextColumn.Width = columns[column];
                if (column.Equals("Value"))
                {
                    dataGridTextColumn.IsReadOnly = false;
                }
                else
                {
                    dataGridTextColumn.IsReadOnly = true;
                }
                table.Columns.Add(dataGridTextColumn);
            }

            List<RowTable> rowsList = new List<RowTable>();

            foreach (string row in rows)
            {
                rowsList.Add(
                new RowTable()
                {
                    Parameter = row.Replace("mb_", ""),
                    Value = device.GetType().GetField(row).GetValue(device).ToString(),
                    Description = Localization.language.GetDescriptionTranslate(row)
                });
            }
            table.ItemsSource = rowsList;
        }

        private static void tableCellEditEvent(object? sender, DataGridCellEditEndingEventArgs e)
        {
            string parameter = ((RowTable)e.Row.Item).Parameter;
            string value = ((TextBox)e.EditingElement).Text.ToString();

            if (!((DataGrid)sender).Name.ToString().Equals("deviceTable")) { parameter = "mb_" + parameter; }

            if (parameter.Equals("deviceType") || parameter.Equals("id") || parameter.Equals("firmwareVer"))
            {
                ((TextBox)e.EditingElement).Text = ((RowTable)e.Row.Item).Value;
            }
            else
            {
                mainWindow.UpdateDevice(parameter, value);
            }
        }

        public void DeviceTableUpdate(DataGrid table, Device device)
        {
            Dictionary<string, int> columns = new Dictionary<string, int>();
            columns.Add("Parameter", 90);
            columns.Add("Value", 150);
            columns.Add("Description", 231);

            List<string> rows = new List<string>();
            rows.Add("deviceType");
            rows.Add("id");
            rows.Add("name");
            rows.Add("firmwareVer");
            rows.Add("mbAddress");
            rows.Add("mbSpeed");

            TableUpdate(table, device, columns, rows);
        }

        public void Option1TableUpdate(DataGrid table, Device device)
        {
            Dictionary<string, int> columns = new Dictionary<string, int>();
            columns.Add("Parameter", 90);
            columns.Add("Value", 150);
            columns.Add("Description", 231);

            List<string> rows = new List<string>();
            rows.Add("mb_1");
            rows.Add("mb_2");
            rows.Add("mb_3");
            rows.Add("mb_4");
            rows.Add("mb_5");
            rows.Add("mb_6");
            rows.Add("mb_7");
            rows.Add("mb_8");
            rows.Add("mb_9");
            rows.Add("mb_10");

            TableUpdate(table, device, columns, rows);
        }

        public void Option2TableUpdate(DataGrid table, Device device)
        {
            Dictionary<string, int> columns = new Dictionary<string, int>();
            columns.Add("Parameter", 90);
            columns.Add("Value", 150);
            columns.Add("Description", 231);

            List<string> rows = new List<string>();
            rows.Add("mb_11");
            rows.Add("mb_12");
            rows.Add("mb_13");
            rows.Add("mb_14");
            rows.Add("mb_15");
            rows.Add("mb_16");
            rows.Add("mb_17");
            rows.Add("mb_18");

            rows.Add("mb_50");
            rows.Add("mb_51");

            TableUpdate(table, device, columns, rows);
        }

        public void Text1TableUpdate(DataGrid table, Device device)
        {
            Dictionary<string, int> columns = new Dictionary<string, int>();
            columns.Add("Parameter", 90);
            columns.Add("Value", 150);
            columns.Add("Description", 231);

            List<string> rows = new List<string>();
            rows.Add("mb_100");
            rows.Add("mb_101");
            rows.Add("mb_102");
            rows.Add("mb_103");
            rows.Add("mb_104");
            rows.Add("mb_105");
            rows.Add("mb_106");
            rows.Add("mb_107");
            rows.Add("mb_108");
            rows.Add("mb_109");
            rows.Add("mb_110");

            TableUpdate(table, device, columns, rows);
        }

        public void Text2TableUpdate(DataGrid table, Device device)
        {
            Dictionary<string, int> columns = new Dictionary<string, int>();
            columns.Add("Parameter", 90);
            columns.Add("Value", 150);
            columns.Add("Description", 231);

            List<string> rows = new List<string>();
            rows.Add("mb_111");
            rows.Add("mb_112");
            rows.Add("mb_113");
            rows.Add("mb_114");
            rows.Add("mb_115");
            rows.Add("mb_116");
            rows.Add("mb_117");
            rows.Add("mb_118");
            rows.Add("mb_119");
            rows.Add("mb_120");

            TableUpdate(table, device, columns, rows);
        }

        public void Text3TableUpdate(DataGrid table, Device device)
        {
            Dictionary<string, int> columns = new Dictionary<string, int>();
            columns.Add("Parameter", 90);
            columns.Add("Value", 150);
            columns.Add("Description", 231);

            List<string> rows = new List<string>();
            rows.Add("mb_121");
            rows.Add("mb_122");
            rows.Add("mb_123");
            rows.Add("mb_124");
            rows.Add("mb_125");
            rows.Add("mb_126");
            rows.Add("mb_127");
            rows.Add("mb_128");
            rows.Add("mb_129");
            rows.Add("mb_130");

            TableUpdate(table, device, columns, rows);
        }

        public void Text4TableUpdate(DataGrid table, Device device)
        {
            Dictionary<string, int> columns = new Dictionary<string, int>();
            columns.Add("Parameter", 90);
            columns.Add("Value", 150);
            columns.Add("Description", 231);

            List<string> rows = new List<string>();
            rows.Add("mb_131");
            rows.Add("mb_132");
            rows.Add("mb_133");
            rows.Add("mb_134");
            rows.Add("mb_135");
            rows.Add("mb_136");
            rows.Add("mb_137");
            rows.Add("mb_138");
            rows.Add("mb_139");
            rows.Add("mb_140");

            TableUpdate(table, device, columns, rows);
        }

        public void QrcodeTableUpdate(DataGrid table, Device device)
        {
            Dictionary<string, int> columns = new Dictionary<string, int>();
            columns.Add("Parameter", 90);
            columns.Add("Value", 150);
            columns.Add("Description", 231);

            List<string> rows = new List<string>();
            rows.Add("mb_202");
            rows.Add("mb_203");
            rows.Add("mb_204");
            rows.Add("mb_205");
            rows.Add("mb_206");
            rows.Add("mb_207");
            rows.Add("mb_208");
            rows.Add("mb_209");
            rows.Add("mb_210");
            rows.Add("mb_211");
            rows.Add("mb_212");
            rows.Add("mb_213");
            rows.Add("mb_214");
            rows.Add("mb_215");
            rows.Add("mb_216");
            rows.Add("mb_217");

            TableUpdate(table, device, columns, rows);
        }
    }
}
