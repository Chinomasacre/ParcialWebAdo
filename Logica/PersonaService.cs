using System.Threading;
using System.Security.Permissions;
using System.Security.AccessControl;
using System;
using System.Collections.Generic;
using Datos;
using Entidad;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Logica
{
    public class PersonaService
    {
        private readonly ParcialContext _context;
        public PersonaService(ParcialContext context){
            _context = context;
        }

        public GuardarResponse Guardar(Persona persona)
        {
            try
            {
                var personaBuscada = _context.Personas.Find(persona.Identificacion);
                if(personaBuscada != null){
                    return new GuardarResponse("Error, ya registrarada");
                }
                _context.Personas.Add(persona);
                _context.SaveChanges();
                return new GuardarResponse(persona);
            }
            catch (Exception e)
            {
                return new GuardarResponse($"Error de la Aplicacion: {e.Message}");
            }
            finally { }
        }
        public List<Persona> ConsultarTodos()
        {
            List<Persona> personas = _context.Personas.Include(p => p.Ayuda).ToList();
            return personas;
        }
        
        public Persona BuscarxIdentificcion(string identificacion){
            return _context.Personas.Find(identificacion);
        }
    }
    public class GuardarResponse 
    {
        public GuardarResponse(Persona persona)
        {
            Error = false;
            Persona = persona;
        }
        public GuardarResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Persona Persona { get; set; }
    }
    
}
