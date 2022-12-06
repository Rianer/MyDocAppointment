using MyDocAppointment.Business.Helpers;

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

        public static Result<Insurance> Create(string expirationDate)
        {
            DateTime timeResult;

            try
            {
                timeResult = DateTime.Parse(expirationDate);
            }
            catch (Exception ex)
            {
                return Result<Insurance>.Failure($"Invalid time format: '{expirationDate}'.\n" + ex.Message);
            }

            Insurance insurance = new()
            {
                ExpirationDate = timeResult,
                Discounts = new Dictionary<Specialization, Tuple<float, DiscountType>>()
            };
            return Result<Insurance>.Success(insurance);
        }

        ///// <summary>
        ///// If we eventually have predefined insurance packets.
        ///// </summary>
        ///// <param name="expirationDate"></param>
        ///// <param name="Discounts"></param>
        //public Insurance(string expirationDate, Dictionary<Specialization, Tuple<float, DiscountType>> discounts)
        //{
        //     ExpirationDate = expirationDate;
        //     Discounts = new Dictionary<Specialization, Tuple<float, DiscountType>>();
        //     Discounts = discounts;
        //}

        public Result AddDiscount(string specialization, float discount, string discountType)
        {
            DiscountType discountResult;
            Specialization specializationResult;

            if (!Enum.TryParse<Specialization>(specialization, out specializationResult))
            {
                return Result.Failure("Input specialization is invalid: " + specialization);
            }

            if (!Enum.TryParse<DiscountType>(discountType, out discountResult))
            {
                return Result.Failure("Input discount type is invalid: " + discountType);
            }

            Discounts.Add(specializationResult, new Tuple<float, DiscountType>(discount, discountResult));
            return Result.Success();
        }

        public Result RemoveDiscount(string specialization)
        {
            Specialization specializationResult;

            if (!Enum.TryParse<Specialization>(specialization, out specializationResult))
            {
                return Result.Failure("Input specialization is invalid: " + specialization);
            }

            if (Discounts.ContainsKey(specializationResult))
            {
                Discounts.Remove(specializationResult);
                return Result.Success();
            }
            return Result.Failure("Can't remove specialization because isn't included in the insurance.");
        }

        public Result ModifyDiscount(string specialization, float discount, string discountType)
        {
            DiscountType discountResult;
            Specialization specializationResult;

            if (!Enum.TryParse<Specialization>(specialization, out specializationResult))
            {
                return Result.Failure("Input specialization is invalid: " + specialization);
            }

            if (!Enum.TryParse<DiscountType>(discountType, out discountResult))
            {
                return Result.Failure("Input discount type is invalid: " + discountType);
            }

            if ( Discounts.ContainsKey(specializationResult))
            {
                 Discounts[specializationResult] = new Tuple<float, DiscountType>(discount, discountResult);
                return Result.Success();
            }
            return Result.Failure("Can't modify specialization because isn't included in the insurance.");
        }

        public Result RenewInsurance(string expirationDate)
        {
            DateTime timeResult;

            try
            {
                timeResult = DateTime.Parse(expirationDate);
            }
            catch (Exception ex)
            {
                return Result.Failure($"Invalid time format: '{expirationDate}'.\n" + ex.Message);
            }

            ExpirationDate = timeResult;
            return Result.Success();
        }
    }
}
