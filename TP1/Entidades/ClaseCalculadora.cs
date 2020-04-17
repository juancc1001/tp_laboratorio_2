using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1;

namespace Entidades
{
    static public class Calculadora
    {
        //Methods
        #region
        static string ValidarOperador(string operador)
        {
            string retorno = "+";
            
            if(operador == "-" ||
                operador == "*" ||
                operador == "/"
                )
            {
                retorno = operador;
            }

            return retorno;
        }

        public static double Operar (Numero n1, Numero n2, string operador)
        {
            double retorno = 0;
            
            operador = Calculadora.ValidarOperador(operador);

            switch (operador)
            {
                case "+":
                    retorno = n1 + n2;
                    break;
                case "-":
                    retorno = n1 - n2;
                    break;
                case "*":
                    retorno = n1 * n2;
                    break;
                case "/":
                    retorno = n1 / n2;
                    break;
            }

            return retorno;
        }

        #endregion


    }
}
