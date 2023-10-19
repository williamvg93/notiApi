using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Notifications;

public class FiledNumber : BaseEntity
{
    /* Foreign Key for Notification Modules */
    public ICollection<NotificationModule> NotiModules { get; set; }

    /* ------------------------------------ */
}
