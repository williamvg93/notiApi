using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.Notifications;

public class FiledNumbConfig : IEntityTypeConfiguration<FiledNumber>
{
    public void Configure(EntityTypeBuilder<FiledNumber> builder)
    {
        /* Assign Table name */
        builder.ToTable("filednumber");

        /* Assign Primary Key */
        builder.HasKey(pk => pk.Id);

        /* Assign Colums */
        builder.Property(cd => cd.CreationDate)
        .IsRequired()
        .HasColumnType("datetime");

        builder.Property(cd => cd.ModificationDate)
        .IsRequired()
        .HasColumnType("datetime");
    }
}
