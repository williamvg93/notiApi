using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Person;

public class GenericSubModules : BaseEntity
{
    public DateTime CreationDate { get; set; }
    public DateTime ModificationDate { get; set; }

    /* --------- Foreign Keys ---------- */

    /* Foreign Key for Rol */
    public int IdRolFk { get; set; }
    public Rol Rols { get; set; }

    /* Foreign Key for Generic Permissions */
    public int IdGenePermiFk { get; set; }
    public GenericPermissions GenericPermissions { get; set; }

    /* Foreign Key for Sub Modules */
    public int IdTeacSubModuFk { get; set; }
    public TeacherSubModule TeaSubModules { get; set; }
}
