using System;
using Entidad;
namespace parcial.Models
{
    public class PersonaModel
    {
        
    }
    public class PersonaInputModel
    {
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public string Departamento { get; set; }
        public string Ciudad { get; set; }
        public decimal Valor { get; set; }
        public string Modalidad { get; set; }
        public DateTime Fecha { get; set; }
    }
    public class PersonaViewModel : PersonaInputModel
    {
        public PersonaViewModel()
        {

        }
        public PersonaViewModel(Persona persona)
        {
            Identificacion = persona.Identificacion;
            Nombre = persona.Nombre;
            Edad = persona.Edad;
            Sexo = persona.Sexo;
        }
    }
}