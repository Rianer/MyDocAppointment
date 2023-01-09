export class NewAppointment{
    id : string;
    status: string;
    doctorID: string;
    patientID: string;
    specialization: string;
    appointmentTime: string;
    payment: Payment;
}

export class Payment{
    "amount" : number;
    "paymentMethod" : string; 
}

export class Appointment{
    id : string;
    status: string;
    doctorID: string;
    doctorName: string;
    patientID: string;
    patientName: string;
    specialization: string;
    appointmentTime: string;
    paymentMethod: string;
    paymentDate: string;
    amount : number;
}