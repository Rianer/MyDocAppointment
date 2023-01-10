using MediatR;
using MyDocAppointment.Application.Mappers;
using MyDocAppointment.Application.Response;
using MyDocAppointment.Business.Interfaces;

namespace MyDocAppointment.Application.Queries
{
    public class GetAllDrugEntrysQueryHandler : IRequestHandler<GetAllDrugEntrysQuery, List<DrugEntryResponse>>
    {
        private readonly IDrugEntrysRepository _repository;

        public GetAllDrugEntrysQueryHandler(IDrugEntrysRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<DrugEntryResponse>> Handle(GetAllDrugEntrysQuery request, CancellationToken cancellationToken)
        {
            var result = DrugEntryMapper.Mapper.Map<List<DrugEntryResponse>>
                (await _repository.GetAll());
            return result;
        }
    }
}
