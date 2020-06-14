using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Archivos;

namespace ClasesInstanciables
{
    public class Jornada
    {
        #region Atributos

        List<Alumno> alumnos;
        Universidad.EClases clase;
        Profesor instructor;

        #endregion

        #region Constructores

        private Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.Instructor = instructor;
            this.Clase = clase;
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// Get, Set: retorna y asigna la lista de alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        /// <summary>
        /// Get, Set: retorna y asigna la Clase de la jornada
        /// </summary>
        public Universidad.EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }

        /// <summary>
        /// Get, Set: retorna y asigna el profesor de la jornada
        /// </summary>
        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// retorna los valores de la jornada en formato string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA:");
            sb.Append("CLASE DE " + this.Clase.ToString() + " POR ");
            sb.Append(this.Instructor.ToString());
            sb.AppendLine("ALUMNOS: ");
            foreach(Alumno item in this.Alumnos)
            {
                sb.Append(item.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Guarda los datos de la jornada como archivo de texto
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto guardar = new Texto();

            return guardar.Guardar("jornada.txt", jornada.ToString());
        }

        /// <summary>
        /// retorna los datos de una jornada guardada como archivo de texto
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            Texto leer = new Texto();
            string retorno;

            leer.Leer("jornada.txt", out retorno);

            return retorno;
        }

        #endregion

        #region Operadores

        /// <summary>
        /// Una jornada será igual a un alumno si este se encuentra en la lista Alumnos
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator == (Jornada j, Alumno a)
        {
            bool retorno = false;

            foreach(Alumno item in j.Alumnos)
            {
                if(item == a)
                {
                    retorno = true;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Una jornada será igual a un alumno si este se encuentra en la lista Alumnos
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega un alumno a la lista de Alumnos
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if(j != a)
            {
                j.alumnos.Add(a);
            }

            return j;
        }
            
        #endregion

    }
}
