using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocAppointment.Business.Logistics.Internal
{
    public class Storage
    {
        public Storage(List<Cabinet> cabinets)
        {
            Id = Guid.NewGuid();
            Cabinets = cabinets;
        }
        public Guid Id { private set; get; }
        public List<Cabinet> Cabinets { private set; get; }

        public void AddCabinet(Cabinet cabinet){
            Cabinets.Append(cabinet);
        } 

        public void RemoveCabinet(Cabinet cabinet){
            Cabinets.RemoveAll(c => c.Id == cabinet.Id);
        }

        public void RemoveCabinet(Guid id){
            Cabinets.RemoveAll(c => c.Id == id);
        }

    }
}