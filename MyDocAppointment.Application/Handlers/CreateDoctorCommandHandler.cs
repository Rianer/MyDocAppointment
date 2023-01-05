using AutoMapper;
using MediatR;
using MyDocAppointment.Application.Commands;
using MyDocAppointment.Application.Mappers;
using MyDocAppointment.Application.Response;
using MyDocAppointment.Business.Interfaces;
using MyDocAppointment.Business.Users;

namespace MyDocAppointment.API.Handlers
{
    public class CreateDoctorCommandHandler :
        IRequestHandler<CreateDoctorCommand,
            DoctorResponse>
    {
        private readonly IDoctorsRepository repository;

        public CreateDoctorCommandHandler(IDoctorsRepository repository)
        {
            this.repository = repository;
        }
        public async Task<DoctorResponse>
            Handle(CreateDoctorCommand request,
            CancellationToken cancellationToken)
        {
            var doctorEntity = DoctorMapper.Mapper.Map<Doctor>(request);
            if (doctorEntity == null)
            {
                throw new ApplicationException("Issue with the mapper");
            }
            var newDoctor = await repository.AddAsync(doctorEntity);
            return DoctorMapper.Mapper.Map<DoctorResponse>(newDoctor);
        }
    }
}
