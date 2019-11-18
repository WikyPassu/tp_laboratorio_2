using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        
        public delegate void DelegadoEstado(object emisor, EventArgs evento);
        public event DelegadoEstado InformaEstado;

        /// <summary>
        /// Enumerado del estado del paquete.
        /// </summary>
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }

        /// <summary>
        /// Propiedad de lectura y escritura del Tracking ID del paquete.
        /// </summary>
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura de la direccion de entrega del paquete.
        /// </summary>
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del estado actual del paquete.
        /// </summary>
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }

        /// <summary>
        /// Constructor de la clase paquete que instancia sus datos pasados como parametro.
        /// </summary>
        /// <param name="direccionEntrega">Direccion de entrega del paquete.</param>
        /// <param name="trackingID">Tracking ID del paquete.</param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.TrackingID = trackingID;
            this.DireccionEntrega = direccionEntrega;
            this.Estado = EEstado.Ingresado;
        }

        /// <summary>
        /// Compila la informacion de un paquete.
        /// </summary>
        /// <param name="elemento">Un paquete.</param>
        /// <returns>Retorna una cadena con formato de los datos del paquete especificado.</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            string datos = "";

            if (!Object.Equals(elemento, null) && elemento is Paquete)
            {
                Paquete paquete = (Paquete)elemento;
                datos = string.Format("{0} para {1}", paquete.TrackingID, paquete.DireccionEntrega);
            }

            return datos;
        }

        /// <summary>
        /// Retorna la informacion de un paquete.
        /// </summary>
        /// <returns>Retorna una cadena con la informacion del paquete.</returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        /// <summary>
        /// Hace que un paquete cambie de estado y luego intenta guardarlo en la base de datos.
        /// </summary>
        public void MockCicloVida()
        {
            while (this.Estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);
                this.Estado += 1;
                this.InformaEstado(this, new EventArgs());
            }
            PaqueteDAO.Insertar(this);
        }

        /// <summary>
        /// Verifica si dos paquetes son iguales de acuerdo a su Tracking ID.
        /// </summary>
        /// <param name="p1">Un paquete.</param>
        /// <param name="p2">Otro paquete.</param>
        /// <returns>Retorna true si los paquetes son iguales, false caso contrario.</returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool retorno = false;

            if (!Object.Equals(p1, null) && !Object.Equals(p2, null))
            {
                if (p1.TrackingID == p2.TrackingID)
                {
                    retorno = true;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Verifica si dos paquetes son diferentes de a cuerdo a su Tracking ID.
        /// </summary>
        /// <param name="p1">Un paquete.</param>
        /// <param name="p2">Otro paquete.</param>
        /// <returns>Retorna true si los paquetes son diferentes, false caso contrario.</returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
    }
}
