using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Archivos;
using EntidadesAbstractas;
using Excepciones;

namespace ClasesInstanciables
{
    public class Universidad
    {
        public enum EClases
        {
            Programacion, Laboratorio, Legislacion, SPD
        }

        #region Atributos

        List<Alumno> alumnos;
        List<Jornada> jornada;
        List<Profesor> profesores;

        #endregion

        #region Constructores

        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Jornadas = new List<Jornada>();
            this.Instructores = new List<Profesor>();
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// Get, Set: asigna y retorna la lista de alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        /// <summary>
        /// Get, Set: asigna y retorna la lista de profesores
        /// </summary>
        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }

        /// <summary>
        /// Get, Set: asigna y retorna la lista de jornadas
        /// </summary>
        public List<Jornada> Jornadas
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }

        /// <summary>
        /// Get, Set: asigna y retorna una jornada en un índice especificado
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get 
            {
                if (i >= 0)
                {
                    return this.Jornadas[i];
                }
                else
                {
                    throw new Exception("Indice no válido ");
                }           
            }
            set 
            {
                if (i >= 0)
                {
                    this.Jornadas[i] = value;
                }
                else
                {
                    throw new Exception("Indice no válido ");
                }
            }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// retorna los datos de la universidad en formato string
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Jornada item in uni.Jornadas)
            {
                sb.Append(item.ToString());
                sb.AppendLine("<------------------------------------------------------>\n");
            }
            

            return sb.ToString();
        }

        /// <summary>
        /// hace publicos los datos de la universidad
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// Serializa los datos del objeto universidad en un archivo .xml
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {

            Xml<Universidad> g = new Xml<Universidad>();

            return g.Guardar("Universidad.xml", uni);
        }

        /// <summary>
        /// retorna los datos de un archivo .xml que contenga un objeto Universidad
        /// </summary>
        /// <returns></returns>
        public static Universidad Leer()
        {
            Xml<Universidad> l = new Xml<Universidad>();
            Universidad aux;

            l.Leer("Universidad.xml", out aux);

            return aux;
        }

        #endregion

        #region Operadores

        /// <summary>
        /// Una universidad será igual a un alumno si este ya se encuentra añadido a la lista Alumnos
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno item in g.Alumnos)
            {
                if(item == a)
                {
                    retorno = true;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Una universidad será igual a un alumno si este ya se encuentra añadido a la lista Alumnos
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Una universidad será igual a un profesor si este ya se encuentra añadido a la lista profesores
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;

            foreach (Profesor item in g.Instructores)
            {
                if(item == i)
                {
                    retorno = true;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Una universidad será igual a un profesor si este ya se encuentra añadido a la lista profesores
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// retorna el primer profesor que da la clase
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor instructor = null;
            bool flag = false;

            foreach (Profesor item in u.Instructores)
            {
                if (item == clase)
                {
                    instructor = item;
                    flag = true;
                    break;
                }
                
            }

            if(flag == false)
            {
                throw new SinProfesorException();
            }

            return instructor;
        }

        /// <summary>
        /// retorna el primer profesor que no da la clase especificada
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor instructor = null;

            foreach (Profesor item in u.Instructores)
            {
                if (item != clase)
                {
                    instructor = item;
                    break;
                }

            }

            return instructor;
        }

        /// <summary>
        /// Agrega una jornada de la clase específicada, con los alumnos que toman dicha clase y su instructor
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator + (Universidad g, EClases clase)
        {
            Profesor instructor = (g == clase);
            Jornada aux;
            List<Alumno> listaAlumnos = new List<Alumno>();

            foreach (Alumno item in g.Alumnos)
            {
                if(item == clase)
                {
                    listaAlumnos.Add(item);
                }
            }

            aux = new Jornada(clase, instructor);
            aux.Alumnos = listaAlumnos;
            g.Jornadas.Add(aux);

            return g;
        }

        /// <summary>
        /// Añade un alumno a la lista alumnos si este no se encuentraba en ella previamente
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if(u != a)
            {
                u.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }

            return u;
        }

        /// <summary>
        /// Añade un profesor a la lista de profesores
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if(u != i)
            {
                u.Instructores.Add(i);
            }

            return u;    
        }


        #endregion


    }
}
