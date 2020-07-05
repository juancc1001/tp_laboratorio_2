using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class PaqueteDAO
    {
        static SqlCommand comando;
        static SqlConnection conexion;

        static PaqueteDAO()
        {
            comando = new SqlCommand();
            conexion = new SqlConnection(@"Server = localhost\SQLEXPRESS; Database = correo-sp-2017; Trusted_Connection = True;");
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = conexion;
        }

        /// <summary>
        /// Guarda el paquete en la base de datos
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool Insertar(Paquete p)
        {
            bool ret = false;
            string textoC = "insert into Paquetes (direccionEntrega, trackingID, alumno) ";
            textoC += String.Format("values ('" +  p.DireccionEntrega + "', '" + p.TrackingID + "', 'Carvallo Juan Cruz')");
            try
            {
                comando.CommandText = textoC;
                conexion.Open();

                if(comando.ExecuteNonQuery() != 0)
                {
                    ret = true;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                if(conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return ret;
        }

    }
}
