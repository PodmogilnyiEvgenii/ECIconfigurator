using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Principal;
using System.Windows.Markup;

namespace ECIconfigurator
{
    class JsonUtils
    {
        public static string GetRequestMessage()
        {
            JObject request = new JObject();
            request.Add("type", "get");

            return request.ToString(Formatting.None);
        }

        public static bool IsValidJson(string json)
        {
            try
            {
                JObject jsonObject = JObject.Parse(json);
                return true;
            }
            catch (JsonReaderException)
            {
                //System.Diagnostics.Trace.WriteLine("Json parsing failed: " + e.Message);
                return false;                
            }
        }

        public static string DeviceToJsonString(Device device)
        {
            return JsonConvert.SerializeObject(device, Formatting.None);
        }

        public static Device? JsonStringToDevice(string jsonString)
        {
            return JsonConvert.DeserializeObject<Device>(jsonString);
        }
    }
}
