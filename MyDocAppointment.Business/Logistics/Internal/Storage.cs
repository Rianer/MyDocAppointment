using MyDocAppointment.Business.Helpers;

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

        public Result AddCabinet(Cabinet cabinet){
            Cabinets.Add(cabinet);
            return Result.Success();
        } 

        public void RemoveCabinet(Cabinet cabinet){
            Cabinets.RemoveAll(c => c.Id == cabinet.Id);
        }

        public void RemoveCabinet(Guid id){
            Cabinets.RemoveAll(c => c.Id == id);
        }

    }
}