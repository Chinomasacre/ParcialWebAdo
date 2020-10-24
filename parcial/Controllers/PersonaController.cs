using System.Collections.Generic;
using System.Linq;
using Entidad;
using Logica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using parcial.Models;
using Datos;

namespace parcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PersonaController:ControllerBase
    {
        private readonly PersonaService _personaService;
        public PersonaController(ParcialContext context)
        {
         _personaService = new PersonaService(context);
        }
        // GET: api/Persona
        [HttpGet]
        public IEnumerable<PersonaViewModel> Gets()
        {
            var ayudas = _personaService.ConsultarTodosAyudas();
            var personas = _personaService.ConsultarTodos();

            var personass = personas.Select(p=>new PersonaViewModel(p,ayudas));

            return personass;
        }
        // POST: api/Persona
        [HttpPost]
        public ActionResult<PersonaViewModel> Post(PersonaInputModel personaInput)
        {
            Persona persona = MapearPersona(personaInput);
            Ayuda ayuda = MapearAyuda(personaInput);
            var response = _personaService.Guardar(persona,ayuda);
            if (response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Persona);
        }
        private Persona MapearPersona(PersonaInputModel personaInput)
        {
            var persona = new Persona
                {
                Identificacion = personaInput.Identificacion,
                Nombre = personaInput.Nombre,
                Edad = personaInput.Edad,
                Sexo = personaInput.Sexo
            };
            return persona;
        }
        private Ayuda MapearAyuda(PersonaInputModel personaInput)
        {
            var ayuda = new Ayuda
                {
                personaIdentificacion = personaInput.Identificacion,
                Departamento = personaInput.Departamento,
                Ciudad = personaInput.Ciudad,
                Valor = personaInput.Valor,
                Modalidad = personaInput.Modalidad,
                Fecha = personaInput.Fecha
            };
            return ayuda;
        }

    }
}