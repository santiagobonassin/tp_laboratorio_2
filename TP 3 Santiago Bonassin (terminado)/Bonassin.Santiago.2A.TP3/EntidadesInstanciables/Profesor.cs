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

        private Profesor() : base()
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();

        }
        public Profesor(int id, string nombre, string apellido, string dni, Enacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }
        static Profesor()
        {
            _random = new Random();
        }

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
        protected override string ParticiparEnClase()
        {          
            return "\nCLASES DEL DIA: " + this._clasesDelDia.Dequeue();
        }
        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + this._clasesDelDia.Peek().ToString();
        }
        public override string ToString()
        {
            return MostrarDatos();
        }
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases c in i._clasesDelDia)
            {
                if (clase == c)
                    return true;
            }
            return false;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
    }
}
