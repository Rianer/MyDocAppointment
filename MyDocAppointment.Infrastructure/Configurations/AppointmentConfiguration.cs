using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore;
using MyDocAppointment.Business.Helpers;
using MyDocAppointment.Business.Users;
using MyDocAppointment.Business.Logistics.External;

namespace MyDocAppointment.Infrastructure.Configurations
{
    internal class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(a => a.Id);
            builder.HasAlternateKey(a => new { a.PatientID, a.DoctorID });
            builder.Property(a => a.Specialization);
            builder.Property(a => a.AppointmentTime);
            builder.Property(a => a.Payment);
            builder.Property(a => a.Location);
        }
    }
}
