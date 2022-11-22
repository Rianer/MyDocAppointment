using MyDocAppointment.Business.Helpers;
using MyDocAppointment.Business.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocAppointment.Business.Logistics.External
{
    public class Appointment
    {
        public static Result<Appointment> Create(Specialization specialization, DateTime timeOfAppointment, Payment payment, string location, int patientID, int doctorID)
        {
            // validate DoctorID and ClientID
            if (timeOfAppointment < DateTime.Now)
            {
                return Result<Appointment>.Failure($"Can't set appointment in the past: '{timeOfAppointment}'.");
            }

            var appointment = new Appointment()
            {
                Specialization = specialization,
                AppointmentTime = timeOfAppointment,
                Location = location,
                PatientID = patientID,
                DoctorID = doctorID,
                Payment = payment
            };

            return Result<Appointment>.Success(appointment);
        }

        public Guid Id { get; set; }
        public Payment Payment { get; private set; }
        public string Location { get; private set; }
        public int PatientID { get; private set; }
        public int DoctorID { get; private set; }
        public Specialization Specialization { get; private set; }
        public DateTime AppointmentTime { get; private set; }

        public virtual Doctor Doctor { get; set; }
        public Patient Patient { get; set; }

        public Result ChangeAppointmentTime(DateTime dateTime)
        {
            if (dateTime < DateTime.Now)
            {
                return Result.Failure($"Can't set appointment in the past: '{dateTime}'.");
            }

            this.AppointmentTime = dateTime;
            return Result.Success();
        }

        public Result AssignToPatient()
        {
            return Result.Failure("To do.");
        }

        public Result AssignToDoctor()
        {
            return Result.Failure("To do.");
        }

        public Result ChangeLocation(string location)
        {
            this.Location = location;
            return Result.Success();
        }
    }
}
