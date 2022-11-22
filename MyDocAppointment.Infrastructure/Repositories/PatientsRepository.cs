using Microsoft.EntityFrameworkCore;
using MyDocAppointment.Business.Interfaces;
using MyDocAppointment.Business.Users;
namespace MyDocAppointment.Infrastructure.Repositories
{
    public class PatientsRepository : IPatientsRepository
    {
        private readonly AppDbContext _appDbContext;
        public PatientsRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Create(Patient pacient)
        {
            _appDbContext.Patients.Add(pacient);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Delete(Patient pacient)
        {
            _appDbContext.Patients.Remove(pacient);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Patient>> GetAll() => await _appDbContext.Patients.ToListAsync();

        public async Task<Patient> GetById(Guid id)
        {
            var pacient = await _appDbContext.Patients.FirstOrDefaultAsync(d => d.Id == id);

            return pacient;
        }

        public async Task SaveChanges()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
