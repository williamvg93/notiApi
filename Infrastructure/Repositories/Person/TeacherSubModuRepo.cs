using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Person;
using Core.Interfaces.Person;
using Infrastructure.Data;

namespace Infrastructure.Repositories.Person;

public class TeacherSubModuRepo : GenericRepository<TeacherSubModule>, ITeacherSubModu
{
    private readonly NotiApiContext _context;

    public TeacherSubModuRepo(NotiApiContext context) : base(context)
    {
        _context = context;
    }
}
