using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Block;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.Block;

public class BlockChainConfig : IEntityTypeConfiguration<BlockChain>
{
    public void Configure(EntityTypeBuilder<BlockChain> builder)
    {
        /* Assign Table name */
        builder.ToTable("blockchain");

        /* Assign Primary Key */
        builder.HasKey(pk => pk.Id);

        /* Assign Colums */
        builder.Property(gh => gh.GeneratedHash)
        .IsRequired()
        .HasMaxLength(100);

        builder.Property(cd => cd.CreationDate)
        .HasColumnType("datetime");

        builder.Property(cd => cd.ModificationDate)
        .HasColumnType("datetime");

        /* ------------------------------------------------- */
        /* Assign Foreign Key */

        builder.HasOne(fk => fk.NotiResponses)
        .WithMany(fk => fk.BlockChains)
        .HasForeignKey(fk => fk.IdNotiRespFk);

        builder.HasOne(fk => fk.NotiTypes)
        .WithMany(fk => fk.BlockChains)
        .HasForeignKey(fk => fk.IdNotiTypeFk);

        builder.HasOne(fk => fk.Auditors)
        .WithMany(fk => fk.BlockChains)
        .HasForeignKey(fk => fk.IdAuditorFk);

        /* ------------------------------------------------- */

    }
}
