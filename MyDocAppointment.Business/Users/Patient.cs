using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDocAppointment.Business.Helpers;
using MyDocAppointment.Business.Logistics.External;

namespace MyDocAppointment.Business.Users
{
    public class Patient : Person
    {
        public List<Appointment> FutureAppointments { get; set; }
        public List<Appointment> PastAppointments { get; set; } // Medical history
        public List<Diagnosis> Diagnosis { get; set; }


        public Patient(string name, string surname, int age, PersonGender gender, string email, List<Appointment> futureAppointments, 
        List<Appointment> pastAppointments, List<Diagnosis> diagnosis)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
            this.Gender = gender;
            this.EmailAddress = email;
            this.FutureAppointments = futureAppointments;
            this.PastAppointments = pastAppointments;
            this.Diagnosis = diagnosis;
        }

    }
}
