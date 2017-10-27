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
        public Alumno() : base()
        {
            this._clasesQueToma = Universidad.EClases.Legislacion;
            this._estadoCuenta = EEstadoCuenta.AlDia;
        }
        public Alumno(int id, string nombre, string apellido, string dni, Enacionalidad nacionalidad, Universidad.EClases clasesQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesQueToma = clasesQueToma;
            this._estadoCuenta = EEstadoCuenta.AlDia;
        }
        public Alumno(int id, string nombre, string apellido, string dni, Enacionalidad nacionalidad, Universidad.EClases clasesQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, clasesQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }
        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + "\n" +ParticiparEnClase() + "\nEstado Cuenta: " + this._estadoCuenta + "\n\n";
        }
        protected override string ParticiparEnClase()
        {
            return "Toma clase de " + this._clasesQueToma.ToString();
        }
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if (a._clasesQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return (a._clasesQueToma != clase);
        }
        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
