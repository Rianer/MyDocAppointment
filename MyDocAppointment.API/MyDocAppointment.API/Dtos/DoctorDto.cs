namespace MyDocAppointment.API.Dtos
{
    public class DoctorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string HomeAddress { get; set; } = string.Empty;
        public string Speciality { get; set; } = string.Empty;
    }
}