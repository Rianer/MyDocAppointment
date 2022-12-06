﻿using MyDocAppointment.Business.Helpers;

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
