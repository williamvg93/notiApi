using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Person;

public class TeacherModule : BaseEntity
{
    public string Name { get; set; }

    /* Foreign Key for Rol Teachers */
    public ICollection<RolTeacher> RolTeachers { get; set; }

    /* Foreign Key for Teacher Sub Module */
    public ICollection<TeacherSubModule> TeacherSubModules { get; set; }
    /* ------------------------------------ */

}
