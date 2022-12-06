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
        public Guid Id {private set; get;}
        public Drug Item {private set; get;}
        public int Quantity {private set; get;}
        public bool IsRestricted {private set; get;}

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
            if(!IsRestricted & Quantity >= quantity){
                Quantity -= quantity;
                return true;
            }
            return false;
        }
    }
}
