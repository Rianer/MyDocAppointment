using MyDocAppointment.Business.Logistics.External;

namespace MyDocAppointment.API.Dtos
{
    public class CreateAppointmentDto
    {
        public string Location { get; set; }
        public string PatientID { get; set; }
        public string DoctorID { get; set; }
        public string Specialization { get; set; }
        public string AppointmentTime { get; set; }
        public CreatePaymentDto Payment { get; set; }
    }
}
