using FluentValidation;

namespace MyDocAppointment.API.Dtos
{
    public class CreateDrugDtoValidator : AbstractValidator<CreateDrugDto>
    {
        public CreateDrugDtoValidator()
        {
            RuleFor(x => x.Name).Length(1, 30);
            RuleFor(x => x.Vendor).Length(1, 30);
            RuleFor(x => x.Price).NotEmpty();
            RuleFor(x => x.Category).Length(1, 20);
        }
    }
}
