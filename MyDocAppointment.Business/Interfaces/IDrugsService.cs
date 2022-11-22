using MyDocAppointment.Business.Helpers;
using MyDocAppointment.Business.Logistics.Internal;

namespace MyDocAppointment.Business.Interfaces
{
    public interface IDrugsService
    {
        Task Create(Drug drug);
        Task Delete(Drug drug);
        Task SaveChanges();
        Task<Result<IEnumerable<Drug>>> GetAll();
        Task<Result<Drug>> GetById(Guid id);
    }
}
