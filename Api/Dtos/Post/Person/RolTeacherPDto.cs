using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos.Post.Person;

public class RolTeacherPDto
{
    public int Id { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime ModificationDate { get; set; }
    public int IdRolFk { get; set; }
    public int IdTecherModuFk { get; set; }
}
