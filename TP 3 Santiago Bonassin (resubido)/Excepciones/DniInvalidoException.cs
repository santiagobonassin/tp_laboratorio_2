using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException:Exception
    {
        protected static string mensajeBase = "El DNI ingresado no es valido";
        public DniInvalidoException() : base()
        {
        }
        public DniInvalidoException(Exception e) : this(mensajeBase, e)
        {
        }
        public DniInvalidoException(string mensaje) : base(mensaje)
        {
        }
        public DniInvalidoException(string mensaje, Exception e) : base(mensaje, e)
        {
        }
    }
}
