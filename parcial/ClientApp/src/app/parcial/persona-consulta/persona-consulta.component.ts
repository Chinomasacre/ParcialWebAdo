import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { PersonaService } from '../../services/persona.service';
import { Persona } from '../models/persona';

@Component({
  selector: 'app-persona-consulta',
  templateUrl: './persona-consulta.component.html',
  styleUrls: ['./persona-consulta.component.css']
})
export class PersonaConsultaComponent implements OnInit {

  personas:Persona[];
  searchText:string;
  valorTotal:number;

  constructor(private personaService:PersonaService) { }

  ngOnInit() {
    this.get();
  }
  get(){
    this.personaService.get().subscribe(result => {
      this.personas = result;
    });
  }
  sumarTotal(){
    this.valorTotal =0;
    
    this.personas.forEach(element => {
      this.valorTotal = this.valorTotal + element.ayuda.valor;
    });
  }
}
