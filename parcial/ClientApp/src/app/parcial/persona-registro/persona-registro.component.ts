import { Component, OnInit } from '@angular/core';
import { PersonaService } from './../../services/persona.service';
import { Persona } from './../models/persona';
import { Ayuda } from './../models/ayuda';
import { FormGroup, FormBuilder, Validators, AbstractControl} from '@angular/forms'
import { getLocaleDateTimeFormat } from '@angular/common';

@Component({
  selector: 'app-persona-registro',
  templateUrl: './persona-registro.component.html',
  styleUrls: ['./persona-registro.component.css']
})
export class PersonaRegistroComponent implements OnInit {
  formGroup: FormGroup;
  persona: Persona;
  ayuda: Ayuda;
  constructor(private personaService: PersonaService,private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.persona = new Persona();
    this.ayuda = new Ayuda();
    this.buildForm();
  }
  private buildForm(){
    this.persona.identificacion = '';
    this.persona.nombre = '';
    this.persona.edad = 0;
    this.persona.sexo = '';
    this.ayuda.departamento = '';
    this.ayuda.ciudad = '';
    this.ayuda.valor = 0;
    this.ayuda.modalidad = '';
    this.ayuda.fecha = new Date(Date.now());
    this.formGroup = this.formBuilder.group({
      identificacion: [this.persona.identificacion, Validators.required],
      nombre: [this.persona.nombre, Validators.required],
      edad: [this.persona.edad, [Validators.required, Validators.min(1)]],
      sexo: [this.persona.sexo, [Validators.required,  this.validaSexo]],
      departamento: [this.ayuda.departamento, [Validators.required, Validators.min(1)]],
      ciudad: [this.ayuda.ciudad, [Validators.required, Validators.min(1)]],
      valor: [this.ayuda.valor, [Validators.required, Validators.min(1)]],
      modalidad: [this.ayuda.modalidad, [Validators.required, Validators.min(1)]],
      fecha: [this.ayuda.fecha, [Validators.required, Validators.min(1)]]
    });
   
  }
  

  private validaSexo(control: AbstractControl) {
     const sexo = control.value;
     if(sexo.toLocaleUpperCase() !== 'M' && sexo.toLocaleUpperCase() !== 'F') {
      return {validSexo:true,messageSexo:'Sexo No Valido'};
     }
      return null;
  }
  get control() { 
    return this.formGroup.controls;
     }
  onSubmit() {
    if (this.formGroup.invalid) {
      return;
    }
    this.add();
  }
      
  add(){
    this.persona = this.formGroup.value;

    this.ayuda.departamento = this.formGroup.value.departamento;
    this.ayuda.ciudad = this.formGroup.value.ciudad;
    this.ayuda.valor = this.formGroup.value.valor;
    this.ayuda.modalidad = this.formGroup.value.modalidad;
    this.ayuda.fecha = this.formGroup.value.fecha;

    this.persona.ayuda = this.ayuda;

    this.personaService.post(this.persona).subscribe(p => {
      if (p != null) {
        alert('persona creada');
        this.persona = p;
      }
    });
  }
}
