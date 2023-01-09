namespace MyDocAppointment.Application.Response
{
    public class DoctorResponse
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? HomeAddress { get; set; }
        public string? Speciality { get; set; }
    }
}
