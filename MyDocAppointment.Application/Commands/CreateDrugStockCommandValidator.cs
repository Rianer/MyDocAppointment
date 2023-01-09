using FluentValidation;

namespace MyDocAppointment.Application.Commands
{
    public class CreateDrugEntryCommandValidator : AbstractValidator<CreateDrugEntryCommand>
    {
        public CreateDrugEntryCommandValidator()
        {
            RuleFor(x => x.DrugId).NotNull();
            RuleFor(x => x.DrugName).Length(0, 30);
            RuleFor(x => x.Quantity).InclusiveBetween(1, 100);
            RuleFor(x => x.IsRestricted).NotNull();
        }
    }
}
