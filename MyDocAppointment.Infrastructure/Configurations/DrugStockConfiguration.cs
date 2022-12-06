using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MyDocAppointment.Business.Logistics.Internal;

namespace MyDocAppointment.Infrastructure.Configurations
{
    internal class DrugStockConfiguration : IEntityTypeConfiguration<DrugStock>
    {
        public void Configure(EntityTypeBuilder<DrugStock> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Item);
            builder.Property(d => d.Quantity);
            builder.Property(d => d.IsRestricted);
        }
    }
}
