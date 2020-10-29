using System;
using System.Collections.Generic;
using Entidad;
namespace parcial.Models
{
   
    public class PersonaInputModel
    {
        public PersonaInputModel(){
            
        }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public Ayuda Ayuda { get; set; }
       
    }
    public class PersonaViewModel : PersonaInputModel
    {
        public PersonaViewModel()
        {
            Ayuda = new Ayuda();
        }
        public PersonaViewModel(Persona persona)
        {
            Identificacion = persona.Identificacion;
            Nombre = persona.Nombre;
            Edad = persona.Edad;
            Sexo = persona.Sexo;   
            Ayuda = persona.Ayuda; 
        }
    }
}