namespace MyDocAppointment.API.Dtos
{
    public class DrugEntryDto
    {
        public string DrugName { get; set; } = string.Empty;
        public Guid DrugId { get; set; }
        public int Quantity { get; set; }
        public string ExpirationDate { get; set; } = string.Empty;
    }
}
