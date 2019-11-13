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
    public partial class FrmPpal : Form
    {
        private Correo correo;

        public FrmPpal()
        {
            InitializeComponent();
            this.correo = new Correo();
            this.Text = "Correo UTN por Alan.Passucci.2A";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.rtbMostrar.Enabled = false;
            this.FormClosing += new FormClosingEventHandler(FrmPpal_FormClosing);
        }
        
        private void ActualizarEstados()
        {
            this.lstEstadoIngresado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoEntregado.Items.Clear();
            foreach (Paquete paquete in this.correo.Paquetes)
            {
                if (paquete.Estado == Paquete.EEstado.Ingresado)
                {
                    this.lstEstadoIngresado.Items.Add(paquete);
                }
                else if (paquete.Estado == Paquete.EEstado.EnViaje)
                {
                    this.lstEstadoEnViaje.Items.Add(paquete);
                }
                else
                {
                    this.lstEstadoEntregado.Items.Add(paquete);
                }
            }
        }

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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Paquete nuevoPaquete = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text);
                nuevoPaquete.InformaEstado += new Paquete.DelegadoEstado(paq_InformaEstado); //Revisar.
                this.correo += nuevoPaquete;
                this.ActualizarEstados();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Paquete repetido", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
        //Revisar.
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (!Object.Equals(elemento, null))
            {
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
                GuardaString.Guardar(this.rtbMostrar.Text, "salida.txt");
            }
        }

        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntrega();
        }
    }
}
