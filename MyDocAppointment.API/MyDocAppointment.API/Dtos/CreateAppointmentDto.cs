namespace MyDocAppointment.API.Dtos
{
    public class CreateAppointmentDto
    {
        public string Location { get; set; } = string.Empty;
        public string PatientID { get; set; } = string.Empty;
        public string DoctorID { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
        public string AppointmentTime { get; set; } = string.Empty;
        public CreatePaymentDto? Payment { get; set; }
    }
}
