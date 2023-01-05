using MyDocAppointment.Business.Logistics.Internal;

namespace MyDocAppointment.Business.Interfaces
{
    public interface IDrugsRepository
    {
        Task Create(Drug drug);
        Task Delete(Drug drug);
        Task SaveChanges();
        Task<IEnumerable<Drug>> GetAll();
        Task<Drug> GetById(Guid id);
    }
}
