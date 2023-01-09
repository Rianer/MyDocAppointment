using FluentValidation;

namespace MyDocAppointment.API.Dtos
{
    public class PatientDtoValidator : AbstractValidator<PatientDto>
    {
        public PatientDtoValidator()
        {
            RuleFor(x => x.Name).Length(3, 30);
            RuleFor(x => x.Surname).Length(3, 30);
            RuleFor(x => x.EmailAddress).EmailAddress();
            RuleFor(x => x.Age).NotEmpty();
            RuleFor(x => x.PhoneNumber).Length(10);
            RuleFor(x => x.HomeAddress).Length(1, 50);
        }
    }
}
