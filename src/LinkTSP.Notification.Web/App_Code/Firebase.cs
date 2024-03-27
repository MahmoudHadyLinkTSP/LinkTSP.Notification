using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Builder.Extensions;

namespace LinkTSP.Notification.Web.App_Code
{
    public class Firebase
    {
        public static void Send(Message message)
        {

            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("FirebaseSetting.json"),
            });

            //var message = new Message()
            //{
            //    Notification = new Notification
            //    {
            //        Title = "Test Notification",
            //        Body = "This is a test notification Body",
            //    },
            //    Token = "eW9lRJZ0Sfukm9qgYV3kmC:APA91bFUHfeG0OFTmz7SARQbu-BL79TstwAdqUiEE5xcfQN9BA8R2uDaRO3nXWMkQOVsna3dxR3nFvYFUOYU3aRSkMFY3jbOUBIphsu5jKzu4kKoH91bmxEqcQM65cTVMj-seOxuZcyS"
            //};

            // Send the message
            var response = FirebaseMessaging.DefaultInstance.SendAsync(message).Result;
        }

        public static void SendBulk(Message message, string token)
        {

            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("FirebaseSetting.json"),
            });

            //var message = new Message()
            //{
            //    Notification = new Notification
            //    {
            //        Title = "Test Notification",
            //        Body = "This is a test notification Body",
            //    },
            //    Token = "eW9lRJZ0Sfukm9qgYV3kmC:APA91bFUHfeG0OFTmz7SARQbu-BL79TstwAdqUiEE5xcfQN9BA8R2uDaRO3nXWMkQOVsna3dxR3nFvYFUOYU3aRSkMFY3jbOUBIphsu5jKzu4kKoH91bmxEqcQM65cTVMj-seOxuZcyS"
            //};

            // Send the message
            var response = FirebaseMessaging.DefaultInstance.SendAsync(message).Result;
        }
    }
}
