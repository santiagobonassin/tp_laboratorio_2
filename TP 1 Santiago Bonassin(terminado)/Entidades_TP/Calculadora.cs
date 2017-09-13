using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_TP
{
    public class Calculadora
    {
        /// <summary>
        /// Realiza la operacion deseada entre los dos operandos indicados por el usuario
        /// </summary>
        /// <param name="num1">Primer operando</param>
        /// <param name="num2">Segundo Operando</param>
        /// <param name="operador">Operacion a realizar</param>
        /// <returns>Devuelve el resultado de la operacion de tipo double</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;
            operador = Calculadora.ValidarOperador(operador);

            if (operador == "+")
            {
                resultado = num1.GetNumero() + num2.GetNumero();
            }
            else if (operador == "-")
            {
                resultado = num1.GetNumero() - num2.GetNumero();
            }
            else if (operador == "*")
            {
                resultado = num1.GetNumero() * num2.GetNumero();
            }
            else if (operador == "/")
            {
                if (num2.GetNumero() == 0)
                {
                    resultado = 0;
                }
                else
                {
                    resultado = num1.GetNumero() / num2.GetNumero();
                }

            }
            return resultado;
        }
        /// <summary>
        /// Verifica que la operacion indicada por el usuario sea valida (Suma, Resta, Multiplicacion o Division)
        /// </summary>
        /// <param name="operador">El signo de la operacion a verificar</param>
        /// <returns>Devuelve el operador verificado en tipo string</returns>
        public static string ValidarOperador(string operador)
        {
            if (operador != "+" && operador != "-" && operador != "*" && operador != "/")
            {
                operador = "+";
            }
            return operador;
        }
        
    }
}
