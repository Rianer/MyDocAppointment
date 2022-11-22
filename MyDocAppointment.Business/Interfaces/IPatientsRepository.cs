using MyDocAppointment.Business.Users;

namespace MyDocAppointment.Business.Interfaces
{
    public interface IPatientsRepository
    {
        Task Create(Patient patient);
        Task Delete(Patient patient);
        Task SaveChanges();
        Task<IEnumerable<Patient>> GetAll();
        Task<Patient> GetById(Guid id);
    }
}
