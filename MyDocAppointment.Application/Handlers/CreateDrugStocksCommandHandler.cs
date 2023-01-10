using MediatR;
using MyDocAppointment.Application.Commands;
using MyDocAppointment.Application.Mappers;
using MyDocAppointment.Application.Response;
using MyDocAppointment.Business.Interfaces;
using MyDocAppointment.Business.Logistics.Internal;

namespace MyDocAppointment.API.Handlers
{
    public class CreateDrugEntrysCommandHandler :
        IRequestHandler<CreateDrugEntryCommand,
            DrugEntryResponse>
    {
        private readonly IDrugEntrysRepository _repository;

        public CreateDrugEntrysCommandHandler(IDrugEntrysRepository repository)
        {
            _repository = repository;
        }
        public async Task<DrugEntryResponse>
            Handle(CreateDrugEntryCommand request,
            CancellationToken cancellationToken)
        {
            var drugStockEntity = DrugEntryMapper.Mapper.Map<DrugEntry>(request);
            if (drugStockEntity == null)
            {
                throw new ApplicationException("Issue with the mapper");
            }
            DrugEntry drugItem = await _repository.GetDrug(drugStockEntity.Drug.Id);
            drugStockEntity = drugItem;

            var newDrugEntry = await _repository.AddAsync(drugStockEntity);
            return DrugEntryMapper.Mapper.Map<DrugEntryResponse>(newDrugEntry);
        }
    }
}
