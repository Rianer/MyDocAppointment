export class NewDrug{
    name: string;
    vendor: string;
    category: string;
    price: number;
    
    isComplete(): boolean{
        if(this.name === null || this.name === undefined || this.name === ''){
            return false;
        }
        if(this.vendor === null || this.vendor === undefined || this.vendor === ''){
            return false;
        }
        if(this.category === null || this.category === undefined || this.category === ''){
            return false;
        }
        if(this.price === null || this.price === undefined || this.price === 0){
            return false;
        }
        return true;
    }
}

export class Drug{
    id: string;
    name: string;
    vendor: string;
    category: string;
    price: number;

    constructor(drug?: Drug){       
        if(drug === undefined || drug === null){
            this.id = '';
            this.name = '';
            this.vendor = '';
            this.category = '';
            this.price = 0;
            return;
        } 
        if(this.id === null || this.id === undefined || this.id === ''){
            this.id = drug.id;
        }
        if(this.name === null || this.name === undefined || this.name === ''){
            this.name = drug.name;
        }
        if(this.vendor === null || this.vendor === undefined || this.vendor === ''){
            this.vendor = drug.vendor;
        }
        if(this.category === null || this.category === undefined || this.category === ''){
            this.category = drug.category;
        }
        if(this.price === null || this.price === undefined || this.price === 0){
            this.price = drug.price;
        }
    }
}