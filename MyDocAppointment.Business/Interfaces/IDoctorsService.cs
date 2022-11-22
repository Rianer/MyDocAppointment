using MyDocAppointment.Business.Helpers;
using MyDocAppointment.Business.Users;

namespace MyDocAppointment.Business.Interfaces
{
    public interface IDoctorsService
    {
        Task Create(Doctor doctor);
        Task Delete(Guid id);
        Task SaveChanges();
        Task<Result<IEnumerable<Doctor>>> GetAll();
        Task<Result<Doctor>> GetById(Guid id);
    }
}
