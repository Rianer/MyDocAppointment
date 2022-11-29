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

        public Guid Id { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime DiagnosisDate { get; private set; }
        /// <summary>
        /// Medic can add comments at every check.
        /// </summary>
        public List<Observation> Observations { get; private set; }
        public Guid UserId { get; private set; }

        public Diagnosis(string name, string description, DateTime diagnosisDate)
        {
            Id = new Guid();
            Name = name;
            Description = description;
            DiagnosisDate = diagnosisDate;
        }

        // Assign to user as well!!!
        public Result AssignToUser(Guid userId)
        {
            this.UserId = userId;
            return Result.Success();
        }

        public Result AddObservation(DateTime date, string description)
        {
            this.Observations.Add(new Observation(date, description));
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

        public Result ModifyObservation(int id, DateTime date, string description)
        {
            if (this.Observations.Count > id)
            {
                this.Observations[id] = new Observation(date, description);
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
