using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configuration
{
    class VisitTypeConfiguration : IEntityTypeConfiguration<VisitType>
    {
        public void Configure(EntityTypeBuilder<VisitType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasMany(x => x.Visits).WithOne(x => x.VisitType)
              .HasForeignKey(x => x.VisitTypeId);
        }
    }
}
