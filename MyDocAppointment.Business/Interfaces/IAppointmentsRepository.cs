using MyDocAppointment.Business.Logistics.External;

namespace MyDocAppointment.Business.Interfaces
{
    public interface IAppointmentsRepository
    {
        Task Create(Appointment appointment);
        Task Delete(Appointment appointment);
        Task SaveChanges();
        Task<IEnumerable<Appointment>> GetAll();
        Task<Appointment> GetById(Guid id);
    }
}
