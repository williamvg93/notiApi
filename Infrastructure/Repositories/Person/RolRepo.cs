using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Person;
using Core.Interfaces.Person;
using Infrastructure.Data;

namespace Infrastructure.Repositories.Person;

public class RolRepo : GenericRepository<Rol>, IRol
{
    private readonly NotiApiContext _context;

    public RolRepo(NotiApiContext context) : base(context)
    {
        _context = context;
    }
}
