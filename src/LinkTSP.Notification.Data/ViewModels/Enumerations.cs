using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkTSP.Notification.ViewModels;

public enum TemplateStatus
{
    Deleted = 0,
    Live = 1,
}

public enum EventStatus
{
    Deleted = 0,
    Live = 1,
}

public enum NotificationStatus
{
    Deleted = 0,
    Live = 1,
    Suspended = 2,
    Sent = 3,
}

public enum Channels
{
    Email = 1,
    SMS = 2,
    Device = 3,
    whatsApp = 4
}

public enum UsersNotificationStatus
{
    New = 1,
    Sent = 2,
    Readed = 3,
}
