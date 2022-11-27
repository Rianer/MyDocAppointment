using MyDocAppointment.Business.Helpers;
using MyDocAppointment.Business.Interfaces;
using MyDocAppointment.Business.Users;

namespace MyDocAppointment.Application
{
    public class PatientsService : IPatientsService
    {
        private readonly IPatientsRepository _patientsRepository;
        public PatientsService(IPatientsRepository patientsRepository)
        {
            _patientsRepository = patientsRepository;
        }

        public async Task Create(Patient patient)
        {
            await _patientsRepository.Create(patient);
        }

        public async Task<Result> Delete(Guid id)
        {
            var patient = await _patientsRepository.GetById(id);
            if (patient == null)
            {
                return Result.Failure($"Patient with ID: {id} does not exist.");
            }
            await _patientsRepository.Delete(patient);
            return Result.Success();
        }

        public async Task<Result<IEnumerable<Patient>>> GetAll()
        {
            var patients = await _patientsRepository.GetAll();
            if (!patients.Any())
            {
                return Result<IEnumerable<Patient>>.Failure($"Drugs not found.");
            }
            return Result<IEnumerable<Patient>>.Success(patients);
        }

        public async Task<Result<Patient>> GetById(Guid id)
        {
            var patient = await _patientsRepository.GetById(id);
            if(patient == null)
            {
                return Result<Patient>.Failure($"Patient with ID: {id} does not exist.");
            }
            return Result<Patient>.Success(patient);
        }

        public async Task SaveChanges()
        {
            await _patientsRepository.SaveChanges();
        }
    }
}
