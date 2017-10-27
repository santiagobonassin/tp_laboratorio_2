using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario:Persona
    {
        private int _legajo;

        /// <summary>
        /// Construye un objeto del tipo Universitario llamando al constructor base
        /// </summary>
        public Universitario() : base()
        {
            this._legajo = 0;
        }
        /// <summary>
        /// Construye un objeto del tipo Universitario llamando al constructor base con parametros
        /// </summary>
        /// <param name="legajo">Entero con la id del universitario</param>
        /// <param name="nombre">Cadena pasada por parametro con el nombre</param>
        /// <param name="apellido">Cadena pasada por parametro con el apellido</param>
        /// <param name="dni">Cadena con el numero de dni</param>
        /// <param name="nacionalidad">Enumerado del tipo Enacionalidad que indica la nacionalidad</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, Enacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this._legajo = legajo;
        }
        /// <summary>
        /// Compara si 2 universitarios son iguales por su dni y legajo
        /// </summary>
        /// <param name="pg1">Primer objeto Universitario</param>
        /// <param name="pg2">Segundo objeto Universitario</param>
        /// <returns>Retorna True si son iguales, false en caso contrario</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if (pg1.DNI == pg2.DNI || pg1._legajo == pg2._legajo)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Compara si 2 universitarios no son iguales
        /// </summary>
        /// <param name="pg1">Primer objeto Universitario</param>
        /// <param name="pg2">Segundo objeto Universitario</param>
        /// <returns>Retorna True si son desiguales, false en caso contrario</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        /// <summary>
        /// Metodo virtual que muestra los datos de la clase
        /// </summary>
        /// <returns>Retorna la cadena con la informacion de la clase</returns>
        protected virtual string MostrarDatos()
        {
            return "Nombre Completo: " + this.Nombre + " " + this.Apellido + "\nNacionalidad: " + this.Nacionalidad  + "\nLegajo " + this._legajo;
        }
        /// <summary>
        /// Metodo abstracto que muestra en que clase participa
        /// </summary>
        /// <returns>Retorna la cadena con las clases en las que participa</returns>
        protected abstract string ParticiparEnClase();
        /// <summary>
        /// Indica si un objeto es Universitario
        /// </summary>
        /// <param name="obj">Objeto del tipo object</param>
        /// <returns>Retorna True si lo es y falso en caso contrario</returns>
        public override bool Equals(object obj)
        {
            if (obj is Universitario)
            {
                return true;
            }
            return false;
        }
    }
}
