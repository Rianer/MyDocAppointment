using MyDocAppointment.Business.Helpers;
using MyDocAppointment.Business.Logistics.Internal;
using MyDocAppointment.Business.Users;

namespace MyDocAppointment.Business.Interfaces
{
    public interface IDrugsService
    {
        Task Create(Drug drug);
        Task<Result> Delete(Guid id);
        Task SaveChanges();
        Task<Result<IEnumerable<Drug>>> GetAll();
        Task<Result<Drug>> GetById(Guid id);
        Task<Result<Drug>> Update(Drug drug, Guid drugId);

    }
}
