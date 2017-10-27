using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;

        public List<Alumno> Alumnos
        {
            get
            {
                return this._alumnos;
            }
            set
            {
                this._alumnos = value;
            }
        }
        public Universidad.EClases Clase
        {
            get
            {
                return this._clase;
            }
            set
            {
                this._clase = value;
            }
        }
        public Profesor Instructor
        {
            get
            {
                return this._instructor;
            }
            set
            {
                this._instructor = value;
            }
        }
        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno i in j._alumnos)
            {
                if (i == a)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j._alumnos.Add(a);
            }
            return j;
        }
        public override string ToString()
        {
            string aux = "";

            aux += "--------------------------------------------------------------------------\n";
            aux += "CLASE DE: " + this._clase + "\nPor " + this._instructor.ToString() + "\n";
            aux += "\nALUMNOS:\n";

            foreach (Alumno i in this._alumnos)
            {
                if (i == _clase)
                {
                    aux += i.ToString();
                }
            }
            return aux;
        }
        public static bool Guardar(Jornada jornada)
        {
            ;
            Texto text = new Texto();
            if (text.Guardar(@"\jornada.txt", jornada.ToString()))
            {
                return true;
            }
            return false;
        }

        public static string Leer()
        {
            string retorno = null;
            Texto miTexto = new Texto();
            if (miTexto.Leer(@"..\jornada.txt", out retorno))
            {
                return retorno;
            }

            return null;
        }
    }
}
