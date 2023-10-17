using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos.Post.Block;

public class BlockChainPDto
{
    public int Id { get; set; }
    public string GeneratedHash { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime ModificationDate { get; set; }
    public int IdNotiRespFk { get; set; }
    public int IdNotiTypeFk { get; set; }
    public int IdAuditorFk { get; set; }

}
