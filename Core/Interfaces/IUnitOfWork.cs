using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces.Block;
using Core.Interfaces.Notifications;
using Core.Interfaces.Person;

namespace Core.Interfaces;

public interface IUnitOfWork
{
    IAuditor Auditors { get; }
    IBlockChain BlockChains { get; }
    IFiledNumber FiledNumbers { get; }
    IFormats Formats { get; }
    INotiModule NotiModules { get; }
    INotiResponse NotiResponses { get; }
    INotiStatus NotiStatus { get; }
    INotiType NotiTypes { get; }
    IRequiType RequiTypes { get; }
    IGenePermi GenePermissions { get; }
    IGeneSubModu GeneSubModules { get; }
    IRol Rols { get; }
    IRolTeacher RolTeachers { get; }
    ISubModules SubModules { get; }
    ITeacherModu TeacherModules { get; }
    ITeacherSubModu TeacherSubModules { get; }
    Task<int> SaveAsync();

}
