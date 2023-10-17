using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos.Get.Block;

public class AuditorDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public long ActionDes { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime ModificationDate { get; set; }
}
