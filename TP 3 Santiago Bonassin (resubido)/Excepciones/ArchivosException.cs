using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException:Exception
    {
        static string mensaje = "Se produjo un error en el guardado de los archivos";
        public ArchivosException(Exception innerException) : base(mensaje, innerException)
        {
        }
    }
}
