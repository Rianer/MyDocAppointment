namespace MyDocAppointment.API.Dtos
{
    public class DrugDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Vendor { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}
