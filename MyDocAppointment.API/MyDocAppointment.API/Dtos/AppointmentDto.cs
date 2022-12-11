namespace MyDocAppointment.API.Dtos
{
    public class AppointmentDto
    {
        public string Location { get; private set; }
        public string PatientID { get; private set; }
        public string DoctorID { get; private set; }
        public string Specialization { get; private set; }
        public string AppointmentTime { get; private set; }
    }
}
