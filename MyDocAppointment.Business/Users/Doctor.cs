using MyDocAppointment.Business.Helpers;
using MyDocAppointment.Business.Logistics.External;

namespace MyDocAppointment.Business.Users
{
    public class Doctor : Person
    {

        public Specialization Speciality { get; set; }
        public List<Appointment> Appointments { get; set; }

        public Doctor() { }

        public Doctor(string name, string surname, int age, PersonGender gender, string emailAddress, Specialization specialization, List<Appointment> appointments)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
            EmailAddress = emailAddress;
            Speciality = specialization;
            Appointments = appointments;
        }
    }
}
