using MyDocAppointment.Business.Helpers;
using MyDocAppointment.Business.Interfaces;
using MyDocAppointment.Business.Logistics.Internal;
using MyDocAppointment.Business.Users;

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
                return Result<IEnumerable<Drug>>.Failure($"drug not found.");
            }
            return Result<IEnumerable<Drug>>.Success(drugs);
        }

        public async Task<Result<Drug>> GetById(Guid id)
        {
            var drug = await _drugsRepository.GetById(id);
            if(drug == null)
            {
                return Result<Drug>.Failure($"drug with ID: {id} does not exist.");
            }
            return Result<Drug>.Success(drug);
        }

        public async Task SaveChanges()
        {
            await _drugsRepository.SaveChanges();
        }

        public async Task<Result<Drug>> Update(Drug updateDrug, Guid drugId)
        {
            var currentDrug = await _drugsRepository.GetById(drugId);
            if (currentDrug == null)
            {
                return Result<Drug>.Failure($"Drug with ID: {drugId} does not exist.");

            }

            currentDrug.Name = updateDrug.Name;
            currentDrug.Vendor = updateDrug.Vendor;
            currentDrug.Category = updateDrug.Category;
            currentDrug.Price = updateDrug.Price;

            await _drugsRepository.SaveChanges();

            return Result<Drug>.Success(currentDrug);
        }
    }
}
