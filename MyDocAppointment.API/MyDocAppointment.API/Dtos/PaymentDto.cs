namespace MyDocAppointment.API.Dtos
{
    public class PaymentDto
    {
        public Guid Id { get; set; }
        public double Amount { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime EmissionDate { get; set; }
        public DateTime AcquittedDate { get; set; }
    }
}
