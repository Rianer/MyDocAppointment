using MyDocAppointment.Business.Helpers;
using MyDocAppointment.Business.Logistics.External;

namespace MyDocAppointment.Business.Users
{
    public class Doctor : Person
    {
        public Specialization Speciality { get; private set; }
        public List<Appointment> Appointments { get; private set; }

        //public Doctor() { }

        public static Result<Doctor> Create(string name, string surname, int age, string gender,
            string emailAddress, string phoneNumber, string homeAddress, string specialization)
        {
            PersonGender genderResult;
            Specialization specializationResult;

            if (!Enum.TryParse<PersonGender>(gender, out genderResult))
            {
                return Result<Doctor>.Failure("Input gender is invalid: " + gender);
            }

            if (!Enum.TryParse<Specialization>(specialization, out specializationResult))
            {
                return Result<Doctor>.Failure("Input specialization is invalid: " + specialization);
            }

            Doctor doctor = new()
            {
                Id = new Guid(),
                Name = name,
                Surname = surname,
                Age = age,
                Gender = genderResult,
                EmailAddress = emailAddress,
                PhoneNumber = phoneNumber,
                HomeAddress = homeAddress,
                Speciality = specializationResult,
                Appointments = new List<Appointment>()
            };
            return Result<Doctor>.Success(doctor);
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
    }
}
