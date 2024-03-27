using System.IO;
using Newtonsoft.Json;

namespace LinkTSP.Notification.Web.Models
{
    public class EmailSetting
    {
        [JsonProperty(nameof(UserName))]
        public string UserName { get; private set; }
        [JsonProperty(nameof(Password))]
        public string Password { get; private set; }
        [JsonProperty(nameof(Host))]
        public string Host { get; private set; }
        [JsonProperty(nameof(Port))]
        public string Port { get; private set; }
        [JsonProperty(nameof(Bcc))]
        public string Bcc { get; private set; }

        public static EmailSetting FromFile()
        {
            var str = File.ReadAllText("EmailSetting.json");
            return JsonConvert.DeserializeObject<EmailSetting>(str);

        }
    }
}
