using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MyDocAppointment.Business.Logistics.External;

namespace MyDocAppointment.Infrastructure.Configurations
{
    internal class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(a => a.Id);
            builder.HasAlternateKey(a => new { a.DoctorID, a.PatientID });
            builder.HasOne(a => a.Doctor).WithMany(d => d.Appointments);
            builder.HasOne(a => a.Patient).WithMany(p => p.Appointments);
            builder.Property(a => a.Specialization);
            builder.Property(a => a.AppointmentTime);
            builder.Property(a => a.Payment);
            builder.Property(a => a.Location);
        }
    }
}
