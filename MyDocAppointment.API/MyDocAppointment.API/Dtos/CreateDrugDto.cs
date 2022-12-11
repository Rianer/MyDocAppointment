namespace MyDocAppointment.API.Dtos
{
    public class CreateDrugDto
    {
        public string Name { private set; get; }
        public string Vendor { private set; get; }
        public string Category { private set; get; }
        public decimal Price { private set; get; }
    }
}
