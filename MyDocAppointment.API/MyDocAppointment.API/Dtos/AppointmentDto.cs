﻿namespace MyDocAppointment.API.Dtos
{
    public class AppointmentDto
    {
        public string Id { get; set; }
        public string Location { get; set; }
        public string PatientID { get; set; }
        public string DoctorID { get; set; }
        public string Specialization { get; set; }
        public string AppointmentTime { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentDate { get; set; }
        public double Amount { get; set;}
    }
}
