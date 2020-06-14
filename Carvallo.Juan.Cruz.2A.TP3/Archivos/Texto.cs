using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {

        /// <summary>
        /// Guarda los datos en un archivo de texto en el path indicado
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;

            try
            {
                using (StreamWriter writer = new StreamWriter(archivo))
                {
                    writer.WriteLine(datos);
                    retorno = true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return retorno;
        }

        /// <summary>
        /// retorna los datos en un archivo de texto indicado
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;
            datos = "";

            try
            {
                using (StreamReader reader = new StreamReader(archivo))
                {
                    string texto;

                    while ((texto = reader.ReadLine()) != null)
                    {
                        datos = datos + "\n" + texto;
                    }
                    retorno = true;
                }

            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return retorno;
        }

    }
}
