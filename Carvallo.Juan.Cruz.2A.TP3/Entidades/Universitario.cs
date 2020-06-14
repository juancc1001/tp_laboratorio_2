using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        int legajo;

        #region constructores

        public Universitario() : base() { }

        public Universitario(int legajo, string nombre, string apellido, string dni, Persona.ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// retorna los datos del objeto universitario como string
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.Append("LEGAJO NÚMERO: ");
            sb.AppendLine(this.legajo.ToString());

            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();

        /// <summary>
        /// retorna true si el objeto es igual a this
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            bool retorno = false;

            if(obj is Universitario)
            {
                if((Universitario)obj == this)
                {
                    retorno = true;
                }
            }

            return retorno;
        }

        #endregion

        #region Operadores

        /// <summary>
        /// dos objetos universitarios seran iguales si son del mismo tipo y sus legajos o dni son iguales
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;
           

                if ((pg1.GetType() == pg2.GetType()) && (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI))
                {
                    retorno = true;
                }

           
            return retorno;
        }

        /// <summary>
        /// dos objetos universitarios seran iguales si son del mismo tipo y sus legajos o dni son iguales
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
            
        #endregion

    }
}
