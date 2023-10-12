using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Notifications;

public class NotificationModule : BaseEntity
{
    public string NotiSubject { get; set; }
    public string Text { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime ModificationDate { get; set; }

    /* --------- Foreign Keys ---------- */

    /* Foreign Key for Notification Type */
    public int IdNotiTypeFk { get; set; }
    public NotificationType NotiTypes { get; set; }

    /* Foreign Key for Filed Number */
    public int IdFiledNumFk { get; set; }
    public FiledNumber FiledNumbers { get; set; }

    /* Foreign Key for Filed Number */
    public int IdFotmatFk { get; set; }
    public Formats Formats { get; set; }

    /* Foreign Key for Notification Status */
    public int IdNotiStatusFk { get; set; }
    public NotificationStatus NotiStatus { get; set; }

    /* Foreign Key for Notification Response */
    public int IdNotiResFk { get; set; }
    public NotificationResponse NotiResponses { get; set; }

    /* Foreign Key for Requirement Type */
    public int IdRequiTypeFk { get; set; }
    public RequirementType RequiTypes { get; set; }


}
