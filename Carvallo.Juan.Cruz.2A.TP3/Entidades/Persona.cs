using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino, Extranjero
        }

        #region Atributos

        string apellido;
        int dni;
        ENacionalidad nacionalidad;
        string nombre;
        #endregion

        #region Constructores

        public Persona() { }

        public  Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) 
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region Propiedades
        /// <summary>
        /// Asigna y retorna el valor de apellido
        /// </summary>
        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = ValidarNombreApellido(value); }
        }

        /// <summary>
        /// Asigna y retorna el valor de dni
        /// </summary>
        public int DNI
        {   
            get { return this.dni; }
            set
            {
                try
                {
                    this.dni = ValidarDni(this.nacionalidad, value);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        /// <summary>
        /// Asigna y retorna el valor de nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad = value; }
        }

        /// <summary>
        /// Asigna y retorna el valor de nombre
        /// </summary>
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = ValidarNombreApellido(value); }
        }

        /// <summary>
        /// WriteOnly:Asigna el valor de dni recibiendolo como string
        /// </summary>
        public string StringToDNI
        {
            set { this.dni = ValidarDni(this.nacionalidad, value); }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Valida que el dni sea un valor válido de acuerdo a la nacionalidad
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if(nacionalidad == ENacionalidad.Argentino && (dato >0 && dato<= 89999999))
            {
                return dato;
            }else if(nacionalidad == ENacionalidad.Extranjero && (dato >= 90000000 && dato <= 99999999))
            {
                return dato;
            }
            else
            {
                throw new NacionalidadInvalidaException();
            }
        }

        /// <summary>
        /// Valida que el dni sea un formato válido
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int aux;
                
            if (Int32.TryParse(dato, out aux) == true)
            {
                return ValidarDni(nacionalidad, aux);
            }
            else
            {
                throw new DniInvalidoExcepcion();    
            }

            
        }

        /// <summary>
        /// Valida que el nombre o apellido no contenga caracteres inválidos
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        string ValidarNombreApellido(string dato)
        {
            string retorno = null;

            if((dato.All(char.IsLetter)) == true)
            {
                retorno = dato;
            }

            return retorno;
        }

        /// <summary>
        /// retorna los datos de el objeto Persona como string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.Append("NOMBRE COMPLETO: " + this.Apellido);
            retorno.AppendLine(", " + this.Nombre);
            retorno.AppendLine("NACIONALIDAD: " + this.Nacionalidad);

            return retorno.ToString();
        }

        #endregion



    }
}
