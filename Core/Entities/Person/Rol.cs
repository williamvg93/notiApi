using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Person;

public class Rol : BaseEntity
{
    public string Name { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime ModificationDate { get; set; }

    /* Foreign Key for Rol Teachers */
    public ICollection<RolTeacher> RolTeachers { get; set; }

    /* Foreign Key for Generic SUb Modules */
    public ICollection<GenericSubModules> GenericSubModules { get; set; }
    /* ------------------------------------ */

}
