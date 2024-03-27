using LinkTSP.Notification.Web.Models;

namespace LinkTSP.Notification.Web.App_Code
{
    public class SMS
    {
        public static void Send(string massage, string receiver, string id, string campaignId = null)
        {
            var setting = SMSSetting.FromFile();

            SMSService.SMSSenderSoap client = new SMSService.SMSSenderSoapClient(SMSService.SMSSenderSoapClient.EndpointConfiguration.SMSSenderSoap);
            client.SendSMS(setting.UserName, setting.Password, massage, setting.Lang, setting.SMSSender, receiver, id, campaignId);
        }

        public static void SendMany(string massage, string[] SMSReceiver, string CampaignID)
        {
            var setting = SMSSetting.FromFile();
            SMSService.SMSSenderSoap client = new SMSService.SMSSenderSoapClient(SMSService.SMSSenderSoapClient.EndpointConfiguration.SMSSenderSoap);
            client.SendToMany(SMSReceiver, setting.UserName, setting.Password, massage, setting.Lang, setting.SMSSender, CampaignID, setting.WithDLR.ToString(), setting.Validty.ToString());
        }
    }
}
