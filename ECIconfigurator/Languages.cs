using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ECIconfigurator
{
    class Language
    {
        public Hashtable menuMap = new();
        public Hashtable buttonsMap = new();
        public Dictionary<string, Hashtable> tabPanesMap = new();        
        public Hashtable messageMap = new();
        public Hashtable descriptionMap = new();

        public ICollection GetMenuSet()
        {
            return menuMap.Keys;
        }

        public string? GetMenuTranslate(string menuName)
        {
            return menuMap[menuName].ToString();
        }

        public ICollection GetButtonSet()
        {
            return buttonsMap.Keys;
        }

        public string? GetButtonTranslate(string buttonName)
        {
            return buttonsMap[buttonName].ToString();
        }

        public ICollection GetTabControlsSet()
        {
            return tabPanesMap.Keys;
        }

        public string? GetTabTranslate(string tabPaneName, string tabName)
        {
            return tabPanesMap[tabPaneName][tabName].ToString();
        }

        public string? GetMessageTranslate(string message)
        {
            return messageMap[message].ToString();
        }

        public string? GetDescriptionTranslate(string name)
        {
            return descriptionMap[name].ToString();
        }
    }

    class Ru : Language
    {
        public Ru()
        {
            menuMap.Add("configurationMenu", "Конфигурация");
            menuMap.Add("configurationMenuOpen", "Открыть..");
            menuMap.Add("configurationMenuSave", "Сохранить..");
            menuMap.Add("configurationMenuExit", "Выход");

            menuMap.Add("comportMenu", "COM порт");
            menuMap.Add("comportMenuReadWhenOpen", "Чтение при окрытии");
            menuMap.Add("comportMenuReadOnline", "Чтение онлайн");
            menuMap.Add("comportMenuWriteOnline", "Запись онлайн");

            menuMap.Add("languageMenu", "Язык");
            menuMap.Add("languageMenuRu", "Русский");
            menuMap.Add("languageMenuEng", "Английский");


            buttonsMap.Add("scanButton", "Сканировать");
            buttonsMap.Add("openButton", "Открыть");
            buttonsMap.Add("closeButton", "Закрыть");
            buttonsMap.Add("readButton", "Прочитать");
            buttonsMap.Add("writeButton", "Записать");
            buttonsMap.Add("saveButton", "Сохранить");
            buttonsMap.Add("loadButton", "Загрузить");
            buttonsMap.Add("localButton", "Русский");


            Hashtable tabControl1 = new();

            tabControl1.Add("deviceTab", "Устройство");
            tabControl1.Add("options1Tab", "Параметры1");
            tabControl1.Add("options2Tab", "Параметры2");
            tabControl1.Add("text1Tab", "Текст1");
            tabControl1.Add("text2Tab", "Текст2");
            tabControl1.Add("text3Tab", "Текст3");
            tabControl1.Add("text4Tab", "Текст4");
            tabControl1.Add("qrcodeTab", "QR-код");

            tabPanesMap.Add("tabControl", tabControl1);


            messageMap.Add("greetingsMsg", "Выберите COM-порт и нажмите открыть");
            messageMap.Add("paramRequestSendMsg", "Параметры запрошены. Ожидается ответ...");
            messageMap.Add("paramWriteMsg", "Параметры записаны. Ожидается ответ...");
            messageMap.Add("tryMsg", "Нет ответа/неверный ответ. Попытка ");
            messageMap.Add("responseReceivedMsg", "Ответ получен");
            messageMap.Add("setupDoneMsg", "Параметры установлены");
            messageMap.Add("comPortOpenMsg", "COM-порт открыт");
            messageMap.Add("comPortFailMsg", "Ошибка открытия COM-порта");
            messageMap.Add("comPortCloseMsg", "COM-порт закрыт");
            messageMap.Add("cfgOpened", "Конфигурация открыта");
            messageMap.Add("cfgSaved", "Конфигурация сохранена");


            descriptionMap.Add("deviceType", "Тип устройства");
            descriptionMap.Add("id", "Серийный номер");
            descriptionMap.Add("name", "Имя устройства");
            descriptionMap.Add("firmwareVer", "Версия прошивки");
            descriptionMap.Add("mbAddress", "Modbus адрес");
            descriptionMap.Add("mbSpeed", "Modbus скорость");
            descriptionMap.Add("wifiLogin", "Логин WI-Fi точки доступа");
            descriptionMap.Add("wifiPassword", "Пароль WI-FI точки доступа");

            descriptionMap.Add("mb_1", "Видимость элементов");
            descriptionMap.Add("mb_2", "Отображение текста");
            descriptionMap.Add("mb_3", "Цвет баланса");
            descriptionMap.Add("mb_4", "Цвет символа предупреждения");
            descriptionMap.Add("mb_5", "Цвет линии разделителя");
            descriptionMap.Add("mb_6", "Цвет нестандарт. экрана");
            descriptionMap.Add("mb_7", "Цвет строки 1");
            descriptionMap.Add("mb_8", "Цвет строки 2");
            descriptionMap.Add("mb_9", "Цвет строки 3");
            descriptionMap.Add("mb_10", "Цвет строки 4");

            descriptionMap.Add("mb_11", "Размер шрифта текста");
            descriptionMap.Add("mb_12", "Тип символа предупреждения");
            descriptionMap.Add("mb_13", "Тип линии разделителя");
            descriptionMap.Add("mb_14", "Тип нестандартного экрана");
            descriptionMap.Add("mb_15", "Тип анимации смены баланса");
            descriptionMap.Add("mb_16", "Тип анимации режима ожидания");
            descriptionMap.Add("mb_17", "Время повтора анимации ожидания");
            descriptionMap.Add("mb_18", "Тип отображения баланса");

            descriptionMap.Add("mb_50", "Яркость");
            descriptionMap.Add("mb_51", "Порядок RGB каналов");

            descriptionMap.Add("mb_100", "Значение баланса");

            descriptionMap.Add("mb_101", "Текст. Строка 1");
            descriptionMap.Add("mb_102", "Текст. Строка 1");
            descriptionMap.Add("mb_103", "Текст. Строка 1");
            descriptionMap.Add("mb_104", "Текст. Строка 1");
            descriptionMap.Add("mb_105", "Текст. Строка 1");
            descriptionMap.Add("mb_106", "Текст. Строка 1");
            descriptionMap.Add("mb_107", "Текст. Строка 1");
            descriptionMap.Add("mb_108", "Текст. Строка 1");
            descriptionMap.Add("mb_109", "Текст. Строка 1");
            descriptionMap.Add("mb_110", "Текст. Строка 1");

            descriptionMap.Add("mb_111", "Текст. Строка 2");
            descriptionMap.Add("mb_112", "Текст. Строка 2");
            descriptionMap.Add("mb_113", "Текст. Строка 2");
            descriptionMap.Add("mb_114", "Текст. Строка 2");
            descriptionMap.Add("mb_115", "Текст. Строка 2");
            descriptionMap.Add("mb_116", "Текст. Строка 2");
            descriptionMap.Add("mb_117", "Текст. Строка 2");
            descriptionMap.Add("mb_118", "Текст. Строка 2");
            descriptionMap.Add("mb_119", "Текст. Строка 2");
            descriptionMap.Add("mb_120", "Текст. Строка 2");

            descriptionMap.Add("mb_121", "Текст. Строка 3");
            descriptionMap.Add("mb_122", "Текст. Строка 3");
            descriptionMap.Add("mb_123", "Текст. Строка 3");
            descriptionMap.Add("mb_124", "Текст. Строка 3");
            descriptionMap.Add("mb_125", "Текст. Строка 3");
            descriptionMap.Add("mb_126", "Текст. Строка 3");
            descriptionMap.Add("mb_127", "Текст. Строка 3");
            descriptionMap.Add("mb_128", "Текст. Строка 3");
            descriptionMap.Add("mb_129", "Текст. Строка 3");
            descriptionMap.Add("mb_130", "Текст. Строка 3");

            descriptionMap.Add("mb_131", "Текст. Строка 4");
            descriptionMap.Add("mb_132", "Текст. Строка 4");
            descriptionMap.Add("mb_133", "Текст. Строка 4");
            descriptionMap.Add("mb_134", "Текст. Строка 4");
            descriptionMap.Add("mb_135", "Текст. Строка 4");
            descriptionMap.Add("mb_136", "Текст. Строка 4");
            descriptionMap.Add("mb_137", "Текст. Строка 4");
            descriptionMap.Add("mb_138", "Текст. Строка 4");
            descriptionMap.Add("mb_139", "Текст. Строка 4");
            descriptionMap.Add("mb_140", "Текст. Строка 4");

            descriptionMap.Add("mb_202", "Год (4 цифры)");
            descriptionMap.Add("mb_203", "Месяц + день (4 цифры)");
            descriptionMap.Add("mb_204", "Время (4 цифры)");
            descriptionMap.Add("mb_205", "Целая часть оплаты (рубли 0-65635)");
            descriptionMap.Add("mb_206", "Дробная часть оплаты (копейки 0-99)");
            descriptionMap.Add("mb_207", "Номер фиск. накопителя (1-4 цифры)");
            descriptionMap.Add("mb_208", "Номер фиск. накопителя (5-8 цифры)");
            descriptionMap.Add("mb_209", "Номер фиск. накопителя (9-12 цифры)");
            descriptionMap.Add("mb_210", "Номер фиск. накопителя (13-16 цифры)");
            descriptionMap.Add("mb_211", "Номер фиск. документа (1-2 цифры)");
            descriptionMap.Add("mb_212", "Номер фиск. документа (3-6 цифры)");
            descriptionMap.Add("mb_213", "Номер фиск. документа (7-10 цифры)");
            descriptionMap.Add("mb_214", "Фискальный признак (1-2 цифры)");
            descriptionMap.Add("mb_215", "Фискальный признак (3-6 цифры)");
            descriptionMap.Add("mb_216", "Фискальный признак (7-10 цифры)");
            descriptionMap.Add("mb_217", "Признак расчета");
        }
    }

    class Eng : Language
    {
        public Eng()
        {
            menuMap.Add("configurationMenu", "Configuration");
            menuMap.Add("configurationMenuOpen", "Open..");
            menuMap.Add("configurationMenuSave", "Save..");
            menuMap.Add("configurationMenuExit", "Exit");

            menuMap.Add("comportMenu", "COM port");
            menuMap.Add("comportMenuReadWhenOpen", "Reading when opened");
            menuMap.Add("comportMenuReadOnline", "Reading online");
            menuMap.Add("comportMenuWriteOnline", "Writing online");

            menuMap.Add("languageMenu", "Language");
            menuMap.Add("languageMenuRu", "Russian");
            menuMap.Add("languageMenuEng", "English");

            buttonsMap.Add("scanButton", "Scan");
            buttonsMap.Add("openButton", "Open");
            buttonsMap.Add("closeButton", "Close");
            buttonsMap.Add("readButton", "Read");
            buttonsMap.Add("writeButton", "Write");
            buttonsMap.Add("saveButton", "Save cfg");
            buttonsMap.Add("loadButton", "Load cfg");
            buttonsMap.Add("localButton", "English");


            Hashtable tabControl1 = new();

            tabControl1.Add("deviceTab", "Device");
            tabControl1.Add("options1Tab", "Options1");
            tabControl1.Add("options2Tab", "Options2");
            tabControl1.Add("text1Tab", "Text1");
            tabControl1.Add("text2Tab", "Text2");
            tabControl1.Add("text3Tab", "Text3");
            tabControl1.Add("text4Tab", "Text4");
            tabControl1.Add("qrcodeTab", "QR-code");

            tabPanesMap.Add("tabControl", tabControl1);


            messageMap.Add("greetingsMsg", "Select a COM-port and press open");
            messageMap.Add("paramRequestSendMsg", "Parameter request sent. Response expected...");
            messageMap.Add("paramWriteMsg", "The parameters are written. Response expected...");
            messageMap.Add("tryMsg", "No response/wrong response. Try ");
            messageMap.Add("responseReceivedMsg", "Response received");
            messageMap.Add("setupDoneMsg", "Setup done");
            messageMap.Add("comPortOpenMsg", "COM-port opened");
            messageMap.Add("comPortFailMsg", "COM-port open fail");
            messageMap.Add("comPortCloseMsg", "COM-port closed");
            messageMap.Add("cfgOpened", "Configuration opened");
            messageMap.Add("cfgSaved", "Configuration saved");


            descriptionMap.Add("deviceType", "Device type");
            descriptionMap.Add("id", "Serial number");
            descriptionMap.Add("name", "Device name");
            descriptionMap.Add("firmwareVer", "Firmware version");
            descriptionMap.Add("mbAddress", "Modbus address");
            descriptionMap.Add("mbSpeed", "Modbus speed");
            descriptionMap.Add("wifiLogin", "Login WI-Fi access point");
            descriptionMap.Add("wifiPassword", "Password WI-FI access point");            

            descriptionMap.Add("mb_1", "Element visibility");
            descriptionMap.Add("mb_2", "Text visibility");
            descriptionMap.Add("mb_3", "Balance color");
            descriptionMap.Add("mb_4", "Exception symbol color");
            descriptionMap.Add("mb_5", "Separator line color");
            descriptionMap.Add("mb_6", "Custom screen color");
            descriptionMap.Add("mb_7", "Row color 1");
            descriptionMap.Add("mb_8", "Row color 2");
            descriptionMap.Add("mb_9", "Row color 3");
            descriptionMap.Add("mb_10", "Row color 4");

            descriptionMap.Add("mb_11", "Text font size");
            descriptionMap.Add("mb_12", "Warning character type");
            descriptionMap.Add("mb_13", "Separator line type");
            descriptionMap.Add("mb_14", "Custom screen type");
            descriptionMap.Add("mb_15", "Balance change animation type");
            descriptionMap.Add("mb_16", "Idle mode animation type");
            descriptionMap.Add("mb_17", "Wait animation repeat time");
            descriptionMap.Add("mb_18", "Balance display type");

            descriptionMap.Add("mb_50", "Brightness");
            descriptionMap.Add("mb_51", "RGB channel order");

            descriptionMap.Add("mb_100", "Balance");

            descriptionMap.Add("mb_101", "Text. Line 1");
            descriptionMap.Add("mb_102", "Text. Line 1");
            descriptionMap.Add("mb_103", "Text. Line 1");
            descriptionMap.Add("mb_104", "Text. Line 1");
            descriptionMap.Add("mb_105", "Text. Line 1");
            descriptionMap.Add("mb_106", "Text. Line 1");
            descriptionMap.Add("mb_107", "Text. Line 1");
            descriptionMap.Add("mb_108", "Text. Line 1");
            descriptionMap.Add("mb_109", "Text. Line 1");
            descriptionMap.Add("mb_110", "Text. Line 1");

            descriptionMap.Add("mb_111", "Text. Line 2");
            descriptionMap.Add("mb_112", "Text. Line 2");
            descriptionMap.Add("mb_113", "Text. Line 2");
            descriptionMap.Add("mb_114", "Text. Line 2");
            descriptionMap.Add("mb_115", "Text. Line 2");
            descriptionMap.Add("mb_116", "Text. Line 2");
            descriptionMap.Add("mb_117", "Text. Line 2");
            descriptionMap.Add("mb_118", "Text. Line 2");
            descriptionMap.Add("mb_119", "Text. Line 2");
            descriptionMap.Add("mb_120", "Text. Line 2");

            descriptionMap.Add("mb_121", "Text. Line 3");
            descriptionMap.Add("mb_122", "Text. Line 3");
            descriptionMap.Add("mb_123", "Text. Line 3");
            descriptionMap.Add("mb_124", "Text. Line 3");
            descriptionMap.Add("mb_125", "Text. Line 3");
            descriptionMap.Add("mb_126", "Text. Line 3");
            descriptionMap.Add("mb_127", "Text. Line 3");
            descriptionMap.Add("mb_128", "Text. Line 3");
            descriptionMap.Add("mb_129", "Text. Line 3");
            descriptionMap.Add("mb_130", "Text. Line 3");

            descriptionMap.Add("mb_131", "Text. Line 4");
            descriptionMap.Add("mb_132", "Text. Line 4");
            descriptionMap.Add("mb_133", "Text. Line 4");
            descriptionMap.Add("mb_134", "Text. Line 4");
            descriptionMap.Add("mb_135", "Text. Line 4");
            descriptionMap.Add("mb_136", "Text. Line 4");
            descriptionMap.Add("mb_137", "Text. Line 4");
            descriptionMap.Add("mb_138", "Text. Line 4");
            descriptionMap.Add("mb_139", "Text. Line 4");
            descriptionMap.Add("mb_140", "Text. Line 4");

            descriptionMap.Add("mb_202", "Year (4 digits)");
            descriptionMap.Add("mb_203", "Month + day (4 digits)");
            descriptionMap.Add("mb_204", "Time (4 digits)");
            descriptionMap.Add("mb_205", "Integer part of the payment (rubles 0-65635)");
            descriptionMap.Add("mb_206", "Fractional part of the payment (penny 0-99)");
            descriptionMap.Add("mb_207", "Fiscal drive number (1-4 digits)");
            descriptionMap.Add("mb_208", "Fiscal drive number (5-8 digits)");
            descriptionMap.Add("mb_209", "Fiscal drive number (9-12 digits)");
            descriptionMap.Add("mb_210", "Fiscal drive number (13-16 digits)");
            descriptionMap.Add("mb_211", "Fiscal document number (1-2 digits)");
            descriptionMap.Add("mb_212", "Fiscal document number (3-6 digits)");
            descriptionMap.Add("mb_213", "Fiscal document number (7-10 digits)");
            descriptionMap.Add("mb_214", "Fiscal sign (1-2 digits)");
            descriptionMap.Add("mb_215", "Fiscal sign (3-6 digits)");
            descriptionMap.Add("mb_216", "Fiscal sign (7-10 digits)");
            descriptionMap.Add("mb_217", "Settlement attribute");
        }
        
    }
}
