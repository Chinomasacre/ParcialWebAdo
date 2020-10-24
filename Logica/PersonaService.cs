using System.Threading;
using System.Security.Permissions;
using System.Security.AccessControl;
using System;
using System.Collections.Generic;
using Datos;
using Entidad;
using System.Linq;

namespace Logica
{
    public class PersonaService
    {
        private readonly ParcialContext _context;
        public PersonaService(ParcialContext context){
            _context = context;
        }

        public GuardarPersonaResponse Guardar(Persona persona,Ayuda ayuda)
        {
            try
            {
                var personaBuscada = _context.Personas.Find(persona.Identificacion);
                if(personaBuscada != null){
                    return new GuardarPersonaResponse("Error, ya registrarada");
                }
                _context.Personas.Add(persona);
                _context.Ayudas.Add(ayuda);
                _context.SaveChanges();
                return new GuardarPersonaResponse(persona);
            }
            catch (Exception e)
            {
                return new GuardarPersonaResponse($"Error de la Aplicacion: {e.Message}");
            }
            finally { }
        }
        public List<Persona> ConsultarTodos()
        {
            List<Persona> personas = _context.Personas.ToList();

            return personas;
        }
        public List<Ayuda> ConsultarTodosAyudas(){
            List<Ayuda> ayudas = _context.Ayudas.ToList();
            return ayudas;
        }
        public Persona BuscarxIdentificcion(string identificacion){
            return _context.Personas.Find(identificacion);
        }
    }
    public class GuardarPersonaResponse 
    {
        public GuardarPersonaResponse(Persona persona)
        {
            Error = false;
            Persona = persona;
        }
        public GuardarPersonaResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Persona Persona { get; set; }
    }
    
}
