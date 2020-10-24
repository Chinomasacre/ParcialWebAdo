using System.Security.AccessControl;
using System;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;
namespace Entidad
{
    public class Persona
    
    {
        [Key]
        [Column(TypeName = "varchar(11)")]
        public string Identificacion {get;set;}
        
        
        [Column(TypeName = "varchar(20)")]
        public string Nombre {get;set;}


        [Column(TypeName = "varchar(11)")]
        public string Sexo {get;set;}
        
    
        public int Edad {get;set;}
        
    }
}
