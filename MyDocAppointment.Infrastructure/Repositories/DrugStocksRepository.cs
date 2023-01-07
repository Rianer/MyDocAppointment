using Microsoft.EntityFrameworkCore;
using MyDocAppointment.Business.Interfaces;
using MyDocAppointment.Business.Logistics.Internal;

namespace MyDocAppointment.Infrastructure.Repositories
{
    public class DrugStocksRepository : IDrugStocksRepository
    {
        private readonly AppDbContext _appDbContext;
        public DrugStocksRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Drug> GetDrug(Guid drugId)
        {
            var drug = await _appDbContext.Drugs.FirstOrDefaultAsync(d => d.Id == drugId);
            return drug;
        }
        public async Task<DrugStock> AddAsync(DrugStock drugStock)
        {
            _appDbContext.DrugStocks.Add(drugStock);
            await _appDbContext.SaveChangesAsync();
            return drugStock;
        }

        public async Task<IEnumerable<DrugStock>> GetAll() => await _appDbContext.DrugStocks.Include(ds => ds.Item).ToListAsync();

    }
}
