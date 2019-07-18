using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using DAL;



namespace BLL
{
    public class PersonaService
    {
        PersonaRepository personaRepositorio;
        

        public PersonaService()
        {
            personaRepositorio = new PersonaRepository();
        }
        public string Guardar(Persona persona)
        {
            try
            {
                if (personaRepositorio.Buscar(persona.Identificacion) == null)
                {
                    personaRepositorio.Guardar(persona);
                    return $"Los datos de {persona.Nombre} han sido guardados satisfatoriamente";
                }
                else
                {
                    return $"Lo sentimos, los datos de{persona.Nombre} ya se encuentran registrados";
                }
            }
            catch (Exception e)
            {
                return $"Error de la apliacion: {e.Message}";
            }
        }

        public string Eliminar(string identificacion)
        {
            Persona persona;
            try
            {
                persona = personaRepositorio.Buscar(identificacion);
                if (persona != null)
                {
                    personaRepositorio.Eliminar(persona);
                    return $"Los datos de {persona.Nombre} han sido eliminados satisfatoriamente";
                }
                else
                {
                    return $"Lo sentimos, los datos de{persona.Nombre} no se encuentran registrados";
                }
            }
            catch (Exception e)
            {
                return $"Error de la apliacion: {e.Message}";
            }
        }

        public string Modificar(string personaVieja, Persona personaNueva)
        {
            Persona persona;
            try
            {
                persona = personaRepositorio.Buscar(personaVieja);
                if (persona != null)
                {
                    personaRepositorio.Modificar(persona, personaNueva);
                    return $"Los datos de {persona.Nombre} han sido modificados satisfatoriamente";
                }
                else
                {
                    return $"Lo sentimos, los datos de{personaVieja} no se encuentran registrados";
                }
            }
            catch (Exception e)
            {
                return $"Error de la apliacion: {e.Message}";
            }
        }

        public List<Persona> Consultar()
        {
            return personaRepositorio.Consultar();
        }

        public Persona Buscar(string identificacion)
        {

            Persona persona = personaRepositorio.Buscar(identificacion);
            return persona;
        }

       

    }
}
