using MyDocAppointment.Business.Helpers;
using MyDocAppointment.Business.Logistics.External;

namespace MyDocAppointment.API.Dtos
{
    public class CreatePatientDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        public PersonGender PersonGender { get; set; }

        public string EmailAddress { get; set; }
        public List<Appointment> FutureAppointments { get; set; }
        public List<Appointment> PastAppointments { get; set; } // Medical history
        public List<Diagnosis> Diagnosis { get; set; }
    }
}