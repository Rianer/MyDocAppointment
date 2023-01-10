using MyDocAppointment.Business.Helpers;
using MyDocAppointment.Business.Users;

namespace MyDocAppointment.Business.Logistics.External
{
    // To implement template diagnosis for easy medical use.
    public class Diagnosis
    {
        public Guid Id { get; set; }
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public DateTime DiagnosisDate { get; private set; }
        public List<Observation>? Observations { get; private set; } = new List<Observation>();
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
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                DiagnosisDate = timeResult
            };
            return Result<Diagnosis>.Success(diagnosis);

        }

        public Result AddObservation(string date, string description)
        {
            if(Observations == null)
            {
                return Result.Failure("Null list!");
            }

            Observation? entity = Observation.Create(date, description).Entity;
            if(entity == null)
            {
                return Result.Failure("Entity error!");
            }
            Observations.Add(entity);
            return Result.Success();
        }

        public Result DeleteObservation(int id)
        {
            if (Observations == null)
            {
                return Result.Failure("Null list!");
            }
            if ( Observations.Count > id)
            {
                 Observations.RemoveAt(id);
                return Result.Success();
            }
            return Result.Failure("Observation doesn't exist in diagnosis!");
        }

        public Result ModifyObservation(int id, string date, string description)
        {
            if (Observations == null)
            {
                return Result.Failure("Null list!");
            }


            if ( Observations.Count > id)
            {
                Observation? entity = Observation.Create(date, description).Entity;
                if(entity == null)
                {
                    return Result.Failure("ID not found!");
                }
                Observations[id] = entity;
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

        public Result Modify(string? name = null, string? description = null, string? diagnosisDate = null)
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
