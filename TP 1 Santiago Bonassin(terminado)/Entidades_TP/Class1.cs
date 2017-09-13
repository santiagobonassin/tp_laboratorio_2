using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_TP
{
    public class Numero
    {
        double _numero;
        /// <summary>
        /// Construye un objeto del tipo Numero e inicializa el atributo _numero en 0
        /// </summary>
        public Numero()
        {
            this._numero = 0;
        }
        /// <summary>
        /// Construye un objeto del tipo Numero y le carga el atributo -numero con el valor verificado de lo que ingrese el usuario
        /// </summary>
        /// <param name="numero">Operando a verificar ingresado por el usuario</param>
        public Numero(string numero)
        {
            this.SetNumero(numero);
        }
        /// <summary>
        /// Construye un objeto del tipo Numero y lo carga con lo ingresado por el usuario
        /// </summary>
        /// <param name="numero">Operando ingresado por el usuario</param>
        public Numero(double numero)
        {
            this._numero = numero;
        }
        /// <summary>
        /// Le pasa a Calculadora el valor del atributo _numero del objeto de tipo Numero
        /// </summary>
        /// <returns>Devuelve el valor de _numero de tipo double</returns>
        public double GetNumero()
        {
            return this._numero;
        }
        /// <summary>
        /// Llama a la funcion ValidarNumero para verificar el dato ingresado por el usuario
        /// </summary>
        /// <param name="numero">El operando a verificar ingresado por el usuario</param>
        void SetNumero(string numero)
        {
            this._numero = Numero.ValidarNumero(numero);
        }
        /// <summary>
        /// Valida si el dato ingresado por el usuario puede pasarse a double
        /// </summary>
        /// <param name="numero">Dato a validar</param>
        /// <returns>Devuelve el numero parseado si se pudo convertir o 0 si el mismo no se pudo parsear</returns>
        static private double ValidarNumero(string numero)
        {
            if (!(double.TryParse(numero, out double numVerificado)))
            {
                numVerificado = 0;
            }
            return numVerificado;
        }
    }
}
