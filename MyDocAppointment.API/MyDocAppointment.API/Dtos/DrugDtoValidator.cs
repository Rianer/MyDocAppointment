using FluentValidation;

namespace MyDocAppointment.API.Dtos
{
    public class DrugDtoValidator : AbstractValidator<DrugDto>
    {
        public DrugDtoValidator()
        {
            RuleFor(x => x.Name).Length(1, 30);
            RuleFor(x => x.Vendor).Length(1, 30);
            RuleFor(x => x.Price).NotEmpty();
            RuleFor(x => x.Description).Length(1, 20);
        }
    }
}
