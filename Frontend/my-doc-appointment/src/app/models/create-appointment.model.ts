import { Payment } from "./payment.model";

export class CreateAppointment{
    location: string;
    doctorId: string;
    patientId: string;
    appointmentTime: string;
    specialization: string;
    payment: Payment;
    constructor(){
        this.location = '';
        this.doctorId = '';
        this.patientId = '';
        this.appointmentTime = '';
        this.specialization = '';
        this.payment = new Payment();
    }
}