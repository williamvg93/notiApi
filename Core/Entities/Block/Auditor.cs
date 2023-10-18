using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Core.Entities.Block;

public class Auditor : BaseEntity
{
    public string Name { get; set; }
    public int ActionDes { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime ModificationDate { get; set; }

    /* Foreign Key for Notification Modules */
    public ICollection<BlockChain> BlockChains { get; set; }
    /* ------------------------------------ */
}
