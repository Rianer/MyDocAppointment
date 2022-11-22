using MyDocAppointment.Business.Logistics.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocAppointment.Business.Interfaces
{
    public interface IDrugsRepository
    {
        Task Create(Drug drug);
        Task Delete(Drug drug);
        Task SaveChanges();
        Task<IEnumerable<Drug>> GetAll();
        Task<Drug> GetById(Guid id);
    }
}
