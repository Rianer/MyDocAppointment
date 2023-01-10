namespace MyDocAppointment.Application.Response
{
    public class DrugEntryResponse
    {
        public string? DrugName { get; set; }
        public Guid DrugId { get; set; }
        public int Quantity { get; set; }
        public string? ExpirationDate { get; set; }
    }
}
