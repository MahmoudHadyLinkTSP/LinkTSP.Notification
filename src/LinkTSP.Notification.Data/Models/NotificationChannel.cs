using System;
using System.Collections.Generic;

namespace LinkTSP.Notification.Data.Models;

public partial class NotificationChannel
{
    public virtual int Id { get; set; }

    public virtual int NotificationId { get; set; }

    public virtual int ChannelId { get; set; }

    public virtual Notification Notification { get; set; }
}
