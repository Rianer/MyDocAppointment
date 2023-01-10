using MyDocAppointment.Business.Logistics.Internal;

namespace MyDocAppointment.Business.Interfaces
{
    public interface IDrugEntrysRepository
    {
        Task<DrugEntry> AddAsync(DrugEntry drugStock);
        Task<IEnumerable<DrugEntry>> GetAll();
        Task<DrugEntry>? GetDrug(Guid drugId);
    }
}
