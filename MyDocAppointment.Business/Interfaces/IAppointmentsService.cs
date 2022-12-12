using MyDocAppointment.Business.Helpers;
using MyDocAppointment.Business.Logistics.External;
using MyDocAppointment.Business.Users;

namespace MyDocAppointment.Business.Interfaces
{
    public interface IAppointmentsService
    {
        Task Create(Appointment appointment);
        Task<Result> Delete(Guid id);
        Task SaveChanges();
        Task<Result<IEnumerable<Appointment>>> GetAll();
        Task<Result<Appointment>> GetById(Guid id);
        Task<Result<Appointment>> Update(Appointment appointment, Guid id);
    }
}
