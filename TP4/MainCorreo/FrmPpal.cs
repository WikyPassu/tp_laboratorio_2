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

        /// <summary>
        /// Constructor del formulario principal de la aplicacion.
        /// </summary>
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
        
        /// <summary>
        /// Actualiza las listas de paquetes segun su estado.
        /// </summary>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">Emisor.</param>
        /// <param name="e">Evento.</param>
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
        /// Agrega un nuevo paquete al sistema.
        /// </summary>
        /// <param name="sender">Emisor.</param>
        /// <param name="e">Evento.</param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Paquete nuevoPaquete = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text);
                nuevoPaquete.InformaEstado += new Paquete.DelegadoEstado(paq_InformaEstado); //Revisar.
                this.correo += nuevoPaquete;
                this.ActualizarEstados();
            }
            catch (TrackingIdRepetidoException error)
            {
                MessageBox.Show(error.Message, "Paquete repetido", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
        
        /// <summary>
        /// Muestra la informacion de todos los paquetes.
        /// </summary>
        /// <param name="sender">Emisor.</param>
        /// <param name="e">Evento.</param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// Muestra la informacion del paquete seleccionado en la lista de paquetes entregados.
        /// </summary>
        /// <param name="sender">Emisor.</param>
        /// <param name="e">Evento.</param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        /// <summary>
        /// Muestra los datos de un objeto en el RichTextBox.
        /// </summary>
        /// <typeparam name="T">Cualquier tipo de objeto.</typeparam>
        /// <param name="elemento">Un objeto del tipo T.</param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (!Object.Equals(elemento, null))
            {
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
                this.rtbMostrar.Text.Guardar("salida.txt");
            }
        }

        /// <summary>
        /// Al cerrarse la ventana, llamara al metodo que cierra todos los hilos activos.
        /// </summary>
        /// <param name="sender">Emisor.</param>
        /// <param name="e">Evento.</param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntrega();
        }
    }
}
