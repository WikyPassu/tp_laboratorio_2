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
        //Revisar.
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            string datos = "";

            foreach (Paquete p in ((Correo)elementos).Paquetes)
            {
                datos += string.Format("{0} para {1} ({2})\n", p.TrackingID, p.DireccionEntrega, p.Estado.ToString());
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
            bool noExiste = false;

            if (!Object.Equals(c, null) && !Object.Equals(p, null))
            {
                if (c.Paquetes.Count == 0)
                {
                    c.Paquetes.Add(p);
                    Thread hilo = new Thread(p.MockCicloVida);
                    c.mockPaquetes.Add(hilo);
                    hilo.Start();
                }
                else
                {
                    foreach (Paquete paquete in c.Paquetes)
                    {
                        if (paquete != p)
                        {
                            noExiste = true;
                        }
                        else
                        {
                            throw new TrackingIdRepetidoException("El Tracking ID " + p.TrackingID + " ya figura en la lista de envios.");
                        }
                    }
                }

                if (noExiste)
                {
                    c.Paquetes.Add(p);
                    Thread hilo = new Thread(p.MockCicloVida);
                    c.mockPaquetes.Add(hilo);
                    hilo.Start();
                }
            }

            return c;
        }
    }
}
