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

        /// <summary>
        /// Retorna y asigna el valor de la lista de alumnos
        /// </summary>
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
        /// <summary>
        /// Retorna y asigna el valor del atributo clase
        /// </summary>
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
        /// <summary>
        /// Retorna y asigna el valor del atributo instructor
        /// </summary>
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
        /// <summary>
        /// Crea un objeto del tipo jornada e inicializa la lista de alumnos
        /// </summary>
        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }
        /// <summary>
        /// Crea un objeto del tipo jornada llamando al constructor por default
        /// </summary>
        /// <param name="clase">Enumerado del tipo EClase con la clase a asignar</param>
        /// <param name="instructor">Profesor a asignar</param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }
        /// <summary>
        /// Compara si una jornada es igual a un alumno revisando si este esta en la lista
        /// </summary>
        /// <param name="j">Jornada pasada por parametro</param>
        /// <param name="a">Alumno pasado por parametro</param>
        /// <returns>True si son iguales, false en caso contrario</returns>
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
        /// <summary>
        /// Compara si una jornada no es igual a un alumno
        /// </summary>
        /// <param name="j">Jornada pasada por parametro</param>
        /// <param name="a">Alumno pasado por parametro</param>
        /// <returns>True si son desiguales, false en caso contrario</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        /// <summary>
        /// Comprueba si un alumno esta en la jornada, y si no lo esta lo agrega
        /// </summary>
        /// <param name="j">Jornada pasada por parametro</param>
        /// <param name="a">Alumno pasado por parametro</param>
        /// <returns>Retorna la jornada pasada por parametro</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j._alumnos.Add(a);
            }
            return j;
        }
        /// <summary>
        /// Muestra los datos de la jornada
        /// </summary>
        /// <returns>Retorna una cadena con la informacion de la jornada</returns>
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
        /// <summary>
        /// Guarda una jornada a un archivo de texto
        /// </summary>
        /// <param name="jornada">Jornada a guardar</param>
        /// <returns>True si pudo guardar la jornada, false en caso contrario</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto text = new Texto();
            if (text.Guardar(@"\jornada.txt", jornada.ToString()))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Realiza la lectura del archivo del texto
        /// </summary>
        /// <returns>Retorna la cadena con lo que pudo leer o null si no pudo</returns>
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
