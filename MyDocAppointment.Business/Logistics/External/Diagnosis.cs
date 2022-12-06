using MyDocAppointment.Business.Helpers;
using MyDocAppointment.Business.Users;

namespace MyDocAppointment.Business.Logistics.External
{
    // To implement template diagnosis for easy medical use.
    public class Diagnosis
    {
        public Guid Id { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime DiagnosisDate { get; private set; }
        public List<Observation> Observations { get; private set; }
        public Guid PatientId { get; private set; }

        public static Result<Diagnosis> Create(string name, string description, string diagnosisDate)
        {
            DateTime timeResult;

            try
            {
                timeResult = DateTime.Parse(diagnosisDate);
            }
            catch(Exception ex)
            {
                return Result<Diagnosis>.Failure($"Invalid time format: '{diagnosisDate}'.\n" + ex.Message);
            }

            Diagnosis diagnosis = new()
            {
                Id = new Guid(),
                Name = name,
                Description = description,
                DiagnosisDate = timeResult,
                Observations= new List<Observation>()
            };
            return Result<Diagnosis>.Success(diagnosis);

        }

        public Result AddObservation(string date, string description)
        {
            Observations.Add(Observation.Create(date, description).Entity);
            return Result.Success();
        }

        public Result DeleteObservation(int id)
        {
            if(this.Observations.Count > id)
            {
                this.Observations.RemoveAt(id);
                return Result.Success();
            }
            return Result.Failure("Observation doesn't exist in diagnosis!");
        }

        public Result ModifyObservation(int id, string date, string description)
        {
            if (this.Observations.Count > id)
            {
                this.Observations[id] = Observation.Create(date, description).Entity;
                return Result.Success();
            }
            return Result.Failure("Observation doesn't exist in diagnosis!");
        }

        public Result AssignToPatient(Patient patient)
        {
            if(patient == null)
            {
                return Result.Failure("Input not null patient!");
            }

            PatientId = patient.Id;
            patient.AddDiagnosis(this);
            return Result.Success();
        }

        public Result Modify(string name = null, string description = null, string diagnosisDate = null)
        {
            if(name != null)
            {
                Name = name;
            }

            if(description != null)
            {
                Description = description;
            }

            if(diagnosisDate != null)
            {
                DateTime timeResult;

                try
                {
                    timeResult = DateTime.Parse(diagnosisDate);
                }
                catch (Exception ex)
                {
                    return Result.Failure($"Invalid time format: '{diagnosisDate}'.\n" + ex.Message);
                }
            }

            return Result.Success();
        }
    }
}
