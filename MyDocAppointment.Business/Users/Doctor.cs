using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDocAppointment.Business.Helpers;
using MyDocAppointment.Business.Logistics.External;

namespace MyDocAppointment.Business.Users
{
    public class Doctor : Person
    {

        public Specialization Speciality { get; set; }
        public List<Appointment> Appointments { get; set; }

        public Doctor(string name, string surname, int age, PersonGender gender, 
            string email, Specialization specialization, List<Appointment> appointments)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
            this.Gender = gender;
            this.EmailAddress = email;
            this.Speciality = specialization;
            this.Appointments = appointments;
        }
    }
}
