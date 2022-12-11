namespace MyDocAppointment.Business.Logistics.Internal
{
    public class Drug
    {
        public Drug(string name, string vendor, string category, decimal price)
        {
            Id = Guid.NewGuid();
            Name = name;
            Vendor = vendor;
            Category = category;
            Price = price;
        }

        public Guid Id { get; set;}
        public string Name { get; set;}
        public string Vendor { get; set;}
        
        public string Category { get; set;}
        public decimal Price { get; set;}

        public void ChangePrice(decimal newPrice){
            Price = newPrice;
        }

        public void ChangeCategory(string newCategory){
            Category = newCategory;
        }
    }
}
