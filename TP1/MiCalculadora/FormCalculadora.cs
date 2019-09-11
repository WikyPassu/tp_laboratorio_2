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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            lblResultado.Text = "";
            txtNumero1.Clear();
            txtNumero2.Clear();
            cmbOperador.SelectedItem = null;
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero numeroUno = new Numero(numero1);
            Numero numeroDos = new Numero(numero2);
            
            return Calculadora.Operar(numeroUno, numeroDos, operador);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            //string resultadoActual = Convert.ToString(Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text));
            lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            //string resultadoActual = Convert.ToString(Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text));
            lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
        }
    }
}
