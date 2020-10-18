using System.Collections.Generic;
using System.Linq;
using Entidad;
using Logica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using parcial.Models;

namespace parcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PersonaController:ControllerBase
    {
        private readonly PersonaService _personaService;
        public IConfiguration Configuration { get; }
        public PersonaController(IConfiguration configuration)
        {
        Configuration = configuration;
        string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
        _personaService = new PersonaService(connectionString);
        }
        // GET: api/Persona
        [HttpGet]
        public IEnumerable<PersonaViewModel> Gets()
        {
            var personas = _personaService.ConsultarTodos().Select(p=> new PersonaViewModel(p));
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
            var persona = new Persona
                {
                Identificacion = personaInput.Identificacion,
                Nombre = personaInput.Nombre,
                Edad = personaInput.Edad,
                Sexo = personaInput.Sexo,
                Departamento = personaInput.Departamento,
                Ciudad = personaInput.Ciudad,
                Valor = personaInput.Valor,
                Modalidad = personaInput.Modalidad,
                Fecha = personaInput.Fecha
            };
            return persona;
        }

    }
}