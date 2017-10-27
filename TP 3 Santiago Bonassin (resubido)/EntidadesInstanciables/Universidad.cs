using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        public enum EClases
        {
            Programacion, Laboratorio, Legislacion, SPD
        }
        /// <summary>
        /// Retorna y asigna el valor de la lista de alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }
        /// <summary>
        /// Retorna y asigna el valor de la lista de jornadas
        /// </summary>
        public List<Jornada> Jornada
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }
        /// <summary>
        /// Retorna y asigna el valor de la lista de profesores
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }
        /// <summary>
        /// Retorna y asigna el objeto en una poscision determinada
        /// </summary>
        /// <param name="i">Poscision en la que se van a mostrar y cargar los datos</param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get
            {
                return this.Jornada[i];
            }
            set
            {
                this.Jornada[i] = value;
            }
        }
        /// <summary>
        /// Crea un objeto del tipo Universidad e inicializa las listas
        /// </summary>
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Instructores = new List<Profesor>();
            this.Jornada = new List<Jornada>();
        }
        /// <summary>
        /// Compara si una universidad es igual a un alumno revisando si este esta en la lista
        /// </summary>
        /// <param name="g">Universidad pasada por parametro</param>
        /// <param name="a">Alumno pasado por parametro</param>
        /// <returns>Retorna true si son iguales y false en caso contrario</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno i in g.alumnos)
            {
                if (i == a)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Compara si una universidad no es igual a un alumno
        /// </summary>
        /// <param name="g">Universidad pasada por parametro</param>
        /// <param name="a">Alumno pasado por parametro</param>
        /// <returns>Retorna true si no son iguales y false en caso contrario</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        /// <summary>
        /// Compara si una universidad es igual a un profesor revisando si este esta en la lista
        /// </summary>
        /// <param name="g">Universidad pasada por parametro</param>
        /// <param name="p">Profesor pasado por parametro</param>
        /// <returns>Retorna true si son iguales y false en caso contrario</returns>
        public static bool operator ==(Universidad g, Profesor p)
        {
            foreach(Profesor i in g.profesores)
            {
                if(i==p)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Compara si una universidad no es igual a un profesor
        /// </summary>
        /// <param name="g">Universidad pasada por parametro</param>
        /// <param name="p">Profesor pasado por parametro</param>
        /// <returns>Retorna true si son desiguales y false en caso contrario</returns>
        public static bool operator !=(Universidad g, Profesor p)
        {
            return !(g == p);
        }
        /// <summary>
        /// Compara si una universidad es igual a una clase revisando si un profesor da esa clase
        /// </summary>
        /// <param name="g">Universidad pasada por parametro</param>
        /// <param name="clase">Enumerado del tipo EClase con la clase a buscar</param>
        /// <returns>Retorna el primer profesor que da esa clase</returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach (Profesor i in g.Instructores)
            {
                if (i == clase)
                {
                    return i;
                }
            }
            throw new SinProfesorException();
        }
        /// <summary>
        /// Compara si una universidad no es igual a una clase revisando si un profesor no da esa clase
        /// </summary>
        /// <param name="g">Universidad pasada por parametro</param>
        /// <param name="clase">Enumerado del tipo EClase con la clase a buscar</param>
        /// <returns>Retorna el primer profesor que no de esa clase</returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor i in g.Instructores)
            {
                if (i != clase)
                {
                    return i;
                }                 
            }
            throw new SinProfesorException();
        }
        /// <summary>
        /// Verifica si un alumno esta en la universidad, y si no lo esta lo agrega
        /// </summary>
        /// <param name="g">Universidad pasada por parametro</param>
        /// <param name="a">Alumno pasado por parametro</param>
        /// <returns>Retorna la universidad pasada por parametro</returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if(g!=a)
            {
                g.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return g;
        }
        /// <summary>
        /// Verifica si un profesor esta en la universidad, y si no lo esta lo agrega
        /// </summary>
        /// <param name="g">Universidad pasada por parametro</param>
        /// <param name="p">Profesor pasado por parametro</param>
        /// <returns>Retorna la universidad pasada por parametro</returns>
        public static Universidad operator +(Universidad g, Profesor p)
        {
            if (g != p)
            {
                g.profesores.Add(p);
            }      
            return g;
        }
        /// <summary>
        /// Verifica si un profesor da la clase pasada por parametro, y si es asi crea una jornada con esa clase, profesor y alumnos que tomen esa clase
        /// </summary>
        /// <param name="g">Universidad pasada por parametro</param>
        /// <param name="clase">Enumerado del tipo EClase que contiene la clase a buscar</param>
        /// <returns>Retorna la universidad pasada por parametro</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada jornadaAux;
            foreach (Profesor i in g.profesores)
            {
                if (i == clase)
                {
                    jornadaAux = new Jornada(clase, i);
                    g.jornada.Add(jornadaAux);
                    foreach (Alumno a in g.alumnos)
                    {
                        if (a == clase)
                        {
                            jornadaAux += a;
                        }
                    }
                    break;
                }
            }
            return g;
        }
        /// <summary>
        /// Muestra los datos de la universidad que se le asigne
        /// </summary>
        /// <param name="gim">Universidad pasada por parametro</param>
        /// <returns>Retorna una cadena conla informacion de la universidad</returns>
        static string MostrarDatos(Universidad gim)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA:");
            foreach (Jornada j in gim.jornada)
            {
                sb.AppendLine(j.ToString());
            }
            return sb.ToString();
        }
        /// <summary>
        /// Hace publicos los datos del metodo estatico MostrarDatos
        /// </summary>
        /// <returns>Retorna la cadena que devuelve el metodo estatico al que llama</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        /// <summary>
        /// Guarda los datos de la universidad asignada en formato xml
        /// </summary>
        /// <param name="gim">Universidad pasada por parametro</param>
        /// <returns>Retorna true si pudo guardar el archivo o falso en caso contrario</returns>
        public static bool Guardar(Universidad gim)
        {
            Xml<Universidad> salida = new Xml<Universidad>();
            if (salida.Guardar(@"\universidad.xml", gim))
            {
                return true;
            }
            return false;
        }
    }
}
