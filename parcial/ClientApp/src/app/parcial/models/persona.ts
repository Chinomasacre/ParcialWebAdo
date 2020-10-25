import { Ayuda } from './ayuda';

export class Persona {
    constructor(){
        this.ayuda = new Ayuda();
    }

    identificacion: string;
    nombre: string;
    sexo: string;
    edad: number;
    ayuda: Ayuda;
}
