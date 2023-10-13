using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Person;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.Person;

public class RolTeacherConfig : IEntityTypeConfiguration<RolTeacher>
{
    public void Configure(EntityTypeBuilder<RolTeacher> builder)
    {
        /* Assign Table name */
        builder.ToTable("rol");

        /* Assign Primary Key */
        builder.HasKey(pk => pk.Id);

        /* Assign Colums */

        builder.Property(cd => cd.CreationDate)
        .HasColumnType("datetime");

        builder.Property(cd => cd.ModificationDate)
        .HasColumnType("datetime");

        /* ------------------------------------------------- */
        /* Assign Foreign Key */

        builder.HasOne(fk => fk.Rols)
        .WithMany(fk => fk.RolTeachers)
        .HasForeignKey(fk => fk.IdRolFk);

        builder.HasOne(fk => fk.TeacherModules)
        .WithMany(fk => fk.RolTeachers)
        .HasForeignKey(fk => fk.IdTecherModuFk);

        /* ------------------------------------------------- */
    }
}
