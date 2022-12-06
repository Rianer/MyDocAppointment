using MyDocAppointment.Business.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocAppointment.Business.Users
{
    public abstract class Person
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Surname { get; protected set; }
        public int Age { get; protected set; }
        public PersonGender Gender { get; protected set; }
        public string EmailAddress { get; protected set; }
        public string PhoneNumber { get; protected set; }
        public string HomeAddress { get; protected set; }
    }
}
