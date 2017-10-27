using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Profesor:Universitario
    {
        private Queue<Universidad.EClases> _clasesDelDia;
        private static Random _random;

        /// <summary>
        /// Crea un objeto del tipo Profesor llamando a su constructor base
        /// </summary>
        private Profesor() : base()
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();

        }
        /// <summary>
        /// Crea un objeto del tipo Profesor llamando a su constructor base con parametros
        /// </summary>
        /// <param name="id">Entero con la id del universitario</param>
        /// <param name="nombre">Cadena pasada por parametro con el nombre</param>
        /// <param name="apellido">Cadena pasada por parametro con el apellido</param>
        /// <param name="dni">Cadena con el numero de dni</param>
        /// <param name="nacionalidad">Enumerado del tipo Enacionalidad que indica la nacionalidad</param>
        public Profesor(int id, string nombre, string apellido, string dni, Enacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }
        /// <summary>
        /// Constructor que inicializa el atributo estatico random
        /// </summary>
        static Profesor()
        {
            _random = new Random();
        }
        /// <summary>
        /// Realiza la asignacion aleatoria de clases
        /// </summary>
        private void _randomClases()
        {
            int clasesRandom = _random.Next(1, 4);
            if (clasesRandom == 1)
            {
                this._clasesDelDia.Enqueue(Universidad.EClases.Programacion);
            }
            else if (clasesRandom == 2)
            {
                this._clasesDelDia.Enqueue(Universidad.EClases.Laboratorio);
            }
            if (clasesRandom == 3)
            {
                this._clasesDelDia.Enqueue(Universidad.EClases.Legislacion);
            }
            if (clasesRandom == 4)
            {
                this._clasesDelDia.Enqueue(Universidad.EClases.SPD);
            }
            clasesRandom = _random.Next(1, 4);
            if (clasesRandom == 1)
            {
                this._clasesDelDia.Enqueue(Universidad.EClases.SPD);
            }
            else if (clasesRandom == 2)
            {
                this._clasesDelDia.Enqueue(Universidad.EClases.Legislacion);
            }
            if (clasesRandom == 3)
            {
                this._clasesDelDia.Enqueue(Universidad.EClases.Laboratorio);
            }
            if (clasesRandom == 4)
            {

                this._clasesDelDia.Enqueue(Universidad.EClases.Programacion);
            }
        }
        /// <summary>
        /// Sobreescribe el metodo abstracto ParticiparEnClase y muestra que clases tiene ese profesor
        /// </summary>
        /// <returns>Retorna la cadena con las clases que da el profesor</returns>
        protected override string ParticiparEnClase()
        {          
            return "\nCLASES DEL DIA: " + this._clasesDelDia.Peek().ToString();
        }
        /// <summary>
        /// Sobreescribe el metodo virtual MostrarDatos y le suma las clases que da el profesor
        /// </summary>
        /// <returns>Retorna la cadena con la informacion del profesor</returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + ParticiparEnClase();
        }
        /// <summary>
        /// Hace publicos los datos del profesor
        /// </summary>
        /// <returns>Retorna la cadena con los datos del profesor</returns>
        public override string ToString()
        {
            return MostrarDatos();
        }
        /// <summary>
        /// Compara si un profesor es igual a una clase
        /// </summary>
        /// <param name="i">Profesor pasado por parametro</param>
        /// <param name="clase">Clase pasada por parametro</param>
        /// <returns>Retorna True si son iguales y false en caso contrario</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases c in i._clasesDelDia)
            {
                if (clase == c)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Compara si un profesor no es igual a una clase
        /// </summary>
        /// <param name="i">Profesor pasado por parametro</param>
        /// <param name="clase">Clase pasada por parametro</param>
        /// <returns>Retorna True si son desiguales y false en caso contrario</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
    }
}
