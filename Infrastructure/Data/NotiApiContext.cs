using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Core.Entities.Block;
using Core.Entities.Notifications;
using Core.Entities.Person;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class NotiApiContext : DbContext
{
    public NotiApiContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<FiledNumber> FiledNumbers { get; set; }
    public DbSet<Formats> Formats { get; set; }
    public DbSet<NotificationResponse> NotiResponses { get; set; }
    public DbSet<NotificationStatus> NotiStatuses { get; set; }
    public DbSet<NotificationType> NotiTypes { get; set; }
    public DbSet<RequirementType> RequirementTypes { get; set; }
    public DbSet<NotificationModule> NotiModules { get; set; }
    public DbSet<Auditor> Auditors { get; set; }
    public DbSet<BlockChain> BlockChains { get; set; }
    public DbSet<GenericPermissions> GenericPermissions { get; set; }
    public DbSet<Rol> Rols { get; set; }
    public DbSet<RolTeacher> RolTeachers { get; set; }
    public DbSet<SubModules> SubModules { get; set; }
    public DbSet<TeacherModule> TeacherModules { get; set; }
    public DbSet<GenericSubModules> GeneSubModules { get; set; }
    public DbSet<TeacherSubModule> TeaSubModules { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
