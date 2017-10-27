using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        private string _apellido;
        private int _dni;
        private Enacionalidad _nacionalidad;
        private string _nombre;

        public enum Enacionalidad
        {
            Argentino, Extranjero
        }

        public string Apellido
        {
            get
            {
                return this._apellido;
            }
            set
            {
                this._apellido = this.ValidarNombreApellido(value);
            }
        }
        public int DNI
        {
            get
            {
                return this._dni;
            }
            set
            {
                this._dni = this.ValidarDNI(this._nacionalidad, value);
            }
        }
        public Enacionalidad Nacionalidad
        {
            get
            {
                return this._nacionalidad;
            }
            set
            {
                this._nacionalidad = value;
            }
        }
        public string Nombre
        {
            get
            {
                return this._nombre;
            }
            set
            {
                this._nombre = this.ValidarNombreApellido(value);
            }
        }
        public string StringToDNI
        {
            set
            {
                this._dni = int.Parse(value);
            }
        }
        public Persona()
        {
            this._apellido = "Sin apellido";
            this._dni = 0;
            this._nacionalidad = Enacionalidad.Argentino;
            this._nombre = "Sin nombre";
        }
        public Persona(string nombre, string apellido, Enacionalidad nacionalidad) : this()
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido, int dni, Enacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this._dni = dni;
        }
        public Persona(string nombre, string apellido, string dni, Enacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        private int ValidarDNI(Enacionalidad nacionalidad, int dato)
        {
            if (this._nacionalidad == Enacionalidad.Argentino)
            {
                if (dato < 1 || dato > 89999999)
                {
                    throw new DniInvalidoException();
                }
                else
                {
                    return dato;
                }
            }
            else
            {
                if(dato>1 || dato<89999999)
                {
                    throw new NacionalidadInvalidaException();
                }
                else
                {
                    return dato;
                }
                
            }
            
        }
        private int ValidarDNI(Enacionalidad nacionalidad, string dato)
        {
            return this.ValidarDNI(nacionalidad, int.Parse(dato));
        }
        private string ValidarNombreApellido(string dato)
        {
            for (int i = 0; i < dato.Length; i++)
            {
                if (char.IsDigit(dato[i]) == true || char.IsSymbol(dato[i]) == true)
                {
                    return "";
                }
            }
            return dato;
        }
        public override string ToString()
        {
            return "NOMBRE COMPLETO: " + this.Apellido + " " + this.Nombre + "\nNACIONALIDAD: " + this.Nacionalidad + "\n";
        }
        
    }
}
