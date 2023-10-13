using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Person;
using Core.Interfaces.Person;
using Infrastructure.Data;

namespace Infrastructure.Repositories.Person;

public class TeacherModuRepo : GenericRepository<TeacherModule>, ITeacherModu
{
    private readonly NotiApiContext _context;

    public TeacherModuRepo(NotiApiContext context) : base(context)
    {
        _context = context;
    }
}
