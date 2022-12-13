using Microsoft.EntityFrameworkCore;
using MyDocAppointment.Business.Logistics.External;
using MyDocAppointment.Business.Logistics.Internal;
using MyDocAppointment.Business.Users;
using MyDocAppointment.Infrastructure.Configurations;

namespace MyDocAppointment.Infrastructure
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DoctorConfiguration());
            modelBuilder.ApplyConfiguration(new PatientConfiguration());
            modelBuilder.ApplyConfiguration(new DrugConfiguration());
            modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
