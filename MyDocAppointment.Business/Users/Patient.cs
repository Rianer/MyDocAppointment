using FluentValidation;
using MyDocAppointment.Business.Helpers;
using MyDocAppointment.Business.Logistics.External;

namespace MyDocAppointment.Business.Users
{
    public class Patient : Person
    {
        public List<Appointment>? Appointments { get; private set; }
        public List<Diagnosis>? Diagnosis { get; private set; }

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
                Id = Guid.NewGuid(),
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

            if(Appointments == null)
            {
                return Result.Failure("List is null!");
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

            if (Diagnosis == null)
            {
                return Result.Failure("List is null!");
            }

            Diagnosis.Add(diagnosis);
            return Result.Success();
        }
    }

    public class PatientValidator : AbstractValidator<Patient>
    {
        public PatientValidator()
        {
            RuleFor(x => x.Name).Length(0, 30);
            RuleFor(x => x.Surname).Length(0, 30);
            RuleFor(x => x.EmailAddress).EmailAddress();
            RuleFor(x => x.Age).NotEmpty();
            RuleFor(x => x.PhoneNumber).Length(10);
            RuleFor(x => x.HomeAddress).Length(0, 50);
        }
    }
}
