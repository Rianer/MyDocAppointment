using MyDocAppointment.Business.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocAppointment.Business.Users
{
    public class Person // facut clasa normala abstracta
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        public PersonGender Gender { get; set; }

        public string EmailAddress { get; set; }

 
    }
}
