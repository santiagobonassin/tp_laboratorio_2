using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException:Exception
    {
        static string mensaje = "La nacionalidad ingresada no coincide con el numero de DNI ingresado";
        public NacionalidadInvalidaException() : base(mensaje)
        {
        }
        public NacionalidadInvalidaException(string mensaje) : base(mensaje)
        {
        }
    }
}
