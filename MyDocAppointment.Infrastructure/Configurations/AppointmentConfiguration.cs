using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MyDocAppointment.Business.Logistics.External;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyDocAppointment.Business.Helpers;

namespace MyDocAppointment.Infrastructure.Configurations
{
    internal class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(a => new { a.Id, a.DoctorID, a.PatientID });
            builder.HasOne(a => a.Doctor).WithMany(d => d.Appointments);
            builder.HasOne(a => a.Patient).WithMany(p => p.Appointments);
            builder.Property(a => a.Specialization)
                .HasConversion(new EnumToStringConverter<Specialization>());
            builder.Property(a => a.AppointmentTime);
            builder.HasOne(a => a.Payment);
            builder.Property(a => a.Location);
        }
    }
}