using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Person;

public class RolTeacher : BaseEntity
{
    /* --------- Foreign Keys ---------- */

    /* Foreign Key for Notification Status */
    public int IdRolFk { get; set; }
    public Rol Rols { get; set; }

    /* Foreign Key for Notification Status */
    public int IdTecherModuFk { get; set; }
    public TeacherModule TeacherModules { get; set; }
}
