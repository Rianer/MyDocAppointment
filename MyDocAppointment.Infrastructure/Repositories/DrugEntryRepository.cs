using Microsoft.EntityFrameworkCore;
using MyDocAppointment.Business.Interfaces;
using MyDocAppointment.Business.Logistics.Internal;

namespace MyDocAppointment.Infrastructure.Repositories
{
    public class DrugEntrysRepository : IDrugEntrysRepository
    {
        private readonly AppDbContext _appDbContext;
        public DrugEntrysRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<DrugEntry> GetDrug(Guid drugId)
        {
            var drug = await _appDbContext.DrugEntrys.FirstOrDefaultAsync(d => d.Id == drugId);
            return drug;
        }
        public async Task<DrugEntry> AddAsync(DrugEntry drugStock)
        {
            _appDbContext.DrugEntrys.Add(drugStock);
            await _appDbContext.SaveChangesAsync();
            return drugStock;
        }

        public async Task<IEnumerable<DrugEntry>> GetAll() => await _appDbContext.DrugEntrys.ToListAsync();

    }
}
