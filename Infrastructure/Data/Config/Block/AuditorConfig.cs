using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Block;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.Block;

public class AuditorConfig : IEntityTypeConfiguration<Auditor>
{
    public void Configure(EntityTypeBuilder<Auditor> builder)
    {
        /* Assign Table name */
        builder.ToTable("auditor");

        /* Assign Primary Key */
        builder.HasKey(pk => pk.Id);

        /* Assign Colums */
        builder.Property(n => n.Name)
        .IsRequired()
        .HasMaxLength(100);

        builder.Property(n => n.ActionDes)
        .IsRequired()
        .HasColumnType("long");

        builder.Property(cd => cd.CreationDate)
        .HasColumnType("datetime");

        builder.Property(cd => cd.ModificationDate)
        .HasColumnType("datetime");
    }
}
