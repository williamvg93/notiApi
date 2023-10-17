using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Person;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.Person;

public class TeacherSubModuConfig : IEntityTypeConfiguration<TeacherSubModule>
{
    public void Configure(EntityTypeBuilder<TeacherSubModule> builder)
    {
        /* Assign Table name */
        builder.ToTable("teachersubmodule");

        /* Assign Primary Key */
        builder.HasKey(pk => pk.Id);
        builder.Property(pk => pk.Id);

        /* Assign Colums */
        builder.Property(cd => cd.CreationDate)
        .HasColumnType("datetime");

        builder.Property(cd => cd.ModificationDate)
        .HasColumnType("datetime");

        /* ------------------------------------------------- */
        /* Assign Foreign Key */

        builder.HasOne(fk => fk.TeacherModules)
        .WithMany(fk => fk.TeacherSubModules)
        .HasForeignKey(fk => fk.IdTeacherModuFk);

        builder.HasOne(fk => fk.SubModules)
        .WithMany(fk => fk.TeacherSubModules)
        .HasForeignKey(fk => fk.IdSubModulesFk);

        /* ------------------------------------------------- */
    }
}
