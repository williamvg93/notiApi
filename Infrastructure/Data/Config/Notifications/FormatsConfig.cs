using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.Notifications;

public class FormatsConfig : IEntityTypeConfiguration<Formats>
{
    public void Configure(EntityTypeBuilder<Formats> builder)
    {
        /* Assign Table name */
        builder.ToTable("formats");

        /* Assign Primary Key */
        builder.HasKey(pk => pk.Id);
        builder.Property(pk => pk.Id);

        /* Assign Colums */

        builder.Property(n => n.Name)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(cd => cd.CreationDate)
        .HasColumnType("datetime");

        builder.Property(cd => cd.ModificationDate)
        .HasColumnType("datetime");
    }
}
