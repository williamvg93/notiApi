using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Block;
using Core.Interfaces.Block;
using Infrastructure.Data;

namespace Infrastructure.Repositories.Block;

public class AuditorRepo : GenericRepository<Auditor>, IAuditor
{
    private readonly NotiApiContext _context;

    public AuditorRepo(NotiApiContext context) : base(context)
    {
        _context = context;
    }
}
