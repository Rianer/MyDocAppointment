using MediatR;
using MyDocAppointment.Application.Response;

namespace MyDocAppointment.Application.Queries
{
    public class GetAllDrugStocksQuery : IRequest<List<DrugStockResponse>>
    {
    }
}
