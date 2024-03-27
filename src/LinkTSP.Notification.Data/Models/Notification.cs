using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinkTSP.Notification.Data.Models;

public partial class Notification : IStatus
{
    public virtual int Id { get; set; }

    public virtual DateTime CreatedAt { get; set; }

    public virtual DateTime SendAt { get; set; }

    public virtual string UserId { get; set; }     

    public virtual int TemplateId { get; set; }

    [ForeignKey(nameof(TemplateId))]
    public virtual Template Template { get; set; }

    public virtual string Name { get; set; }

    public virtual string Subject { get; set; }

    public virtual string Message { get; set; }

    public virtual string CallToAction { get; set; }

    public virtual string ImageUrl { get; set; }

    public virtual int StatusId { get; set; }

    public virtual ICollection<NotificationChannel> Channels { get; set; } = new List<NotificationChannel>();

    public virtual ICollection<UsersNotification> Users { get; set; } = new List<UsersNotification>();
}
