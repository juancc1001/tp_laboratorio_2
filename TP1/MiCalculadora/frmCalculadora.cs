using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP1;

namespace MiCalculadora
{
    public partial class frmCalculadora : Form
    {
        public frmCalculadora()
        {
            InitializeComponent();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            string numero1 = txtNumero1.Text;
            string numero2 = txtNumero2.Text;
            string operador = cmbOperador.Text;
            double resultado = Operar(numero1, numero2, operador);

            lblResultado.Text = resultado.ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string resultado = lblResultado.Text;
            resultado = Numero.DecimalBinario(resultado);

            lblResultado.Text = resultado;
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string resultado = lblResultado.Text;
            resultado = Numero.BinarioDecimal(resultado);

            lblResultado.Text = resultado;
        }


        //Methods
        #region

        static double Operar (string numero1, string numero2, string operador)
        {
            double retorno;
            Numero n1 = new Numero(numero1);
            Numero n2 = new Numero(numero2);

            retorno = Calculadora.Operar(n1, n2, operador);

            return retorno;
        }

        void Limpiar()
        {
            this.lblResultado.Text = "";
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.Text = "";
        }











        #endregion






    }
}
