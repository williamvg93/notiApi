using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos.Post.Notification;

public class NotificationModulePDto
{
    public int Id { get; set; }
    public string NotiSubject { get; set; }
    public string Text { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime ModificationDate { get; set; }
    public int IdNotiTypeFk { get; set; }
    public int IdFiledNumFk { get; set; }
    public int IdFotmatFk { get; set; }
    public int IdNotiStatusFk { get; set; }
    public int IdNotiResFk { get; set; }
    public int IdRequiTypeFk { get; set; }
}
