using MediatR;
using MyDocAppointment.Application.Response;

namespace MyDocAppointment.Application.Commands
{
    public class CreateDoctorCommand : IRequest<DoctorResponse>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string HomeAddress { get; set; }
        public string Speciality { get; set; }
    }
}
