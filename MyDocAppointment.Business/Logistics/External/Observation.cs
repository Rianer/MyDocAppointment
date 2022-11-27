using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocAppointment.Business.Logistics.External
{
    public class Observation
    {
        public Observation(DateTime date, string description)
        {
            Id = new Guid();
            Date = date;
            Description = description;
        }

        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
