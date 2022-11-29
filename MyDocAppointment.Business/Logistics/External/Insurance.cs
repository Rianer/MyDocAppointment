using MyDocAppointment.Business.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocAppointment.Business.Logistics.External
{
    // Not decided yet how to make proof of Insurance (in the case that it isn't directly bought from us).
    // Document upload
    public class Insurance
    {
        /// <summary>
        /// List of discounts. 
        /// Specialization : Discount, Percentage/Amount
        /// </summary>
        public Dictionary<Specialization, Tuple<float, DiscountType>> Discounts { get; private set; }
        /// <summary>
        /// Date up until insurance is available.
        /// </summary>
        public DateTime ExpirationDate { get; private set; }

        public Insurance(DateTime expirationDate)
        {
            this.ExpirationDate = expirationDate;
            this.Discounts = new Dictionary<Specialization, Tuple<float, DiscountType>>();
        }

        /// <summary>
        /// If we eventually have predefined insurance packets.
        /// </summary>
        /// <param name="expirationDate"></param>
        /// <param name="Discounts"></param>
        public Insurance(DateTime expirationDate, Dictionary<Specialization, Tuple<float, DiscountType>> discounts)
        {
            this.ExpirationDate = expirationDate;
            this.Discounts = new Dictionary<Specialization, Tuple<float, DiscountType>>();
            this.Discounts = discounts;
        }

        public Result AddDiscount(Specialization specialization, float discount, DiscountType discountType)
        {
            this.Discounts.Add(specialization, new Tuple<float, DiscountType>(discount, discountType));
            return Result.Success();
        }

        public Result RemoveDiscount(Specialization specialization)
        {
            if(this.Discounts.ContainsKey(specialization))
            {
                this.Discounts.Remove(specialization);
                return Result.Success();
            }
            return Result.Failure("Can't remove specialization because isn't included in the insurance.");
        }

        public Result ModifyDiscount(Specialization specialization, float discount, DiscountType discountType)
        {
            if (this.Discounts.ContainsKey(specialization))
            {
                this.Discounts[specialization] = new Tuple<float, DiscountType>(discount, discountType);
                return Result.Success();
            }
            return Result.Failure("Can't modify specialization because isn't included in the insurance.");
        }

        public Result RenewInsurance(DateTime expirationDate)
        {
            this.ExpirationDate = expirationDate;
            return Result.Success();
        }
    }
}
