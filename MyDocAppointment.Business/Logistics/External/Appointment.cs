using MyDocAppointment.Business.Helpers;
using MyDocAppointment.Business.Users;

namespace MyDocAppointment.Business.Logistics.External
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public Payment Payment { get; set; }
        public string Location { get; set; }
        public Guid PatientID { get; set; }
        public Guid DoctorID { get; set; }
        public Specialization Specialization { get; set; }
        public DateTime AppointmentTime { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
