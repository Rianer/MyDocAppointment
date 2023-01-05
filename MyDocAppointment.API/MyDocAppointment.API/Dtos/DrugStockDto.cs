namespace MyDocAppointment.API.Dtos
{
    public class DrugStockDto
    {
        public string DrugName { get; set; } = string.Empty;
        public Guid DrugId { get; set; }
        public int Quantity { get; set; }
        public bool IsRestricted { get; set; }
    }
}
