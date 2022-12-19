using FluentValidation;
using MyDocAppointment.Business.Helpers;
using MyDocAppointment.Business.Logistics.Internal;
using MyDocAppointment.Business.Users;

namespace MyDocAppointment.Business.Logistics.External
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public Payment? Payment { get; set; }
        public string Location { get; set; } = string.Empty;
        public Guid PatientID { get; set; }
        public Guid DoctorID { get; set; }
        public Specialization Specialization { get; set; }
        public DateTime AppointmentTime { get; set; }
        public virtual Doctor? Doctor { get; set; }
        public virtual Patient? Patient { get; set; }
    }

    public class AppointmentValidator : AbstractValidator<Appointment>
    {
        public AppointmentValidator()
        {
            RuleFor(x => x.Location).Length(0, 30);
            RuleFor(x => x.PatientID).NotEmpty();
            RuleFor(x => x.DoctorID).NotEmpty();
            RuleFor(x => x.Payment.Id).NotEmpty();
            RuleFor(x => x.Specialization).NotEmpty();
            RuleFor(x => x.AppointmentTime).NotEmpty();
        }
    }
}
