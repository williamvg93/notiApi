using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.Notifications;

public class RequiTypeConfig : IEntityTypeConfiguration<RequirementType>
{
    public void Configure(EntityTypeBuilder<RequirementType> builder)
    {
        /* Assign Table name */
        builder.ToTable("requirementtype");

        /* Assign Primary Key */
        builder.HasKey(pk => pk.Id);
        builder.Property(pk => pk.Id);

        /* Assign Colums */
        builder.Property(n => n.Name)
        .IsRequired()
        .HasMaxLength(80);

        builder.Property(cd => cd.CreationDate)
        .HasColumnType("datetime");

        builder.Property(cd => cd.ModificationDate)
        .HasColumnType("datetime");
    }
}
