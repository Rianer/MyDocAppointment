import { FormControl } from "@angular/forms";

export class ServiceForm{
    name: FormControl<string>;
    price: FormControl<number>;
    constructor(){
        this.name = new FormControl('');
        this.price = new FormControl(0);
    }
}
