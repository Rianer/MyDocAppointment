using MyDocAppointment.Business.Helpers;

namespace MyDocAppointment.Business.Logistics.External
{
    public class Payment
    {
        public Guid Id { get; private set; }
        public double Amount { get; private set; }
        public PaymentMethod PaymentMethod { get; private set; }
        public DateTime DueDate { get; private set; }
        public DateTime EmissionDate { get; private set; }
        public DateTime AcquittedDate { get; private set; }
        public bool IsAcquitted { get { return (AcquittedDate != DateTime.MinValue); } }

        public static Result<Payment> Create(double amount, string paymentMethod,
            string emissionDate, string dueDate)
        {
            DateTime dueDateResult;
            DateTime emissionDateResult;
            PaymentMethod paymentResult;

            try
            {
                dueDateResult = DateTime.Parse(dueDate);
                emissionDateResult = DateTime.Parse(emissionDate);
                if (dueDateResult < emissionDateResult)
                {
                    return Result<Payment>.Failure($"Due date '{dueDate}' is before emission date '{emissionDate}'.");
                }
            }
            catch (Exception ex)
            {
                return Result<Payment>.Failure($"Invalid time format: '{dueDate}/{emissionDate}'.\n" + ex.Message);
            }

            if (amount < 0)
            {
                return Result<Payment>.Failure($"Payment amount is negative: '{amount}'.");
            }

            if (!Enum.TryParse<PaymentMethod>(paymentMethod, out paymentResult))
            {
                return Result<Payment>.Failure("Input payment method is invalid: " + paymentMethod);
            }

            var payment = new Payment()
            {
                Id = new Guid(),
                Amount = amount,
                PaymentMethod = paymentResult,
                EmissionDate = emissionDateResult,
                DueDate = dueDateResult,
                AcquittedDate = DateTime.MinValue
            };

            return Result<Payment>.Success(payment);
        }

        public Result ChangeDueDate(string dateTime)
        {
            DateTime timeResult;

            try
            {
                timeResult = DateTime.Parse(dateTime);
                if (timeResult <  EmissionDate)
                {
                    return Result.Failure($"Can't set the due date '{dateTime}' before the emission date '{ EmissionDate}'!");
                }
            }
            catch (Exception ex)
            {
                return Result.Failure($"Invalid time format: '{dateTime}'.\n" + ex.Message);
            }

             DueDate = timeResult;
            return Result.Success();
        }

        public Result SetAcquittedDate(string dateTime)
        {
            DateTime timeResult;

            try
            {
                timeResult = DateTime.Parse(dateTime);
                if (timeResult <  EmissionDate)
                {
                    return Result.Failure($"Can't set the acquitted date '{dateTime}' before the emission date '{ EmissionDate}'!");
                }
            }
            catch (Exception ex)
            {
                return Result.Failure($"Invalid time format: '{dateTime}'.\n" + ex.Message);
            }

             AcquittedDate = timeResult;
            return Result.Success();
        }

        public Result ChangeAmount(double amount)
        {
            if (amount < 0)
            {
                return Result.Failure($"Payment amount is negative: '{amount}'.");
            }

             Amount = amount;
            return Result.Success();
        }
    }
}
