using MyDocAppointment.Business.Helpers;
using MyDocAppointment.Business.Users;

namespace MyDocAppointment.Business.Interfaces
{
    public interface IDoctorsRepository
    {
        Task Create(Doctor doctor);
        Task<Doctor> AddAsync(Doctor doctor);
        Task Delete(Doctor doctor);
        Task SaveChanges();
        Task<IEnumerable<Doctor>> GetAll();
        Task<Doctor?> GetById(Guid id);
        Task<IEnumerable<Doctor>> GetBySpectialization(Specialization specialization);
    }
}
