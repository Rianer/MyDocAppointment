using MyDocAppointment.Business.Helpers;
using MyDocAppointment.Business.Logistics.External;

namespace MyDocAppointment.Business.Users
{
    public class Patient : Person
    {
        public List<Appointment> Appointments { get; private set; }
        public List<Diagnosis> Diagnosis { get; private set; }
        public Insurance Insurance { get; private set; }

        //public Patient() { }

        public static Result<Patient> Create(string name, string surname, int age, string gender,
            string emailAddress, string phoneNumber, string homeAddress)
        {
            PersonGender genderResult;

            if (!Enum.TryParse<PersonGender>(gender, out genderResult))
            {
                return Result<Patient>.Failure("Input gender is invalid: " + gender);
            }

            Patient patient = new()
            {
                Id = new Guid(),
                Name = name,
                Surname = surname,
                Age = age,
                Gender = genderResult,
                EmailAddress = emailAddress,
                PhoneNumber = phoneNumber,
                HomeAddress = homeAddress,
                Appointments = new List<Appointment>(),
                Diagnosis = new List<Diagnosis>()
            };
            return Result<Patient>.Success(patient);
        }

        public Result AddAppointment(Appointment appointment)
        {
            if (appointment == null)
            {
                return Result.Failure("Input not null appointment!");
            }
            
            Appointments.Add(appointment);
            return Result.Success();
        }

        public Result AddDiagnosis(Diagnosis diagnosis)
        {
            if (diagnosis == null)
            {
                return Result.Failure("Input not null diagnosis!");
            }
            
            Diagnosis.Add(diagnosis);
            return Result.Success();
        }

        public Result AssignInsurance(Insurance insurance)
        {
            if (insurance == null)
            {
                return Result.Failure("Input not null insurance!");
            }
            
            Insurance = insurance;
            return Result.Success();
        }
    }
}
