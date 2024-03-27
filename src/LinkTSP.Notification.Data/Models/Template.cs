using System;
using System.Collections.Generic;

namespace LinkTSP.Notification.Data.Models;

public partial class Template: IStatus
{
    public virtual int Id { get; set; }

    public virtual string Name { get; set; }

    public virtual string Subject { get; set; }

    public virtual string Message { get; set; }

    public virtual int StatusId { get; set; }
    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}