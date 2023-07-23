using System.Windows;

namespace ECIconfigurator
{
    class Localization
    {
        private static readonly Language ru = new Ru();
        private static readonly Language eng = new Eng();

        public static Language language = ru;

    public static string GetLanguage()
        {
            return language.GetType().Name;
        }

        public static void SetLanguageEng()
        {
            language = eng;
        }

        public static void SetLanguageRu()
        {
            language = ru;
        }

        public static void TranslateView(System.Windows.Controls.Grid mainGrid)
        {
            foreach (string buttonName in language.GetButtonSet())
            {
                System.Windows.Controls.Button button = (System.Windows.Controls.Button)mainGrid.FindName(buttonName);

                if (button != null)
                {
                    button.Content = language.GetButtonTranslate(buttonName);
                }
            }

            foreach (string menuName in language.GetMenuSet())
            {
                System.Windows.Controls.MenuItem menuItem = (System.Windows.Controls.MenuItem)mainGrid.FindName(menuName);

                if (menuItem != null)
                {
                   menuItem.Header = language.GetMenuTranslate(menuName);
                }
            }

            foreach (string tabControlName in language.GetTabControlsSet())
            {
                System.Windows.Controls.TabControl tabControl = (System.Windows.Controls.TabControl)mainGrid.FindName(tabControlName);

                if (tabControl != null)
                {
                    foreach (System.Windows.Controls.TabItem tab in tabControl.Items)
                    {
                        tab.Header = language.GetTabTranslate(tabControlName, tab.Name);
                    }
                }
            }

            System.Windows.Controls.TextBlock statusMessageBlock = (System.Windows.Controls.TextBlock)mainGrid.FindName("statusMessage");

            ((MainWindow)Application.Current.MainWindow).ShowMessaage("greetingsMsg");
            //statusMessageBlock.Text=language.GetMessageTranslate("greetingsMsg");

        }
       
    }
}
