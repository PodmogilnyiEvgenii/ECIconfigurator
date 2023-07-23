using Newtonsoft.Json;
using System;
using static ECIconfigurator.MainWindow;

namespace ECIconfigurator
{
    public class Device 
    {
        public string type = "set";
        public string deviceType = "";
        public string id = "";
        public string name = "";
        public string firmwareVer = "";
        public string mbAddress = "";
        public string mbSpeed = "";
        public string wifiLogin = "";
        public string wifiPassword = "";

        [JsonProperty("1")] public string mb_1 = "";
        [JsonProperty("2")] public string mb_2 = "";
        [JsonProperty("3")] public string mb_3 = "";
        [JsonProperty("4")] public string mb_4 = "";
        [JsonProperty("5")] public string mb_5 = "";
        [JsonProperty("6")] public string mb_6 = "";
        [JsonProperty("7")] public string mb_7 = "";
        [JsonProperty("8")] public string mb_8 = "";
        [JsonProperty("9")] public string mb_9 = "";
        [JsonProperty("10")] public string mb_10 = "";
        [JsonProperty("11")] public string mb_11 = "";
        [JsonProperty("12")] public string mb_12 = "";
        [JsonProperty("13")] public string mb_13 = "";
        [JsonProperty("14")] public string mb_14 = "";
        [JsonProperty("15")] public string mb_15 = "";
        [JsonProperty("16")] public string mb_16 = "";
        [JsonProperty("17")] public string mb_17 = "";
        [JsonProperty("18")] public string mb_18 = "";
        [JsonProperty("50")] public string mb_50 = "";
        [JsonProperty("51")] public string mb_51 = "";

        [JsonProperty("100")] public string mb_100 = "";

        [JsonProperty("101")] public string mb_101 = "";
        [JsonProperty("102")] public string mb_102 = "";
        [JsonProperty("103")] public string mb_103 = "";
        [JsonProperty("104")] public string mb_104 = "";
        [JsonProperty("105")] public string mb_105 = "";
        [JsonProperty("106")] public string mb_106 = "";
        [JsonProperty("107")] public string mb_107 = "";
        [JsonProperty("108")] public string mb_108 = "";
        [JsonProperty("109")] public string mb_109 = "";
        [JsonProperty("110")] public string mb_110 = "";

        [JsonProperty("111")] public string mb_111 = "";
        [JsonProperty("112")] public string mb_112 = "";
        [JsonProperty("113")] public string mb_113 = "";
        [JsonProperty("114")] public string mb_114 = "";
        [JsonProperty("115")] public string mb_115 = "";
        [JsonProperty("116")] public string mb_116 = "";
        [JsonProperty("117")] public string mb_117 = "";
        [JsonProperty("118")] public string mb_118 = "";
        [JsonProperty("119")] public string mb_119 = "";
        [JsonProperty("120")] public string mb_120 = "";

        [JsonProperty("121")] public string mb_121 = "";
        [JsonProperty("122")] public string mb_122 = "";
        [JsonProperty("123")] public string mb_123 = "";
        [JsonProperty("124")] public string mb_124 = "";
        [JsonProperty("125")] public string mb_125 = "";
        [JsonProperty("126")] public string mb_126 = "";
        [JsonProperty("127")] public string mb_127 = "";
        [JsonProperty("128")] public string mb_128 = "";
        [JsonProperty("129")] public string mb_129 = "";
        [JsonProperty("130")] public string mb_130 = "";

        [JsonProperty("131")] public string mb_131 = "";
        [JsonProperty("132")] public string mb_132 = "";
        [JsonProperty("133")] public string mb_133 = "";
        [JsonProperty("134")] public string mb_134 = "";
        [JsonProperty("135")] public string mb_135 = "";
        [JsonProperty("136")] public string mb_136 = "";
        [JsonProperty("137")] public string mb_137 = "";
        [JsonProperty("138")] public string mb_138 = "";
        [JsonProperty("139")] public string mb_139 = "";
        [JsonProperty("140")] public string mb_140 = "";

        [JsonProperty("202")] public string mb_202 = "";
        [JsonProperty("203")] public string mb_203 = "";
        [JsonProperty("204")] public string mb_204 = "";
        [JsonProperty("205")] public string mb_205 = "";
        [JsonProperty("206")] public string mb_206 = "";
        [JsonProperty("207")] public string mb_207 = "";
        [JsonProperty("208")] public string mb_208 = "";
        [JsonProperty("209")] public string mb_209 = "";
        [JsonProperty("210")] public string mb_210 = "";
        [JsonProperty("211")] public string mb_211 = "";
        [JsonProperty("212")] public string mb_212 = "";
        [JsonProperty("213")] public string mb_213 = "";
        [JsonProperty("214")] public string mb_214 = "";
        [JsonProperty("215")] public string mb_215 = "";
        [JsonProperty("216")] public string mb_216 = "";
        [JsonProperty("217")] public string mb_217 = "";

        //public event ComportResponseReceivedEventHandler ComportResponseReceived;
        public override string ToString()
        {
            
            //System.Diagnostics.Trace.WriteLine("event " + ComportResponseReceived);
            //if (ComportResponseReceived!=null) ComportResponseReceived(this);
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
