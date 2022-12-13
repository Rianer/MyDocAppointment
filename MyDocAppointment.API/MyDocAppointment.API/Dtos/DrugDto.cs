namespace MyDocAppointment.API.Dtos
{
    public class DrugDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Vendor { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
