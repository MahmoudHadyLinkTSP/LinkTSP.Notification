using System;
using System.Collections.Generic;

namespace LinkTSP.Notification.Data.Models;

public partial class Event:IStatus
{
    public virtual int Id { get; set; }

    public virtual string Name { get; set; }
    public virtual int StatusId { get; set; }
}
