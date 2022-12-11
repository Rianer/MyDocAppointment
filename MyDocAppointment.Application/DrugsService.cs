using MyDocAppointment.Business.Helpers;
using MyDocAppointment.Business.Interfaces;
using MyDocAppointment.Business.Logistics.Internal;

namespace MyDocAppointment.Application
{
    public class DrugsService : IDrugsService
    {
        private readonly IDrugsRepository _drugsRepository;
        public DrugsService(IDrugsRepository drugsRepository)
        {
            _drugsRepository = drugsRepository;
        }

        public async Task Create(Drug drug)
        {
            await _drugsRepository.Create(drug);
        }

        public async Task<Result> Delete(Guid id)
        {
            var drug = await _drugsRepository.GetById(id);
            if(drug == null)
            {
                return Result.Failure($"drug with id {id} not found.");
            }
            await _drugsRepository.Delete(drug);
            return Result.Success();
        }

        public async Task<Result<IEnumerable<Drug>>> GetAll()
        {
            var drugs = await _drugsRepository.GetAll();
            if (!drugs.Any())
            {
                return Result<IEnumerable<drug>>.Failure($"drug not found.");
            }
            return Result<IEnumerable<drug>>.Success(drugs);
        }

        public async Task<Result<Drug>> GetById(Guid id)
        {
            var drug = await _drugsRepository.GetById(id);
            if(drug == null)
            {
                return Result<drug>.Failure($"drug with ID: {id} does not exist.");
            }
            return Result<drug>.Success(drug);
        }

        public async Task SaveChanges()
        {
            await _drugsRepository.SaveChanges();
        }
    }
}
