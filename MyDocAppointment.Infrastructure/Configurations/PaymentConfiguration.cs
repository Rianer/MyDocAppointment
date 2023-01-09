using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MyDocAppointment.Business.Logistics.External;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyDocAppointment.Business.Helpers;

namespace MyDocAppointment.Infrastructure.Configurations
{
    internal class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Amount);
            builder.Property(d => d.PaymentMethod)
                .HasConversion(new EnumToStringConverter<PaymentMethod>());
            builder.Property(d => d.DueDate);
            builder.Property(d => d.EmissionDate);
            builder.Property(d => d.AcquittedDate);
        }
    }
}
