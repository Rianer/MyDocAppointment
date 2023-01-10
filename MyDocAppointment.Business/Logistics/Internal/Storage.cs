using MyDocAppointment.Business.Helpers;

namespace MyDocAppointment.Business.Logistics.Internal
{
    public class Storage
    {
        public Guid Id { get; set; }
        public List<DrugEntry>? Inventory { get; private set; }

        public static Result<Storage> Create()
        {
            Storage storage = new Storage()
            {
                Id = Guid.NewGuid(),
                Inventory = new List<DrugEntry>()
            };

            return Result<Storage>.Success(storage);
        }

        public Result RemoveEntry(Guid drugId){
            if(Inventory == null)
            {
                return Result.Failure("Null list!");
            }

            int index = Inventory.FindIndex(i => i.Drug.Id == drugId);
            if(index == -1){
                return Result.Failure("Drug not found in storage!");
            }

            Inventory.RemoveAt(index);
            return Result.Success();
        }

        public Result AddEntry(Drug drug, int quantity, DateTime expirationDate)
        {
            if (Inventory == null)
            {
                return Result.Failure("Null list!");
            }
            var result = DrugEntry.Create(drug, quantity, expirationDate);

            if(result.Entity == null)
            {
                return Result.Failure(result.Error);
            }

            Inventory.Add(result.Entity);
            return Result.Success();
        }
    }
}