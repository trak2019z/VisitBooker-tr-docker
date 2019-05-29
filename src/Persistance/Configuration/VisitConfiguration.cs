using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Persistance.Configuration
{
    class VisitConfiguration : IEntityTypeConfiguration<Visit>
    {
        public void Configure(EntityTypeBuilder<Visit> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Status).HasConversion(
                v => v.ToString(),
                v => (VisitStatus)Enum.Parse(typeof(VisitStatus), v)).IsRequired();

            builder.Property(x => x.VisitDate).IsRequired();

            builder.HasOne(x => x.User).WithMany(x => x.Visits)
                .HasForeignKey(x => x.UserName);

        }
    }
}
