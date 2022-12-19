using FluentValidation;
using MyDocAppointment.Business.Users;

namespace MyDocAppointment.Business.Logistics.Internal
{
    public class Drug
    {
        public Guid Id { get; set;}
        public string Name { get; set; } = string.Empty;
        public string Vendor { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set;}
        public virtual List<DrugStock> DrugStocks { get; set; }

        public void ChangePrice(decimal newPrice){
            Price = newPrice;
        }

        public void ChangeCategory(string newCategory){
            Category = newCategory;
        }
    }

    public class DrugValidator : AbstractValidator<Drug>
    {
        public DrugValidator()
        {
            RuleFor(x => x.Name).Length(0, 30);
            RuleFor(x => x.Vendor).Length(0, 30);
            RuleFor(x => x.Price).NotEmpty();
            RuleFor(x => x.Category).Length(0, 20);
        }
    }
}
