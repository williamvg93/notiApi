using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Notifications;
using Core.Interfaces.Notifications;
using Infrastructure.Data;

namespace Infrastructure.Repositories.Notifications;

public class RequiTypeRepo : GenericRepository<RequirementType>, IRequiType
{
    private readonly NotiApiContext _context;

    public RequiTypeRepo(NotiApiContext context) : base(context)
    {
        _context = context;
    }
}
