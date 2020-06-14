using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta
        {
            AlDia, Deudor, Becado
        }

        #region atributos

        Universidad.EClases claseQueToma;
        EEstadoCuenta estadoCuenta;

        #endregion

        #region Constructores

        public Alumno() : base() { }

        public Alumno (int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
            this.estadoCuenta = estadoCuenta;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// retorna los datos del alumno en formato string
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine("ESTADO DE CUENTA: " + this.estadoCuenta.ToString());
            sb.Append(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// retorna las clases que toma el alumno
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("TOMA CLASES DE ");
            sb.AppendLine(this.claseQueToma.ToString());
            return sb.ToString();
        }

        /// <summary>
        /// Hace públicos los datos del alumno
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return (this.MostrarDatos());
        }

        #endregion

        #region Operadores

        /// <summary>
        /// Un alumno será igual a una clase si la toma y su estado de cuenta es no deudor
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;

            if(a.estadoCuenta != EEstadoCuenta.Deudor && a.claseQueToma == clase)
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Un alumno será igual a una clase si la toma y su estado de cuenta es no deudor
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;

            if(a.claseQueToma != clase)
            {
                retorno = true;
            }

            return retorno;
        }


        #endregion


    }
}
