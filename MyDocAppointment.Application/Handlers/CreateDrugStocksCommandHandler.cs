using AutoMapper;
using MediatR;
using MyDocAppointment.Application.Commands;
using MyDocAppointment.Application.Mappers;
using MyDocAppointment.Application.Response;
using MyDocAppointment.Business.Interfaces;
using MyDocAppointment.Business.Logistics.Internal;
using MyDocAppointment.Business.Users;

namespace MyDocAppointment.API.Handlers
{
    public class CreateDrugStocksCommandHandler :
        IRequestHandler<CreateDrugStockCommand,
            DrugStockResponse>
    {
        private readonly IDrugStocksRepository _repository;

        public CreateDrugStocksCommandHandler(IDrugStocksRepository repository)
        {
            _repository = repository;
        }
        public async Task<DrugStockResponse>
            Handle(CreateDrugStockCommand request,
            CancellationToken cancellationToken)
        {
            var drugStockEntity = DrugStockMapper.Mapper.Map<DrugStock>(request);
            if (drugStockEntity == null)
            {
                throw new ApplicationException("Issue with the mapper");
            }
            var drugItem = await _repository.GetDrug(drugStockEntity.Item.Id);
            drugStockEntity.Item= drugItem;

            var newDrugStock = await _repository.AddAsync(drugStockEntity);
            return DrugStockMapper.Mapper.Map<DrugStockResponse>(newDrugStock);
        }
    }
}
