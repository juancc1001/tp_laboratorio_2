using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        #region atributos
        
        Queue<Universidad.EClases> clasesDelDia;
        static Random random;

        #endregion

        #region Constructores

        static Profesor() 
        {
            random = new Random(Environment.TickCount);
        }

        Profesor()
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this.randomClases();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) 
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            Profesor aux = new Profesor();
            this.clasesDelDia = aux.clasesDelDia;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Agrega aleatoriamente dos clases a la cola "clasesDelDia" del objeto Profesor
        /// </summary>
        void randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 3));
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 3));
        }

        /// <summary>
        /// retorna los datos del Profesor en formato string
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
           
            return sb.ToString();
        }

        /// <summary>
        /// retorna las clases del dia
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA: ");
            foreach (Universidad.EClases item in this.clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }


        /// <summary>
        /// Hace públicos los datos del Profesor
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region operadores

        /// <summary>
        /// Un profesor será igual a una clase si esta se encuentra en sus clases del dia
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator == (Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;

            foreach (Universidad.EClases item in i.clasesDelDia)
            {
                if(item == clase)
                {
                    retorno = true;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Un profesor será igual a una clase si esta se encuentra en sus clases del dia
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
         
        #endregion
    }
}
