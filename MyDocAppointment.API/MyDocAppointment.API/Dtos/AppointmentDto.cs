namespace MyDocAppointment.API.Dtos
{
    public class AppointmentDto
    {
        public string Id { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string PatientID { get; set; } = string.Empty;
        public string DoctorID { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
        public string AppointmentTime { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;
        public string PaymentDate { get; set; } = string.Empty;
        public double Amount { get; set;}
    }
}
