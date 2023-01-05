using FluentValidation;
using MyDocAppointment.Business.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocAppointment.Application.Commands
{
    public class CreateDrugStockCommandValidator : AbstractValidator<CreateDrugStockCommand>
    {
        public CreateDrugStockCommandValidator()
        {
            RuleFor(x => x.DrugId).NotNull();
            RuleFor(x => x.DrugName).Length(0, 30);
            RuleFor(x => x.Quantity).InclusiveBetween(1, 100);
            RuleFor(x => x.IsRestricted).NotNull();
        }
    }
}
