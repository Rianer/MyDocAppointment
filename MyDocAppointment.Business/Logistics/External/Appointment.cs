using MyDocAppointment.Business.Helpers;
using MyDocAppointment.Business.Users;

namespace MyDocAppointment.Business.Logistics.External
{
    public class Appointment
    {
        public Guid Id { get; private set; }
        public Payment Payment { get; private set; }
        public string Location { get; private set; }
        public Guid PatientID { get; private set; }
        public Guid DoctorID { get; private set; }
        public Specialization Specialization { get; private set; }
        public DateTime AppointmentTime { get; private set; }
        public virtual Doctor Doctor { get; private set; }
        public virtual Patient Patient { get; private set; }

        public static Result<Appointment> Create(string specialization, 
            string timeOfAppointment, string location)
        {
            Specialization specializationResult;
            DateTime timeResult;

            if (!Enum.TryParse<Specialization>(specialization, out specializationResult))
            {
                return Result<Appointment>.Failure("Input specialization is invalid: " + specializationResult);
            }

            try
            {
                timeResult = DateTime.Parse(timeOfAppointment);
                if (timeResult < DateTime.Now)
                {
                    return Result<Appointment>.Failure($"Can't set appointment in the past: '{timeResult}'.");
                }
            }
            catch(Exception ex)
            {
                return Result<Appointment>.Failure($"Invalid time format: '{timeOfAppointment}'.\n" + ex.Message);
            }

            Appointment appointment = new()
            {
                Id = Guid.NewGuid(),
                Specialization = specializationResult,
                AppointmentTime = timeResult,
                Location = location
            };
            return Result<Appointment>.Success(appointment);
        }

        public Result ChangeAppointmentTime(string dateTime)
        {
            DateTime timeResult;

            try
            {
                timeResult = DateTime.Parse(dateTime);
                if (timeResult < DateTime.Now)
                {
                    return Result.Failure($"Can't set appointment in the past: '{timeResult}'.");
                }
            }
            catch (Exception ex)
            {
                return Result.Failure($"Invalid time format: '{dateTime}'.\n" + ex.Message);
            }

            AppointmentTime = timeResult;
            return Result.Success();
        }

        public Result AssignPatient(Patient patient)
        {
            if(patient == null)
            {
                return Result.Failure("Input not null patient!");
            }

            Patient = patient;
            PatientID = patient.Id;
            patient.AddAppointment(this);
            return Result.Success();
        }

        public Result AssignDoctor(Doctor doctor)
        {
            Doctor = doctor;
            DoctorID = doctor.Id;
            doctor.AddAppointment(this);
            return Result.Success();
        }

        public Result ChangeLocation(string location)
        {
            Location = location;
            return Result.Success();
        }

        public Result AssignPayment(Payment payment)
        {
            if(payment == null)
            {
                return Result.Failure("Input not null payment!");
            }
            
            Payment = payment;
            return Result.Success();
        }
    }
}
