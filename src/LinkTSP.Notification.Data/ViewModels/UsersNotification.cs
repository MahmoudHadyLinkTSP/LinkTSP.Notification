
using System;

namespace LinkTSP.Notification.ViewModels
{
    public class UsersNotificationViewModel
    {
        public virtual int Id { get; set; }

        public virtual int NotificationId { get; set; }

        public virtual string NotificationSubject { get; set; }

        public virtual string UserId { get; set; }

        public virtual string User { get; set; }

        public virtual DateTime CreatedDate { get; set; }

        public virtual UsersNotificationStatus StatusId { get; set; }

        public virtual DateTime? ReadDate { get; set; }
    }
}
