using FluentValidation;

namespace MyDocAppointment.Application.Commands
{
    public class CreateDoctorCommandValidator : AbstractValidator<CreateDoctorCommand>
    {
        public CreateDoctorCommandValidator()
        {
            RuleFor(x => x.Name).Length(0, 30);
            RuleFor(x => x.Surname).Length(0, 30);
            RuleFor(x => x.EmailAddress).EmailAddress();
            RuleFor(x => x.Age).InclusiveBetween(18, 80);
            RuleFor(x => x.PhoneNumber).Length(10);
            RuleFor(x => x.HomeAddress).Length(0, 50);
            RuleFor(x => x.Speciality).NotNull();
        }
    }
}
