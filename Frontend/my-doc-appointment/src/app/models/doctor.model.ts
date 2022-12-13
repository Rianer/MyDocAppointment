export class Doctor{
    age: string;
    appointments: any;
    emailAddress: string;
    gender: number;
    homeAddress: string;
    id: string;
    name: string;
    phoneNumber: string;
    speciality: number;
    surname: string;


    constructor(doctor : Doctor){
        this.age = doctor.age;
        this.appointments = doctor.appointments;
        this.emailAddress = doctor.emailAddress;
        this.gender = doctor.gender;
        this.homeAddress = doctor.homeAddress;
        this.id = doctor.id;
        this.name = doctor.name;
        this.phoneNumber = doctor.phoneNumber;
        this.speciality = doctor.speciality;
        this.surname = doctor.surname;
    }
}