using MyDocAppointment.Business.Helpers;
using MyDocAppointment.Business.Interfaces;
using MyDocAppointment.Business.Logistics.External;

namespace MyDocAppointment.Application
{
    public class AppointmentsService : IAppointmentsService
    {
        private readonly IAppointmentsRepository _appointmentsRepository;
        public AppointmentsService(IAppointmentsRepository appointmentsRepository)
        {
            _appointmentsRepository = appointmentsRepository;
        }

        public async Task Create(Appointment appointment)
        {
            appointment.Id= Guid.NewGuid();
            appointment.Payment = new Payment();
            appointment.Payment.Id = Guid.NewGuid();
            appointment.Payment.DueDate = DateTime.Now;
            appointment.Payment.AcquittedDate = DateTime.Now;
            appointment.Payment.EmissionDate = DateTime.Now;

            await _appointmentsRepository.Create(appointment);
        }

        public async Task<Result> Delete(Guid id)
        {
            Appointment appointment = await _appointmentsRepository.GetById(id);
            if(appointment == null)
            {
                return Result.Failure($"appointment with id {id} not found.");
            }
            await _appointmentsRepository.Delete(appointment);
            return Result.Success();
        }

        public async Task<Result<IEnumerable<Appointment>>> GetAll()
        {
            var appointments = await _appointmentsRepository.GetAll();
            if (!appointments.Any())
            {
                return Result<IEnumerable<Appointment>>.Failure($"appointment not found.");
            }
            return Result<IEnumerable<Appointment>>.Success(appointments);
        }

        public async Task<Result<Appointment>> GetById(Guid id)
        {
            var appointment = await _appointmentsRepository.GetById(id);
            if(appointment == null)
            {
                return Result<Appointment>.Failure($"appointment with ID: {id} does not exist.");
            }
            return Result<Appointment>.Success(appointment);
        }

        public async Task SaveChanges()
        {
            await _appointmentsRepository.SaveChanges();
        }

        public async Task<Result<Appointment>> Update(Appointment appointment, Guid id)
        {
            var currentAppointment = await _appointmentsRepository.GetById(id);
            if (currentAppointment == null)
            {
                return Result<Appointment>.Failure($"appointment with ID: {id} does not exist.");

            }

            currentAppointment.Location = appointment.Location;
            currentAppointment.Specialization = appointment.Specialization;
            currentAppointment.AppointmentTime = appointment.AppointmentTime;

            await _appointmentsRepository.SaveChanges();

            return Result<Appointment>.Success(currentAppointment);
        }
    }
}