using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Person;

public class SubModules : BaseEntity
{
    public string Name { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime ModificationDate { get; set; }

    /* Foreign Key for Teacher Sub Module */
    public ICollection<TeacherSubModule> TeacherSubModules { get; set; }
}
