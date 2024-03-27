
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkTSP.Notification.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string DeviceToken { get; set; }
        public virtual IEnumerable<UsersNotificationViewModel> Notifications { get; set; }

    }
}
