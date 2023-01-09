using MyDocAppointment.Business.Helpers;

namespace MyDocAppointment.Business.Logistics.Internal
{
    public class Drug
    {
        public Guid Id { get; set;}
        public string Name { get; set; } = string.Empty;
        public string Vendor { get; set; } = string.Empty;
        public decimal Price { get; set;}
        public string Description { get; set; } = string.Empty;

        public static Result<Drug> Create(string name, string vendor, decimal price, string description)
        {
            if(price < 0)
            {
                return Result<Drug>.Failure("Invalid drug price!");
            }

            Drug drug = new Drug
            {
                Id = Guid.NewGuid(),
                Name = name,
                Vendor = vendor,
                Price = price,
                Description = description
            };

            return Result<Drug>.Success(drug);
        }

        public Result ChangePrice(decimal newPrice){
            if(newPrice < 0)
            {
                return Result.Failure("Please input a valid price!");
            }

            Price = newPrice;
            return Result.Success();
        }
    }
}
