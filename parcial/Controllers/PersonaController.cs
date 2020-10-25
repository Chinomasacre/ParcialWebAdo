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
            var personas = _personaService.ConsultarTodos().Select(p=>new PersonaViewModel(p));
            return personas;
        }
        
        
        // POST: api/Persona
        [HttpPost]
        public ActionResult<PersonaViewModel> Post(PersonaInputModel personaInput)
        {
            Persona persona = MapearPersona(personaInput);
            var response = _personaService.Guardar(persona);
            if (response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Persona);
        }
        
        private Persona MapearPersona(PersonaInputModel personaInput)
        {
            var persona = new Persona();
                persona.Identificacion = personaInput.Identificacion;
                persona.Nombre = personaInput.Nombre;
                persona.Edad = personaInput.Edad;
                persona.Sexo = personaInput.Sexo;
                persona.Ayuda.Departamento = personaInput.Ayuda.Departamento;
                persona.Ayuda.Ciudad= personaInput.Ayuda.Ciudad;
                persona.Ayuda.Valor = personaInput.Ayuda.Valor;
                persona.Ayuda.Modalidad = personaInput.Ayuda.Modalidad;
                persona.Ayuda.Fecha = personaInput.Ayuda.Fecha.Date;
            return persona;
        }
        

    }
}