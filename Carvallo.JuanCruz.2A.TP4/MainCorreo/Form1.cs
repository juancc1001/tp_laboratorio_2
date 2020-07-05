using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class Form1 : Form
    {
        Correo correo;

        public Form1()
        {
            InitializeComponent();
            this.correo = new Correo();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lstEstadoEntregado_Click(object sender, EventArgs e)
        {

        }
    
        /// <summary>
        /// Invoca el metodo ActualizarEstados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }
    
        /// <summary>
        /// Actualiza las List Box de paquetes segun corresponda
        /// </summary>
        private void ActualizarEstados()
        {
            this.lstEstadoIngresado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoEntregado.Items.Clear();

            foreach(Paquete item in correo.Paquetes)
            {
                if(item.Estado == Paquete.EEstado.Ingresado)
                {
                    this.lstEstadoIngresado.Items.Add(item);

                }else if(item.Estado == Paquete.EEstado.EnViaje)
                {
                    this.lstEstadoEnViaje.Items.Add(item);
                }
                else if (item.Estado == Paquete.EEstado.Entregado)
                {
                    this.lstEstadoEntregado.Items.Add(item);
                }
            }
        }

        /// <summary>
        /// Muestra los datos del elemento en el RichTextBox y guarda el texto creado.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            string aux;

            if(elemento != null)
            {
                aux = elemento.MostrarDatos(elemento);
                this.rtbMostrar.Text = aux;
                aux.Guardar("salida.txt");
            }
        }

        /// <summary>
        /// Evento click del boton Agregar. crea el paquete con los datos y lo añade a la lista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete p = new Paquete(this.txbDireccion.Text, this.mtxtTrackingID.Text);
            p.InformaEstado += paq_InformaEstado;

            try
            {
                this.correo = this.correo + p;

            }catch(TrackingIdRepetidoException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("Ha surgido un error al agregar el paquete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.ActualizarEstados();
        }

        /// <summary>
        /// Cierre del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }

        /// <summary>
        /// Evento click del boton 'Mostrar Todos', muestra los datos de los paqutes en el rich text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// Evento mostrar del Tool Strip Menu, muestra los datos del paquete seleccionado en el rich text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }
    }

}
