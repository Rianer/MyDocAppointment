using MediatR;
using MyDocAppointment.Application.Response;

namespace MyDocAppointment.Application.Commands
{
    public class CreateDrugEntryCommand : IRequest<DrugEntryResponse>
    {
        public Guid DrugId { get; set; }
        public string? DrugName { get; set; }
        public int Quantity { get; set; }
        public bool IsRestricted { get; set; }
    }
}
