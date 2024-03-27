using System;
using System.Collections.Generic;

namespace LinkTSP.Notification.ViewModels;

public class NotificationViewModel
{
    public virtual int Id { get; set; }

    public virtual DateTime CreatedAt { get; set; }

    public virtual DateTime SendAt { get; set; }

    public virtual string UserId { get; set; }

    public virtual int TemplateId { get; set; }

    public virtual string Template { get; set; }

    public virtual string Name { get; set; }

    public virtual string Subject { get; set; }

    public virtual string Message { get; set; }

    public virtual string CallToAction { get; set; }

    public virtual string ImageUrl { get; set; }

    public virtual bool AllUsers { get; set; }

    public virtual NotificationStatus StatusId { get; set; }

    public virtual IEnumerable<NotificationChannelViewModel> Channels{ get; set; }
    public virtual IEnumerable<UsersNotificationViewModel> Users { get; set; }
}
