using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Notifications;
using Core.Interfaces.Notifications;
using Infrastructure.Data;

namespace Infrastructure.Repositories.Notifications;

public class FormatsRepo : GenericRepository<Formats>, IFormats
{
    private readonly NotiApiContext _context;

    public FormatsRepo(NotiApiContext context) : base(context)
    {
        _context = context;
    }
}
