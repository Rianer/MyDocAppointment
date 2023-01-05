using MyDocAppointment.Business.Helpers;

namespace MyDocAppointment.Business.Logistics.External
{
    public class Payment
    {
        public Guid Id { get; set; }
        public double Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime EmissionDate { get; set; }
        public DateTime AcquittedDate { get; set; }
    }
}
