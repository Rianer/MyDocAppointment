using FluentValidation;

namespace MyDocAppointment.API.Dtos
{
    public class CreateAppointmentDtoValidator: AbstractValidator<CreateAppointmentDto>
    {
        public CreateAppointmentDtoValidator()
        {
            RuleFor(x => x.Location).Length(1, 30);
            RuleFor(x => x.PatientID).NotEmpty();
            RuleFor(x => x.DoctorID).NotEmpty();
            RuleFor(x => x.Specialization).NotEmpty();
            RuleFor(x => x.AppointmentTime).NotEmpty();
        }
    }
}
