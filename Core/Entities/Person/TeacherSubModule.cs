using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Person;

public class TeacherSubModule : BaseEntity
{
    public DateTime CreationDate { get; set; }
    public DateTime ModificationDate { get; set; }

    /* --------- Foreign Keys ---------- */

    /* Foreign Key for Rol Teacher */
    public int IdTeacherModuFk { get; set; }
    public TeacherModule TeacherModules { get; set; }

    /* Foreign Key for SUb Modules */
    public int IdSubModulesFk { get; set; }
    public SubModules SubModules { get; set; }

    /* Foreign Key for Generic SUb Modules */
    public ICollection<GenericSubModules> GenericSubModules { get; set; }
    /* ------------------------------------ */


}
