using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Person;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.Person;

public class GeneSubModuConfig : IEntityTypeConfiguration<GenericSubModules>
{
    public void Configure(EntityTypeBuilder<GenericSubModules> builder)
    {
        /* Assign Table name */
        builder.ToTable("genericsubmodules");

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

        builder.HasOne(fk => fk.Rols)
        .WithMany(fk => fk.GenericSubModules)
        .HasForeignKey(fk => fk.IdRolFk);

        builder.HasOne(fk => fk.GenericPermissionss)
        .WithMany(fk => fk.GenericSubModules)
        .HasForeignKey(fk => fk.IdGenePermiFk);

        builder.HasOne(fk => fk.TeacherSubModules)
        .WithMany(fk => fk.GenericSubModules)
        .HasForeignKey(fk => fk.IdTeacSubModuFk);

        /* ------------------------------------------------- */
    }
}
