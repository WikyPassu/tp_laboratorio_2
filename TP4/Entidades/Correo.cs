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

        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }

        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            string datos = "";

            foreach (Paquete paquete in this.Paquetes)
            {
                datos += string.Format("{0} para {1} ({2})\n", paquete.TrackingID, paquete.DireccionEntrega, paquete.Estado.ToString());
            }

            return datos;
        }

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

        public static Correo operator +(Correo c, Paquete p)
        {
            if (!Object.Equals(c, null) && !Object.Equals(p, null))
            {
                foreach (Paquete paquete in c.Paquetes)
                {
                    if (paquete != p)
                    {
                        c.Paquetes.Add(p);
                        Thread hilo = new Thread(p.MockCicloVida);
                        c.mockPaquetes.Add(hilo);
                        hilo.Start();
                    }
                    else
                    {
                        throw new TrackingIdRepetidoException("Paquete repetido.");
                    }
                }
            }

            return c;
        }
    }
}
