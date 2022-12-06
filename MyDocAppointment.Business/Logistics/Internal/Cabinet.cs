namespace MyDocAppointment.Business.Logistics.Internal
{
    public class Cabinet
    {

        public Cabinet(List<DrugStock> stock)
        {
            Id = Guid.NewGuid();
            Inventory = stock;
            TotalAmmount = 0;
            Inventory.ForEach(i => {
                TotalAmmount += i.Quantity;
            });
        }
        public Guid Id;
        public List<DrugStock> Inventory;
        public int TotalAmmount;

        public void RemoveFromInventory(DrugStock drugStock){
            int index = Inventory.FindIndex(i => i.Id == drugStock.Id);
            if(index == -1){
                return;
            }
            TotalAmmount -= Inventory[index].Quantity;
            Inventory.RemoveAt(index);
        }

        public void RemoveFromInventory(Guid id){
            int index = Inventory.FindIndex(i => i.Id == id);
            if(index == -1){
                return;
            }
            TotalAmmount -= Inventory[index].Quantity;
            Inventory.RemoveAt(index);
        }

        public void AddStock(DrugStock drugStock){
            Inventory.Append(drugStock);
            TotalAmmount += drugStock.Quantity;
        }


    }
}