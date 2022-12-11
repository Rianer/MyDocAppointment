namespace MyDocAppointment.API.Dtos
{
    public class DrugStockDto
    {
        public string DrugName { private set; get; }
        public Guid DrugId { private set; get; }
        public int Quantity { private set; get; }
        public bool IsRestricted { private set; get; }
    }
}
