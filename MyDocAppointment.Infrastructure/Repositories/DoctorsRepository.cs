using Microsoft.EntityFrameworkCore;
using MyDocAppointment.Business.Interfaces;
using MyDocAppointment.Business.Users;

namespace MyDocAppointment.Infrastructure.Repositories
{
    public class DoctorsRepository : IDoctorsRepository
    {
        private readonly AppDbContext _appDbContext;
        public DoctorsRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Create(Doctor doctor)
        {
            _appDbContext.Doctors.Add(doctor);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Delete(Doctor doctor)
        {
            _appDbContext.Doctors.Remove(doctor);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Doctor>> GetAll() => await _appDbContext.Doctors.ToListAsync();

        public async Task<Doctor?> GetById(Guid id)
        {
            var doctor = await _appDbContext.Doctors.FirstOrDefaultAsync(d => d.Id == id);

            return doctor;
        }

        public async Task SaveChanges()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
