using MediatR;
using MyDocAppointment.Application.Response;

namespace MyDocAppointment.Application.Queries
{
    public class GetAllDrugEntrysQuery : IRequest<List<DrugEntryResponse>>
    {
    }
}
