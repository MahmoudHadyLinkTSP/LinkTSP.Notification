using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinkTSP.Notification.Data.Models;

public partial class UsersNotification
{
    public virtual int Id { get; set; }

    public virtual int NotificationId { get; set; }

    public virtual string UserId { get; set; }

    public virtual DateTime CreatedDate { get; set; }

    public virtual int StatusId { get; set; }

    public virtual DateTime? ReadDate { get; set; }

    public virtual Notification Notification { get; set; }
}
