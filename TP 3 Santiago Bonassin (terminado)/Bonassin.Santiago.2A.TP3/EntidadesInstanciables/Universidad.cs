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
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Instructores = new List<Profesor>();
            this.Jornada = new List<Jornada>();
        }
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
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
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
        public static bool operator !=(Universidad g, Profesor p)
        {
            return !(g == p);
        }
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
        public static Universidad operator +(Universidad g, Profesor p)
        {
            if (g != p)
            {
                g.profesores.Add(p);
            }      
            return g;
        }
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
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
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
