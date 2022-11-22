using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyDocAppointment.Business.Helpers;
using MyDocAppointment.Business.Users;

namespace MyDocAppointment.Infrastructure.Configurations
{
    internal class DoctorConfiguration: IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(d=>d.Id);
            builder.Property(d => d.Name);
            builder.Property(d => d.Surname);
            builder.Property(d => d.Age);
            builder.Property(d => d.Gender)
                .HasConversion(new EnumToStringConverter<PersonGender>());
            builder.Property(d => d.EmailAddress);
            builder.HasMany(d => d.Appointments).WithOne(a => a.Doctor);
            builder.Property(d=> d.Speciality)
                .HasConversion(new EnumToStringConverter<Specialization>());
        }
    }
}
