using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using ENTITY;

namespace CalcularPulsaciones
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo continuar; 
            int opcion;


            PersonaService personaServicio = new PersonaService();


            do
            {
                Console.Clear();
                Console.WriteLine("--------------Menu---------------------");
                Console.WriteLine("");
                Console.WriteLine("1. Agregar una persona");
                Console.WriteLine("2. Eliminar una persona");
                Console.WriteLine("3. Modificar una persona");
                Console.WriteLine("4. Lista de personas");
                Console.WriteLine("5. Buscar una persona");
                Console.WriteLine("6. Salir");
                opcion = Int32.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        do
                        {
                            Persona persona = new Persona();
                            Console.Clear();

                            Console.WriteLine("Digite su identificacion: ");
                            persona.Identificacion = Console.ReadLine();

                            Console.WriteLine("Digite su nombre: ");
                            persona.Nombre = Console.ReadLine();

                            Console.WriteLine("Digite su edad: ");
                            persona.Edad = Int32.Parse(Console.ReadLine());

                            Console.WriteLine("Digite su sexo [F/M]");
                            persona.Sexo = Console.ReadLine().ToUpper();

                            persona.Pulsaciones = persona.CalcularPulsacion();

                            Console.WriteLine($"su pulsaciones por cada 10Seg debe ser: {persona.Pulsaciones}");

                            string mensaje = personaServicio.Guardar(persona);

                            Console.WriteLine(mensaje);
                            Console.WriteLine("Desea Continuar S/N");
                            continuar = Console.ReadKey();
                        } while (continuar.KeyChar == ('s') || continuar.KeyChar == ('s'));

                        break;
                    case 2:
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("----------Eliminar una Persona------------------");
                            Console.WriteLine("Digite la identificacion a Eliminar");
                            string identificacion = Console.ReadLine();
                            string mensajeEliminar = personaServicio.Eliminar(identificacion);
                            Console.WriteLine(mensajeEliminar);
                            Console.WriteLine("Desea Continuar S/N");
                            continuar = Console.ReadKey();
                        } while (continuar.KeyChar == ('s') || continuar.KeyChar == ('s'));
                        break;
                    case 3:
                        do
                        {
                            Persona persona = new Persona();
                            Console.Clear();
                            Console.WriteLine("----------Modificar una Persona------------------");
                            Console.WriteLine("Digite la identificacion ");
                            string identificacion = Console.ReadLine();
                            persona.Identificacion = identificacion;
                            Console.WriteLine("Digite datos a modificar");
                            Console.WriteLine("Digite nombre");
                            persona.Nombre = Console.ReadLine();
                            Console.WriteLine("Digite edad");
                            persona.Edad = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Digite sexo");
                            persona.Sexo = Console.ReadLine();
                        
                            string mensajeModificar = personaServicio.Modificar(identificacion, persona);
                            Console.WriteLine("Desea Continuar S/N");
                            continuar = Console.ReadKey();
                        } while (continuar.KeyChar == ('s') || continuar.KeyChar == ('s'));
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("----------lista de Personas------------------");
                        foreach (var item in personaServicio.Consultar())
                        {
                            Console.WriteLine(item.ToString());
                        }
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("----------Buscar una Persona------------------");
                        Console.WriteLine("Digite la identificacion a Buscar");
                        string identificacionBuscada = Console.ReadLine();
                        string personaBuscada = personaServicio.Buscar(identificacionBuscada);
                        Console.WriteLine(personaBuscada);
                        Console.ReadKey();
                        break;
                    case 6: Console.WriteLine("Saliendo...."); Console.ReadKey();
                        break;
                    default: Console.WriteLine("Opcion incorrecta "); Console.ReadKey();
                        break;
                }

            } while (opcion<6);
                
        }
    }
}
