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
        private Guid id;
        private List<DrugStock> inventory;
        private int totalAmmount;

        public Guid Id { get => id; set => id = value; }
        public List<DrugStock> Inventory { get => inventory; set => inventory = value; }
        public int TotalAmmount { get => totalAmmount; set => totalAmmount = value; }

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
            Inventory.Add(drugStock);
            TotalAmmount += drugStock.Quantity;
        }


    }
}