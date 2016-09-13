using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp1_Lab_II
{
    class Calculadora2
    {  
        /// <summary>
        /// Toma 2 valores,un operador y calcula la operacion que corresponda
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
              
        public static double Operar(Numero numero1, Numero numero2, string operador)
        {
            double num1 = numero1.GetNumero();
            double num2 = numero2.GetNumero();
            double retorno = 0;

            switch (operador)
            {

                case "+":
                    retorno = num1 + num2;
                    break;
                case "-":
                    retorno = num1 - num2;
                    break;
                case "*":
                    retorno = num1 * num2;
                    break;
                case "/":
                    if (num2 != 0)
                        retorno = num1 / num2;
                    else
                        retorno = 00;
                    break;

            }


            return retorno;
        }
        /// <summary>
        /// Recibe un string y valida que este comprendido en ciertos parametros
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static string ValidarOperador(string operador)
        {
            string retorno = "+";
            if (operador == "+" || operador == "-" || operador == "*" || operador == "/")
                retorno = operador;
            return retorno;
        }
    }
}
