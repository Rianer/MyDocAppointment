using MediatR;
using MyDocAppointment.Application.Response;

namespace MyDocAppointment.Application.Queries
{
    public class GetAllDoctorsQuery : IRequest<List<DoctorResponse>>
    {
    }
}
