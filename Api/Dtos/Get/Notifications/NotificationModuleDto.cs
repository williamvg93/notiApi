using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos.Get.Notifications;

public class NotificationModuleDto
{
    public int Id { get; set; }
    public string NotiSubject { get; set; }
    public string Text { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime ModificationDate { get; set; }
}
