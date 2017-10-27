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
        /// <summary>
        /// Permite acceder al valor del atributo apellido al mismo tiempo que lo valida
        /// </summary>
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
        /// <summary>
        /// Permite la accesibilidad al atributo dni y le asigna el valor devuelto por la validacion
        /// </summary>
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
        /// <summary>
        /// Asigna y muestra el valor del atributo nacionalidad
        /// </summary>
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
        /// <summary>
        /// Permite acceder al valor del atributo nombre al mismo tiempo que lo valida
        /// </summary>
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
        /// <summary>
        /// Asigna el valor del atributo dni verificando un string
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this._dni = int.Parse(value);
            }
        }
        /// <summary>
        /// Construye un objeto del tipo Persona e inicializa sus atributos a valores por default
        /// </summary>
        public Persona()
        {
            this._apellido = "Sin apellido";
            this._dni = 0;
            this._nacionalidad = Enacionalidad.Argentino;
            this._nombre = "Sin nombre";
        }
        /// <summary>
        /// Construye un objeto del tipo persona y lo carga con los parametros pasados, llama al constructor por default
        /// </summary>
        /// <param name="nombre">Cadena pasada por parametro con el nombre</param>
        /// <param name="apellido">Cadena pasada por parametro con el apellido</param>
        /// <param name="nacionalidad">Enumerado del tipo Enacionalidad que indica la nacionalidad</param>
        public Persona(string nombre, string apellido, Enacionalidad nacionalidad) : this()
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._nacionalidad = nacionalidad;
        }
        /// <summary>
        /// Construye un objeto del tipo persona y lo carga con los parametros pasados, llama al constructor parametrizado
        /// </summary>
        /// <param name="nombre">Cadena pasada por parametro con el nombre</param>
        /// <param name="apellido">Cadena pasada por parametro con el apellido</param>
        /// <param name="dni">Entero con el numero de documento</param>
        /// <param name="nacionalidad">Enumerado del tipo Enacionalidad que indica la nacionalidad</param>
        public Persona(string nombre, string apellido, int dni, Enacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this._dni = dni;
        }
        /// <summary>
        /// Construye un objeto del tipo persona y lo carga con los parametros pasados, llama al constructor parametrizado
        /// </summary>
        /// <param name="nombre">Cadena pasada por parametro con el nombre</param>
        /// <param name="apellido">Cadena pasada por parametro con el apellido</param>
        /// <param name="dni">Cadena con el numero de dni a ser verificado</param>
        /// <param name="nacionalidad">Enumerado del tipo Enacionalidad que indica la nacionalidad</param>
        public Persona(string nombre, string apellido, string dni, Enacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        /// <summary>
        /// Realiza la validacion del dni ingresado
        /// </summary>
        /// <param name="nacionalidad">Enumerado del tipo Enacionalidad que contiene la nacionalidad a comparar</param>
        /// <param name="dato">Entero con el dni a verificar</param>
        /// <returns>Retorna el dato validado</returns>
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
        /// <summary>
        /// Valida el dni en formato string llamando al metodo entero
        /// </summary>
        /// <param name="nacionalidad">Enumerado del tipo Enacionalidad que contiene la nacionalidad a comparar</param>
        /// <param name="dato">Cadena con el dni a verificar</param>
        /// <returns>Retorna el dato verificado</returns>
        private int ValidarDNI(Enacionalidad nacionalidad, string dato)
        {
            return this.ValidarDNI(nacionalidad, int.Parse(dato));
        }
        /// <summary>
        /// Valida que el nombre y apellido no tengan numeros o simbolos
        /// </summary>
        /// <param name="dato">Cadena con el nombre o apellido a revisar</param>
        /// <returns>Retorna el nombre o apellido verificado</returns>
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
        /// <summary>
        /// Muestra publicamente los datos de la clase
        /// </summary>
        /// <returns>Retorna la cadena conteniendo toda la informacion</returns>
        public override string ToString()
        {
            return "NOMBRE COMPLETO: " + this.Apellido + " " + this.Nombre + "\nNACIONALIDAD: " + this.Nacionalidad + "\n";
        }       
    }
}
