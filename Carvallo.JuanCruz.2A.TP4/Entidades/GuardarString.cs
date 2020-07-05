using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class GuardarString
    {
        /// <summary>
        /// Guarda el string en el archivo, si este existe
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public static bool Guardar(this string texto, string archivo)
        {
            bool rta = false;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path += String.Format(@"\" + archivo);

            if (File.Exists(path) == true)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(@path, true, Encoding.UTF8))
                    {
                        sw.WriteLine(texto);
                    }
                    rta = true;

                }catch(Exception e)
                {
                    throw e;
                }
            }

            return rta;
        }




    }
}
