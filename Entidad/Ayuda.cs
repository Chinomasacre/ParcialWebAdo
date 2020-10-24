using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entidad
{
    public class Ayuda
    {
        [Key]
        [Column(TypeName = "varchar(11)")]
        public string personaIdentificacion {get;set;}

        [Column(TypeName = "varchar(20)")]
        public string Departamento {get;set;}

        [Column(TypeName = "varchar(15)")]
        public string Ciudad {get;set;}

        [Column(TypeName = "decimal(11)")]
        public decimal Valor {get;set;}

        [Column(TypeName = "varchar(15)")]
        public string Modalidad {get;set;}

        [Column(TypeName = "Date")]
        public DateTime Fecha {get;set;}
    }
}