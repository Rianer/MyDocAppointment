namespace MyDocAppointment.Business.Logistics.Internal
{
    public class Drug
    {
        public Guid Id { get; set;}
        public string Name { get; set; } = string.Empty;
        public string Vendor { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set;}

        public void ChangePrice(decimal newPrice){
            Price = newPrice;
        }

        public void ChangeCategory(string newCategory){
            Category = newCategory;
        }
    }
}
