using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Notifications;

public class RequirementType : BaseEntity
{
    public string Name { get; set; }

    /* Foreign Key for Notification Modules */
    public ICollection<NotificationModule> NotiModules { get; set; }

    /* ------------------------------------ */
}
