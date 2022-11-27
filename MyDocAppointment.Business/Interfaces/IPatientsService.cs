using MyDocAppointment.Business.Helpers;
using MyDocAppointment.Business.Users;

namespace MyDocAppointment.Business.Interfaces
{
    public interface IPatientsService
    {
        Task Create(Patient patient);
        Task<Result> Delete(Guid id);
        Task SaveChanges();
        Task<Result<IEnumerable<Patient>>> GetAll();
        Task<Result<Patient>> GetById(Guid id);
    }
}
