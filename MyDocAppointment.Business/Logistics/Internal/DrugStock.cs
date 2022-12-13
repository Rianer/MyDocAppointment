namespace MyDocAppointment.Business.Logistics.Internal
{
    // Only seen by doctors, contains a list of drugs and their count??
    public class DrugStock
    {
        public DrugStock(Drug item, int quantity, bool isRestricted)
        {
            Id = Guid.NewGuid();
            Item = item;
            Quantity = quantity;
            IsRestricted = isRestricted;
        }
        public Guid Id { get; set;}
        public Drug Item { get; set; }
        public int Quantity { get; set; }
        public bool IsRestricted { get; set; }

        public void SwitchRestriction(){
            IsRestricted = !IsRestricted;
        }

        public void ChangeDrug(Drug newDrug){
            Item = newDrug;
        }

        public void ReplenishInventory(int quantity){
            Quantity += quantity;
        }

        public bool TakeItems(int quantity){
            if(!IsRestricted && Quantity >= quantity){
                Quantity -= quantity;
                return true;
            }
            return false;
        }
    }
}
