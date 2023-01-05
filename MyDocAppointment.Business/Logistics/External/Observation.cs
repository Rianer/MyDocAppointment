using MyDocAppointment.Business.Helpers;

namespace MyDocAppointment.Business.Logistics.External
{
    public class Observation
    {

        public Guid Id { get; private set; }
        public DateTime Date { get; private set; }
        public string Description { get; private set; } = string.Empty;

        public static Result<Observation> Create(string date, string description)
        {
            DateTime timeResult;

            try
            {
                timeResult = DateTime.Parse(date);
            }
            catch (Exception ex)
            {
                return Result<Observation>.Failure($"Invalid time format: '{date}'.\n" + ex.Message);
            }

            Observation observation = new()
            {
                Id = Guid.NewGuid(),
                Date = timeResult,
                Description = description
            };
            return Result<Observation>.Success(observation);
        }
    }
}
