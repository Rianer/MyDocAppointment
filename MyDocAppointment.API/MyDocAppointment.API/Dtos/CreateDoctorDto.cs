using MyDocAppointment.Business.Helpers;
using MyDocAppointment.Business.Logistics.External;

namespace MyDocAppointment.API.Dtos
{
    public class CreateDoctorDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        public PersonGender Gender { get; set; }

        public string EmailAddress { get; set; }
        public Specialization Speciality { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}