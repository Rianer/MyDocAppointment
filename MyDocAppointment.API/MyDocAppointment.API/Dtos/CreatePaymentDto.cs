using MyDocAppointment.Business.Helpers;

namespace MyDocAppointment.API.Dtos
{
    public class CreatePaymentDto
    {
        public double Amount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
    }
}
