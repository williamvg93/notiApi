using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Notifications;

public class FiledNumber : BaseEntity
{
    public DateTime CreationDate { get; set; }
    public DateTime ModificationDate { get; set; }

}
