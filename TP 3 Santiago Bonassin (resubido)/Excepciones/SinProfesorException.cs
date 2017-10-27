using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinProfesorException:Exception
    {
        static string mensaje = "No hay profesor capas de dar la clase";
        public SinProfesorException() : base(mensaje)
        {
        }
    }
}
