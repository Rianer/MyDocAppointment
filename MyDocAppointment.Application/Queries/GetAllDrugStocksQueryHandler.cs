using MediatR;
using MyDocAppointment.Application.Mappers;
using MyDocAppointment.Application.Response;
using MyDocAppointment.Business.Interfaces;

namespace MyDocAppointment.Application.Queries
{
    public class GetAllDrugStocksQueryHandler : IRequestHandler<GetAllDrugStocksQuery, List<DrugStockResponse>>
    {
        private readonly IDrugStocksRepository _repository;

        public GetAllDrugStocksQueryHandler(IDrugStocksRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<DrugStockResponse>> Handle(GetAllDrugStocksQuery request, CancellationToken cancellationToken)
        {
            var result = DrugStockMapper.Mapper.Map<List<DrugStockResponse>>
                (await _repository.GetAll());
            return result;
        }
    }
}
