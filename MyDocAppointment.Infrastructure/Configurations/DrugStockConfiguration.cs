using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MyDocAppointment.Business.Logistics.Internal;

namespace MyDocAppointment.Infrastructure.Configurations
{
    internal class DrugEntryConfiguration : IEntityTypeConfiguration<DrugEntry>
    {
        public void Configure(EntityTypeBuilder<DrugEntry> builder)
        {
            builder.HasKey(d => d.Id);
            builder.HasOne(d => d.Drug);
            builder.Property(d => d.Quantity);
            builder.Property(d => d.ExpirationDate);
        }
    }
}
