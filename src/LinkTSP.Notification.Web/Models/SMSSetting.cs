using System.IO;
using Newtonsoft.Json;

namespace LinkTSP.Notification.Web.Models
{
    public class SMSSetting
    {
        [JsonProperty(nameof(UserName))]
        public string UserName { get; private set; }
        [JsonProperty(nameof(Password))]
        public string Password { get; private set; }
        [JsonProperty(nameof(Lang))]
        public string Lang { get; private set; }
        [JsonProperty(nameof(SMSSender))]
        public string SMSSender { get; private set; }
        [JsonProperty(nameof(Validty))]
        public int Validty { get; private set; }
        [JsonProperty(nameof(WithDLR))]
        public bool WithDLR { get; private set; }

        public static SMSSetting FromFile()
        {
            var str = File.ReadAllText("SMSSetting.json");
            return JsonConvert.DeserializeObject<SMSSetting>(str);

        }
    }
}
