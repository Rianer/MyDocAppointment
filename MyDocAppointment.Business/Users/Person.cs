using MyDocAppointment.Business.Helpers;

namespace MyDocAppointment.Business.Users
{
    public abstract class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public int Age { get; set; }
        public PersonGender Gender { get; set; }
        public string EmailAddress { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string HomeAddress { get; set; } = string.Empty;
    }
}
