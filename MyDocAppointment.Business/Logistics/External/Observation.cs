using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocAppointment.Business.Logistics.External
{
    public class Observation
    {

        public Guid Id { get; private set; }
        public DateTime Date { get; private set; }
        public string Description { get; private set; }

        public Observation(DateTime date, string description)
        {
            Id = new Guid();
            Date = date;
            Description = description;
        }
    }
}
