using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Notifications;

namespace Core.Entities.Block;

public class BlockChain : BaseEntity
{
    public string GeneratedHash { get; set; }

    /* --------- Foreign Keys ---------- */

    /* Foreign Key for Notification Response */
    public int IdNotiRespFk { get; set; }
    public NotificationResponse NotiResponses { get; set; }

    /* Foreign Key for Notification Type */
    public int IdNotiTypeFk { get; set; }
    public NotificationType NotiTypes { get; set; }

    /* Foreign Key for Auditor */
    public int IdAuditorFk { get; set; }
    public Auditor Auditors { get; set; }

}
