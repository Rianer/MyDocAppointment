export class Doctor{
    age: string;
    appointments: any;
    emailAddress: string;
    gender: string;
    homeAddress: string;
    id: string;
    name: string;
    phoneNumber: string;
    speciality: string;
    surname: string;


    constructor(doctor? : Doctor, update? : UpdatedDoctor, newDoctor? : NewDoctor){

        this.age = null;
        this.appointments = null;
        this.emailAddress = null;
        this.gender = null;
        this.homeAddress = null;
        this.id = null;
        this.name = null;
        this.phoneNumber = null;
        this.speciality = null;
        this.surname = null;

        if(newDoctor !== undefined){
            this.age = newDoctor.age;
            this.emailAddress = newDoctor.emailAddress;
            this.gender = newDoctor.gender;
            this.homeAddress = newDoctor.homeAddress;
            this.name = newDoctor.name;
            this.phoneNumber = newDoctor.phoneNumber;
            this.speciality = newDoctor.speciality;
            this.surname = newDoctor.surname;
            return;
        }

        if(doctor !== undefined){
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
        if(update !== undefined){
            if(checkProperty(update.emailAddress))
                this.emailAddress = update.emailAddress;
            if(checkProperty(update.homeAddress))
                this.homeAddress = update.homeAddress;
            if(checkProperty(update.name))
                this.name = update.name;
            if(checkProperty(update.phoneNumber))
                this.phoneNumber = update.phoneNumber;
            if(checkProperty(update.speciality))
                this.speciality = update.speciality;
            if(checkProperty(update.surname))
                this.surname = update.surname;
            return;
        }
        
    }
}

export class UpdatedDoctor{
    emailAddress: string;
    homeAddress: string;
    name: string;
    phoneNumber: string;
    speciality: string;
    surname: string;
    gender : string;

    constructor(doctor? : Doctor){
        this.emailAddress = null;
        this.homeAddress = null;
        this.name = null;
        this.phoneNumber = null;
        this.speciality = null;
        this.surname = null;
        this.gender = null;

        if(doctor !== undefined){
            this.emailAddress = doctor.emailAddress;
            this.homeAddress = doctor.homeAddress;
            this.name = doctor.name;
            this.phoneNumber = doctor.phoneNumber;
            this.speciality = doctor.speciality;
            this.surname = doctor.surname;
        }
    }

    completeInfo(doctor : Doctor){
        if(!checkProperty(this.emailAddress))
            this.emailAddress = doctor.emailAddress;
        if(!checkProperty(this.homeAddress))
            this.homeAddress = doctor.homeAddress;
        if(!checkProperty(this.name))
            this.name = doctor.name;
        if(!checkProperty(this.phoneNumber))
            this.phoneNumber = doctor.phoneNumber;
        if(!checkProperty(this.speciality))
            this.speciality = doctor.speciality;
        if(!checkProperty(this.surname))
            this.surname = doctor.surname;
        if(!checkProperty(this.gender))
            this.gender = doctor.gender;
    }
}

export class NewDoctor{
    age: string;
    emailAddress: string;
    gender: string;
    homeAddress: string;
    name: string;
    phoneNumber: string;
    speciality: string;
    surname: string;

    constructor(){
        this.age = null;
        this.emailAddress = null;
        this.gender = null;
        this.homeAddress = null;
        this.name = null;
        this.phoneNumber = null;
        this.speciality = null;
        this.surname = null;
    }

    isComplete(){
        let complete : boolean = true;
        Object.entries(this).forEach(([key, value]) => {
            if(value === null || value === '') complete = false;
        });
        return complete;
    }
}

function checkProperty(value : string){
    if(value === null || value === '' || value === undefined){
        return false;
    }
    return true;
}