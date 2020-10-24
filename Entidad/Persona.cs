using System.Security.AccessControl;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entidad
{
    public class Persona
    
    {
        [Key]
        public string Identificacion {get;set;}
        
        public string Nombre {get;set;}

        public string Sexo {get;set;}
        
        public int Edad {get;set;}
        
    }
}
