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

        public Universitario() : base()
        {
            this._legajo = 0;
        }
        public Universitario(int legajo, string nombre, string apellido, string dni, Enacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this._legajo = legajo;
        }
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if (pg1.DNI == pg2.DNI || pg1._legajo == pg2._legajo)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        protected virtual string MostrarDatos()
        {
            return "Nombre Completo: " + this.Nombre + " " + this.Apellido + "\nNacionalidad: " + this.Nacionalidad  + "\nLegajo " + this._legajo;
        }
        protected abstract string ParticiparEnClase();

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
