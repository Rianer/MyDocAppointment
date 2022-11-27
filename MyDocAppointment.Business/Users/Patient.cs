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
        public List<Appointment> Appointments { get; set; }
        public List<Diagnosis> Diagnosis { get; set; }

        public Patient() { }

        public Patient(string name, string surname, int age, PersonGender gender, string email, 
        List<Appointment> appointments, List<Diagnosis> diagnosis)
        {
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
            this.Gender = gender;
            this.EmailAddress = email;
            this.Appointments = appointments;
            this.Diagnosis = diagnosis;
        }

    }
}
