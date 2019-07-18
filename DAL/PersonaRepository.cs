using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace DAL
{
    public class PersonaRepository
    {
        string FileName = @"Persona.txt";
        

         List<Persona> Personas = new List<Persona>();

        public PersonaRepository()
        {
            
        }

        public void Guardar (Persona persona)
        {
            FileStream SourceStream = new FileStream(FileName, FileMode.Append);
            StreamWriter writer = new StreamWriter(SourceStream);

            writer.WriteLine(persona.Identificacion + ";" + persona.Nombre + ";" + persona.Edad + ";" + persona.Sexo + ";" + persona.Pulsaciones + ";");
            writer.Close();
            SourceStream.Close();
        }

        public void Eliminar (Persona persona)
        {
            Personas = Consultar();
            FileStream SourceStream = new FileStream(FileName, FileMode.Create);
            SourceStream.Close();

            foreach (var item in Personas)
            {
                if(persona.Identificacion != item.Identificacion)
                {
                    Guardar(item);
                }
            }
        }

        public void Modificar (Persona personaVieja, Persona personaNueva)
        {
            Personas = Consultar();
            FileStream SourceStream = new FileStream(FileName, FileMode.Create);
            SourceStream.Close();
            foreach (var item in Personas)
            {
                if (personaVieja.Identificacion != item.Identificacion)
                {
                    Guardar(item);
                }
                else
                {
                    Guardar(personaNueva);
                }
            }
        }

        public List<Persona> Consultar()
        {
            Personas.Clear();
            FileStream SourceStream = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader Reader = new StreamReader(SourceStream);

            string linea = string.Empty;
            while ((linea = Reader.ReadLine()) != null)
            {
                Persona persona;
                persona = Mapear(linea);
                Personas.Add(persona);
            }

            Reader.Close();
            SourceStream.Close();
            return Personas;
        }

        public Persona Mapear(string linea)
        {
            char delimiter = ';';
            string[] DatosPersona = linea.Split(delimiter);

            Persona persona = new Persona();
            persona.Identificacion = DatosPersona[0];
            persona.Nombre = DatosPersona[1];
            persona.Edad = int.Parse(DatosPersona[2]);
            persona.Sexo = DatosPersona[3];

            return persona;
        }

        public Persona Buscar(string identificacion)
        {
            List<Persona> Persona = Consultar();
            foreach (var item in Persona)
            {
                if (item.Identificacion.Equals(identificacion))
                {
                    return item;
                }
            }

            return null;
        }

       

    }
}
