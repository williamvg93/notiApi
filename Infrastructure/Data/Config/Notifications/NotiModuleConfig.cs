using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.Notifications;

public class NotiModuleConfig : IEntityTypeConfiguration<NotificationModule>
{
    public void Configure(EntityTypeBuilder<NotificationModule> builder)
    {
        /* Assign Table name */
        builder.ToTable("notificationmodule");

        /* Assign Primary Key */
        builder.HasKey(pk => pk.Id);

        /* Assign Colums */

        builder.Property(n => n.NotiSubject)
        .IsRequired()
        .HasMaxLength(80);

        builder.Property(n => n.Text)
        .IsRequired()
        .HasMaxLength(2000);

        builder.Property(cd => cd.CreationDate)
        .HasColumnType("datetime");

        builder.Property(cd => cd.ModificationDate)
        .HasColumnType("datetime");


        /* ------------------------------------------------- */
        /* Assign Foreign Key */

        builder.HasOne(fk => fk.NotiTypes)
        .WithMany(fk => fk.NotiModules)
        .HasForeignKey(fk => fk.IdNotiTypeFk);

        builder.HasOne(fk => fk.FiledNumbers)
        .WithMany(fk => fk.NotiModules)
        .HasForeignKey(fk => fk.IdFiledNumFk);

        builder.HasOne(fk => fk.Formats)
        .WithMany(fk => fk.NotiModules)
        .HasForeignKey(fk => fk.IdFotmatFk);

        builder.HasOne(fk => fk.NotiStatus)
        .WithMany(fk => fk.NotiModules)
        .HasForeignKey(fk => fk.IdNotiStatusFk);

        builder.HasOne(fk => fk.NotiResponses)
        .WithMany(fk => fk.NotiModules)
        .HasForeignKey(fk => fk.IdNotiResFk);

        builder.HasOne(fk => fk.RequiTypes)
        .WithMany(fk => fk.NotiModules)
        .HasForeignKey(fk => fk.IdRequiTypeFk);

        /* ------------------------------------------------- */
    }
}
