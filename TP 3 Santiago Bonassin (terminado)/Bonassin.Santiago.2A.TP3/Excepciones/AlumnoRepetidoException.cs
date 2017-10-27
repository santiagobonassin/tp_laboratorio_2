using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException:Exception
    {
        static string mensaje = "El alumno ingresado ya esta en la Universidad";
        public AlumnoRepetidoException() : base(mensaje)
        {

        }
    }
}
