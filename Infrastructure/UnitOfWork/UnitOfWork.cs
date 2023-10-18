using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Block;
using Core.Interfaces;
using Core.Interfaces.Block;
using Core.Interfaces.Notifications;
using Core.Interfaces.Person;
using Infrastructure.Data;
using Infrastructure.Repositories.Block;
using Infrastructure.Repositories.Notifications;
using Infrastructure.Repositories.Person;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly NotiApiContext _context;
    private AuditorRepo _auditors;
    private BlockChainRepo _blockchains;
    private FiledNumberRepo _filednumbers;
    private FormatsRepo _formats;
    private NotiModuleRepo _notimodules;
    private NotiResponseRepo _notiresponses;
    private NotiStatusRepo _notistatus;
    private NotiTypeRepo _notitype;
    private RequiTypeRepo _requitype;
    private GenericPermiRepo _genericpermi;
    private GeneSubModuRepo _genecsubmodu;
    private RolRepo _rol;
    private RolTeacherRepo _rolteacher;
    private SubModulesRepo _submodules;
    private TeacherModuRepo _teachermodu;
    private TeacherSubModuRepo _teachersubmodu;


    public UnitOfWork(NotiApiContext context)
    {
        _context = context;
    }

    public IAuditor Auditors
    {
        get
        {
            if (_auditors == null)
            {
                _auditors = new AuditorRepo(_context);
            }
            return _auditors;
        }
    }

    public IBlockChain BlockChains
    {
        get
        {
            if (_blockchains == null)
            {
                _blockchains = new BlockChainRepo(_context);
            }
            return _blockchains;
        }
    }

    public IFiledNumber FiledNumbers
    {
        get
        {
            if (_filednumbers == null)
            {
                _filednumbers = new FiledNumberRepo(_context);
            }
            return _filednumbers;
        }
    }

    public IFormats Formats
    {
        get
        {
            if (_formats == null)
            {
                _formats = new FormatsRepo(_context);
            }
            return _formats;
        }
    }

    public INotiModule NotiModules
    {
        get
        {
            if (_notimodules == null)
            {
                _notimodules = new NotiModuleRepo(_context);
            }
            return _notimodules;
        }
    }

    public INotiResponse NotiResponses
    {
        get
        {
            if (_notiresponses == null)
            {
                _notiresponses = new NotiResponseRepo(_context);
            }
            return _notiresponses;
        }
    }

    public INotiStatus NotiStatus
    {
        get
        {
            if (_notistatus == null)
            {
                _notistatus = new NotiStatusRepo(_context);
            }
            return _notistatus;
        }
    }

    public INotiType NotiTypes
    {
        get
        {
            if (_notitype == null)
            {
                _notitype = new NotiTypeRepo(_context);
            }
            return _notitype;
        }
    }

    public IRequiType RequiTypes
    {
        get
        {
            if (_requitype == null)
            {
                _requitype = new RequiTypeRepo(_context);
            }
            return _requitype;
        }
    }

    public IGenePermi GenePermissions
    {
        get
        {
            if (_genericpermi == null)
            {
                _genericpermi = new GenericPermiRepo(_context);
            }
            return _genericpermi;
        }
    }

    public IGeneSubModu GeneSubModules
    {
        get
        {
            if (_genecsubmodu == null)
            {
                _genecsubmodu = new GeneSubModuRepo(_context);
            }
            return _genecsubmodu;
        }
    }

    public IRol Rols
    {
        get
        {
            if (_rol == null)
            {
                _rol = new RolRepo(_context);
            }
            return _rol;
        }
    }

    public IRolTeacher RolTeachers
    {
        get
        {
            if (_rolteacher == null)
            {
                _rolteacher = new RolTeacherRepo(_context);
            }
            return _rolteacher;
        }
    }

    public ISubModules SubModules
    {
        get
        {
            if (_submodules == null)
            {
                _submodules = new SubModulesRepo(_context);
            }
            return _submodules;
        }
    }

    public ITeacherModu TeacherModules
    {
        get
        {
            if (_teachermodu == null)
            {
                _teachermodu = new TeacherModuRepo(_context);
            }
            return _teachermodu;
        }
    }

    public ITeacherSubModu TeacherSubModules
    {
        get
        {
            if (_teachersubmodu == null)
            {
                _teachersubmodu = new TeacherSubModuRepo(_context);
            }
            return _teachersubmodu;
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public Task<int> SaveAsync()
    {
        return _context.SaveChangesAsync();
    }
}
