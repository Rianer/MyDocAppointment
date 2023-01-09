using MediatR;
using MyDocAppointment.Application.Mappers;
using MyDocAppointment.Application.Response;
using MyDocAppointment.Business.Interfaces;

namespace MyDocAppointment.Application.Queries
{
    public class GetAllDoctorsQueryHandler : IRequestHandler<GetAllDoctorsQuery, List<DoctorResponse>>
    {
        private readonly IDoctorsRepository _repository;

        public GetAllDoctorsQueryHandler(IDoctorsRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<DoctorResponse>> Handle(GetAllDoctorsQuery request, CancellationToken cancellationToken)
        {
            var result = DoctorMapper.Mapper.Map<List<DoctorResponse>>
                (await _repository.GetAll());
            return result;
        }
    }
}
