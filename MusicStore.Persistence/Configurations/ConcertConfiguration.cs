﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStore.Entities;

namespace MusicStore.Persistence.Configurations
{
    public class ConcertConfiguration : IEntityTypeConfiguration<Concert>
    {
        public void Configure(EntityTypeBuilder<Concert> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(50);
            builder.Property(x => x.Description).HasMaxLength(100);
            builder.Property(x => x.Place).HasMaxLength(100);
            builder.Property(x => x.UnitePrice).HasColumnType("decimal(10,2)");
            builder.Property(x => x.DateEvent)
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.ImageUrl)
                .HasMaxLength(1000)
                .IsUnicode(false);
            builder.HasIndex(x => x.Title);

            builder.ToTable("Concerts", schema: "Musicales");
        }
    }
}
