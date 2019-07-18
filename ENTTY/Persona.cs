using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
  public  class Persona
    {
        public string  Identificacion { get; set; }
        public string  Nombre { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }

        public decimal Pulsaciones
        {
            get
            {
                if (Sexo.Equals("F") || Sexo.Equals("f"))
                {
                    return (220 - Edad) / 10;
                }
                else
                {
                    return (210 - Edad) / 10;
                }


            }
        }
       
        public override string ToString()
        {
            return $"Identificacion: {Identificacion} ----Nombre: {Nombre} ----Edad: {Edad} ----Sexo: {Sexo} ----Pulsaciones: {Pulsaciones}";
        }

    }
}

