using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    public class Numero
    {
        //fields
        #region
        double numero;

        #endregion

        //constructor
        #region
        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double d) : this()
        {
            this.numero = d;
        }

        public Numero(string numeroStr) : this() 
        {
            this.setNumero = numeroStr;
        }

        #endregion


        //properties
        #region
        public string setNumero
        {
            set { this.numero = ValidarNumero(value); }
        }

        #endregion

        //Methods
        #region
        static double ValidarNumero(string strNumero)
        {
            double retorno;
            double.TryParse(strNumero, out retorno);

            return retorno;
        }

        public static string BinarioDecimal(string binario)
        {
            string retorno = "Valor Invalido";
            int aux;

            if (Int32.TryParse(binario, out aux) == true)
            {
                aux = Convert.ToInt32(binario, 2);

                if (aux > 0)
                {
                    retorno = aux.ToString();
                }
                else if (aux < 0)
                {
                    aux = Math.Abs(aux);
                    retorno = aux.ToString();
                }

            }
            return retorno;
        }

        public static string DecimalBinario(double numero)
        {
            int aux;
            string retorno = "Valor Invalido";

            if (Double.IsNaN(numero) == false)
            {
                retorno = "";
                aux = (int)numero;

                if (aux < 0)
                {
                    aux = Math.Abs(aux);
                }

                while(aux >= 1)
                {
                    retorno = (aux % 2) + retorno;
                    aux = aux / 2;
                }
            }
            return retorno;
        }

        public static string DecimalBinario(string numero)
        {
            double aux;
            string retorno = "Valor Invalido";
            if (Double.TryParse(numero, out aux) == true)
            {
                retorno = DecimalBinario(aux);
            }
            return retorno;
        }

        #endregion

        //Operators
        #region
        public static double operator - (Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator / (Numero n1, Numero n2)
        {
            double retorno;
            if (n2.numero == 0)
            {
                retorno = double.MinValue;
            }
            else
            {
                retorno = n1.numero / n2.numero;
            }


            return retorno;
        }


        public static double operator + (Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        #endregion




    }
}
