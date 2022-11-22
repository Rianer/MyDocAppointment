using MyDocAppointment.Business.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocAppointment.Business.Logistics.External
{
    // To implement template diagnosis for easy medical use.
    public class Diagnosis
    {
        public Diagnosis(string name, string description, DateTime diagnosisDate)
        {
            this.Name = name;
            this.Description = description;
            this.DiagnosisDate = diagnosisDate;
            this.Observations = new List<Tuple<DateTime, string>>();
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime DiagnosisDate { get; private set; }
        /// <summary>
        /// Medic can add comments at every check.
        /// </summary>
        public List<Tuple<DateTime, string>> Observations { get; private set; }
        public Guid UserId { get; private set; }

        // Assign to user as well!!!
        public Result AssignToUser(Guid userId)
        {
            this.UserId = userId;
            return Result.Success();
        }

        public Result AddObservation(DateTime time, string observation)
        {
            this.Observations.Add(new Tuple<DateTime, string>(time, observation));
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

        public Result ModifyObservation(int id, DateTime time, string observation)
        {
            if (this.Observations.Count > id)
            {
                this.Observations[id] = new Tuple<DateTime, string>(time, observation);
                return Result.Success();
            }
            return Result.Failure("Observation doesn't exist in diagnosis!");
        }

        //public Result AssignToUser(Guid id)
        //{
        //    return Result.Fail("To do.");
        //}


    }
}
