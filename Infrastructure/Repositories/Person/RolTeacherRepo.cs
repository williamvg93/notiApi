using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Person;
using Core.Interfaces.Person;
using Infrastructure.Data;

namespace Infrastructure.Repositories.Person;

public class RolTeacherRepo : GenericRepository<RolTeacher>, IRolTeacher
{
    private readonly NotiApiContext _context;

    public RolTeacherRepo(NotiApiContext context) : base(context)
    {
        _context = context;
    }
}
