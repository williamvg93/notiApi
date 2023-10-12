using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Block;

namespace Core.Entities.Notifications;

public class NotificationType : BaseEntity
{
    public string Name { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime ModificationDate { get; set; }

    /* Foreign Key for Notification Modules */
    public ICollection<NotificationModule> NotiModules { get; set; }

    /* Foreign Key for Block Chain */
    public ICollection<BlockChain> BlockChains { get; set; }

    /* ------------------------------------ */
}
