import { FormControl, FormGroup } from "@angular/forms";
import { ServiceForm } from "./serviceForm.model";

export class AppointmentForm{
    name: FormControl<string>;
    doctor: FormControl<string>;
    date: FormControl<string>;
    birthdate: FormControl<string>;
    service: FormGroup<ServiceForm>;
    paymentType: FormControl<string>;
    location: FormControl<string>;
}