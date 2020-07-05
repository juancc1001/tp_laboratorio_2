using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        public enum EEstado
        {
            Ingresado, EnViaje, Entregado
        }

        #region Atributos

        string direccionEntrega;
        EEstado estado;
        string trackingID;
        #endregion

        public Paquete(string direccionEntrega, string trackingId)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingId;
        }

        public event DelegadoEstado InformaEstado;

        public delegate void DelegadoEstado(object sender, EventArgs e);

        #region Propiedades
        /// <summary>
        /// Get: retorna la direccion de entrega, Set: asigna el valor al atributo direccionEntrega
        /// </summary>
        public string DireccionEntrega
        {
            get { return this.direccionEntrega; }
            set { this.direccionEntrega = value; }
        }

        /// <summary>
        /// Get: retorna el estado del paquete, Set: asigna el valor al atributo estado
        /// </summary>
        public EEstado Estado
        {
            get { return this.estado; }
            set { this.estado = value;  }
        }

        /// <summary>
        /// Get: retorna el tracking ID, Set: asigna el valor al atributo trackingID
        /// </summary>
        public string TrackingID
        {
            get { return this.trackingID; }
            set { this.TrackingID = value; }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muestra los datos del paquete
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete p = (Paquete)elemento;
            return String.Format("{0} para {1}", p.trackingID, p.direccionEntrega);
        }

        /// <summary>
        /// Asigna el estado del paquete y lo cambia cada 4 segundos
        /// </summary>
        public void MockCicloDeVida()
        {
            int cont = 0;

            while (cont <= 2)
            {
                this.Estado = (EEstado)cont;
                this.InformaEstado.Invoke(this, EventArgs.Empty);
                Thread.Sleep(4000);
                cont++;
            }

            PaqueteDAO.Insertar(this);
        }

        /// <summary>
        /// Retorna los datos del paquete en formato string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        #endregion

        #region Operadores

        /// <summary>
        /// Dos paquetes son iguales si tienen el mismo tracking ID
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool ret = false;
            if(p1.TrackingID == p2.TrackingID)
            {
                ret = true;
            }
            
            return ret;
        }

        /// <summary>
        /// Dos paquetes son iguales si tienen el mismo tracking ID
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        #endregion

    }
}
