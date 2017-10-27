using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Alumno:Universitario
    {
        private Universidad.EClases _clasesQueToma;
        private EEstadoCuenta _estadoCuenta;

        public enum EEstadoCuenta
        {
            AlDia, Deudor, Becado
        }
        /// <summary>
        /// Crea un objeto del tipo alumno llamando a su constructor base
        /// </summary>
        public Alumno() : base()
        {
            this._clasesQueToma = Universidad.EClases.Legislacion;
            this._estadoCuenta = EEstadoCuenta.AlDia;
        }
        /// <summary>
        /// Crea un objeto del tipo alumno llamando a su constructor base con parametros
        /// </summary>
        /// <param name="id">Entero con la id del universitario</param>
        /// <param name="nombre">Cadena pasada por parametro con el nombre</param>
        /// <param name="apellido">Cadena pasada por parametro con el apellido</param>
        /// <param name="dni">Cadena con el numero de dni</param>
        /// <param name="nacionalidad">Enumerado del tipo Enacionalidad que indica la nacionalidad</param>
        /// <param name="clasesQueToma">Enumerado del tipo EClases que indica las clases a las que asiste</param>
        public Alumno(int id, string nombre, string apellido, string dni, Enacionalidad nacionalidad, Universidad.EClases clasesQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesQueToma = clasesQueToma;
            this._estadoCuenta = EEstadoCuenta.AlDia;
        }
        /// <summary>
        /// Crea un objeto del tipo alumno llamando al constructor parametrizado
        /// </summary>
        /// <param name="id">Entero con la id del universitario</param>
        /// <param name="nombre">Cadena pasada por parametro con el nombre</param>
        /// <param name="apellido">Cadena pasada por parametro con el apellido</param>
        /// <param name="dni">Cadena con el numero de dni</param>
        /// <param name="nacionalidad">Enumerado del tipo Enacionalidad que indica la nacionalidad</param>
        /// <param name="clasesQueToma">Enumerado del tipo EClases que indica las clases a las que asiste</param>
        /// <param name="estadoCuenta">Enumerado del tipo EEstadoCuenta que indica cual es el estado de la cuenta</param>
        public Alumno(int id, string nombre, string apellido, string dni, Enacionalidad nacionalidad, Universidad.EClases clasesQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, clasesQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }
        /// <summary>
        /// Sobreescribe el metodo virtual MostrarDatos y le suma las clases en las que participa el alumno y el estado de la cuenta
        /// </summary>
        /// <returns>Retorna una cadena con la informacion del alumno</returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + "\n" +ParticiparEnClase() + "\nEstado Cuenta: " + this._estadoCuenta + "\n\n";
        }
        /// <summary>
        /// Sobreescribe el metodo abstracto ParticiparEnClase y muestra que clases toma ese alumno
        /// </summary>
        /// <returns>Retorna una cadena con las clases en las que participa el alumno</returns>
        protected override string ParticiparEnClase()
        {
            return "Toma clase de " + this._clasesQueToma.ToString();
        }
        /// <summary>
        /// Compara si un alumno participa en una clase tomando en cuenta el estado de su cuenta
        /// </summary>
        /// <param name="a">Alumno pasado por parametro</param>
        /// <param name="clase">Enumerado del tipo Eclase a comparar</param>
        /// <returns>Retorna True si es igual y False en caso contrario</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if (a._clasesQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Compara si un alumno no participa en una clase
        /// </summary>
        /// <param name="a">Alumno pasado por parametro</param>
        /// <param name="clase">Enumerado del tipo Eclase a comparar</param>
        /// <returns>Retorna True si es desigual y False en caso contrario</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return (a._clasesQueToma != clase);
        }
        /// <summary>
        /// Hace publicos los datos de MostrarDatos
        /// </summary>
        /// <returns>Retorna una cadena con la informacion del alumno</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
