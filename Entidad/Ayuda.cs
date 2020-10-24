using System;
using System.ComponentModel.DataAnnotations;


namespace Entidad
{
    public class Ayuda
    {
        
        public Persona persona {get;set;}
        public string Departamento {get;set;}
        public string Ciudad {get;set;}
        public decimal Valor {get;set;}
        public string Modalidad {get;set;}
        public DateTime Fecha {get;set;}
    }
}