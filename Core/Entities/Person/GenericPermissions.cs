using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Person;

public class GenericPermissions : BaseEntity
{
    public string Name { get; set; }

    /* Foreign Key for Generic SUb Modules */
    public ICollection<GenericSubModules> GenericSubModules { get; set; }
    /* ------------------------------------ */
}
