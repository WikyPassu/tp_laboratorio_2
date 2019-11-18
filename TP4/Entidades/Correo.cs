using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        /// <summary>
        /// Propiedad de lectura y escritura de la lista de paquetes del correo.
        /// </summary>
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }

        /// <summary>
        /// Constructor de la clase correo que instancia las listas que tiene como atributos.
        /// </summary>
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }
        
        /// <summary>
        /// Compila la informacion de todos los paquetes de un correo.
        /// </summary>
        /// <param name="elementos">Lista de paquetes.</param>
        /// <returns>Retorna una cadena con formato de los datos de cada paquete en la lista.</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder datos = new StringBuilder();

            if (!Object.Equals(elementos, null) && elementos is Correo)
            {
                List<Paquete> listaPaquetes = ((Correo)elementos).Paquetes;

                foreach (Paquete p in listaPaquetes)
                {
                    datos.AppendLine(string.Format("{0} para {1} ({2})", p.TrackingID, p.DireccionEntrega, p.Estado.ToString()));
                }
            }
            
            return datos.ToString();
        }

        /// <summary>
        /// Cierra todos los hilos activos.
        /// </summary>
        public void FinEntrega()
        {
            foreach (Thread hilo in this.mockPaquetes)
            {
                if (!Object.Equals(hilo, null))
                {
                    if (hilo.IsAlive)
                    {
                        hilo.Abort();
                    }
                }
            }
        }

        /// <summary>
        /// Agrega un paquete a la lista de paquetes del correo previa verificacion.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            if (!Object.Equals(c, null) && !Object.Equals(p, null))
            {
                Thread hilo = new Thread(p.MockCicloVida);

                foreach (Paquete paquete in c.Paquetes)
                {
                    if (paquete == p)
                    {
                        throw new TrackingIdRepetidoException("El Tracking ID " + p.TrackingID + " ya figura en la lista de envios.");
                    }
                }

                c.Paquetes.Add(p);
                c.mockPaquetes.Add(hilo);
                hilo.Start();
            }

            return c;
        }
    }
}
