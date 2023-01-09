using Microsoft.EntityFrameworkCore;
using MyDocAppointment.Business.Interfaces;
using MyDocAppointment.Business.Logistics.Internal;

namespace MyDocAppointment.Infrastructure.Repositories
{
    public class DrugsRepository : IDrugsRepository
    {
        private readonly AppDbContext _appDbContext;
        public DrugsRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Create(Drug drug)
        {
            _appDbContext.Drugs.Add(drug);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Delete(Drug drug)
        {
            _appDbContext.Drugs.Remove(drug);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Drug>> GetAll() => await _appDbContext.Drugs.ToListAsync();
       
        public async Task<Drug?> GetById(Guid id)
        {
            var drug = await _appDbContext.Drugs.FirstOrDefaultAsync(d => d.Id == id);

            return drug;
        }

        public async Task SaveChanges()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
