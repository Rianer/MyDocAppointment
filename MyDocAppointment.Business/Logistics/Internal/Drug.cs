using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Guid Id {private set; get;}
        public string Name {private set; get;}
        public string Vendor {private set; get;}
        
        public string Category {private set; get;}
        public decimal Price {private set; get;}

        public void ChangePrice(decimal newPrice){
            Price = newPrice;
        }

        

        public void ChangeCategory(string newCategory){
            Category = newCategory;
        }
    }
}
