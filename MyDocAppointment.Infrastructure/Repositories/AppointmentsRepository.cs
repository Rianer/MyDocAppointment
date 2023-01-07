using Microsoft.EntityFrameworkCore;
using MyDocAppointment.Business.Interfaces;
using MyDocAppointment.Business.Logistics.External;
namespace MyDocAppointment.Infrastructure.Repositories
{
    public class AppointmentsRepository : IAppointmentsRepository
    {
        private readonly AppDbContext _appDbContext;
        public AppointmentsRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Create(Appointment appointment)
        {
            _appDbContext.Appointments.Add(appointment);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Delete(Appointment appointment)
        {
            _appDbContext.Appointments.Remove(appointment);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAll() => await _appDbContext.Appointments
                                                    .Include(a => a.Doctor)
                                                    .Include(a => a.Patient)
                                                    .Include(a => a.Payment)
                                                    .ToListAsync();

        public async Task<Appointment?> GetById(Guid id)
        {
            var appointment = await _appDbContext.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Include(a => a.Payment)
                .FirstOrDefaultAsync(d => d.Id == id);

            return appointment;
        }

        public async Task SaveChanges()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
