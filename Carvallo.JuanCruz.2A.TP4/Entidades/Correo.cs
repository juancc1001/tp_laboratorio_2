using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {

        List<Thread> mockPaquetes;
        List<Paquete> paquetes;

        #region Propiedades
        /// <summary>
        /// Get: retorna la lista del atributo paquetes. Set: Asigna una List en el atributo paquetes
        /// </summary>
        public List<Paquete> Paquetes
        {
            get { return this.paquetes; }
            set { this.paquetes = value; }
        }

        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Finaliza los subprocesos de los hilos de la lista mockPaquetes
        /// </summary>
        public void FinEntregas()
        {
            foreach(Thread item in this.mockPaquetes)
            {
                if(item.IsAlive == true)
                    item.Abort();
            }
        }

        /// <summary>
        /// Muestra los datos de una interfaz IMostrar
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            string ret = "";
            foreach(Paquete p in ((Correo)elementos).Paquetes)
            {
                ret += String.Format("{0} para {1} ({2})\n", p.TrackingID, p.DireccionEntrega, p.Estado.ToString());
            }

            return ret;
        }

        #endregion

        #region Operadores

        /// <summary>
        /// Añade un paquete a la lista de Paquetes si este no se encontraba previamente
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            bool flag = true;
            foreach(Paquete item in c.Paquetes)
            {
                if(p == item)
                {
                    flag = false;
                }
            }

            if (flag == false)
            {
                throw new TrackingIdRepetidoException("El paquete ya se encuentra en la lista");
            }
            else
            {
                c.Paquetes.Add(p);
                Thread hiloPaquete = new Thread(p.MockCicloDeVida);
                c.mockPaquetes.Add(hiloPaquete);
                hiloPaquete.Start();
            }

            return c;
        }

        #endregion

    }
}
