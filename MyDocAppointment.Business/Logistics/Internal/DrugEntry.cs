using MyDocAppointment.Business.Helpers;

namespace MyDocAppointment.Business.Logistics.Internal
{
    public class DrugEntry
    {
        public Guid Id { get; private set; }
        public Drug Drug { get; private set;}
        public int Quantity { get; private set; }
        public DateTime ExpirationDate { get; private set; }

        public static Result<DrugEntry> Create(Drug drug, int quantity, DateTime expirationDate)
        {
            if(quantity < 0)
            {
                return Result<DrugEntry>.Failure("Drug entry quantity invalid!");
            }

            DrugEntry drugEntry = new DrugEntry()
            {
                Id = Guid.NewGuid(),
                Drug = drug,
                Quantity = quantity,
                ExpirationDate = expirationDate
            };

            return Result<DrugEntry>.Success(drugEntry);
        }

        public Result IncreaseQuantity(int quantity)
        {
            if (quantity < 0)
            {
                return Result.Failure("Input valid quantity!");
            }

            Quantity += quantity;
            return Result.Success();
        }

        public Result DecreaseQuantity(int quantity)
        {
            if (quantity < 0)
            {
                return Result.Failure("Please input valid quantity");
            }

            if (Quantity < quantity)
            {
                return Result.Failure("Insufficent available stock");
            }

            Quantity -= quantity;

            return Result.Success();
        }
    }
}
