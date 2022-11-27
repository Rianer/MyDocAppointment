using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore;
using MyDocAppointment.Business.Helpers;
using MyDocAppointment.Business.Users;

namespace MyDocAppointment.Infrastructure.Configurations
{
    internal class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name);
            builder.Property(p => p.Surname);
            builder.Property(p => p.Age);
            builder.Property(p => p.Gender)
                .HasConversion(new EnumToStringConverter<PersonGender>());
            builder.Property(p => p.EmailAddress);
            builder.HasMany(d => d.Appointments).WithOne(a => a.Patient);
            builder.HasMany(p => p.Diagnosis);
        }
    }
}
