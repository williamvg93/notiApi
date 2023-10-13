using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Block;
using Core.Interfaces.Block;
using Infrastructure.Data;

namespace Infrastructure.Repositories.Block;

public class BlockChainRepo : GenericRepository<BlockChain>, IBlockChain
{
    private readonly NotiApiContext _context;

    public BlockChainRepo(NotiApiContext context) : base(context)
    {
        _context = context;
    }
}
