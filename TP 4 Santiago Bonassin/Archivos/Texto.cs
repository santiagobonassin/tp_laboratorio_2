using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        string nombreArchivo;

        public Texto(string archivo)
        {
            this.nombreArchivo = archivo;
        }
        public bool guardar(string datos)
        {
            try
            {
                using (StreamWriter sw=new StreamWriter(this.nombreArchivo,true))
                {
                    sw.WriteLine(datos);
                }
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public bool leer(out List<string>datos)
        {
            datos = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(this.nombreArchivo))
                {
                    while(!sr.EndOfStream)
                    {
                        datos.Add(sr.ReadLine());
                    }                   
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
