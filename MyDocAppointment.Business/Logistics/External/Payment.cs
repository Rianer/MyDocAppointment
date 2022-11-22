using MyDocAppointment.Business.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocAppointment.Business.Logistics.External
{
    public class Payment
    {
        public double Amount { get; private set; }
        public PaymentMethod PaymentMethod { get; private set; }
        public DateTime DueDate { get; private set; }
        public DateTime EmissionDate { get; private set; }
        public DateTime AcquittedDate { get; private set; }
        public bool IsAcquitted { get { return (AcquittedDate != new DateTime()); } }

        public static Result<Payment> Create(double amount, PaymentMethod paymentMethod, DateTime emissionDate, DateTime dueDate)
        {
            if(amount < 0)
            {
                return Result<Payment>.Failure($"Payment amount is negative: '{amount}'.");
            }

            if(dueDate < emissionDate)
            {
                return Result<Payment>.Failure($"Due date '{dueDate}' is before emission date '{emissionDate}'.");
            }

            var payment = new Payment()
            {
                Amount = amount,
                PaymentMethod = paymentMethod,
                EmissionDate = emissionDate,
                DueDate = dueDate
            };

            return Result<Payment>.Success(payment);
        }

        public Result ChangeDueDate(DateTime dateTime)
        {
            if (dateTime < this.EmissionDate)
            {
                return Result.Failure($"Can't set the due date '{dateTime}' before the emission date '{this.EmissionDate}'!");
            }
            this.DueDate = dateTime;
            return Result.Success();
        }

        public Result SetAcquittedDate(DateTime dateTime)
        {
            if (dateTime < this.EmissionDate)
            {
                return Result.Failure($"Can't set the acquitted date '{dateTime}' before the emission date '{this.EmissionDate}'!");
            }

            this.AcquittedDate = dateTime;
            return Result.Success();
        }

        public Result ChangeAmount(double amount)
        {
            if (amount < 0)
            {
                return Result.Failure($"Payment amount is negative: '{amount}'.");
            }

            this.Amount = amount;
            return Result.Success();
        }
    }
}
