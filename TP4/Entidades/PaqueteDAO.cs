using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlConnection conexion;
        private static SqlCommand comando;

        /// <summary>
        /// Constructor estatico de la clase PaqueteDAO que instancia la conexion, el comando y sus caracteristicas.
        /// </summary>
        static PaqueteDAO()
        {
            PaqueteDAO.conexion = new SqlConnection(Properties.Settings.Default.Conexion);
            PaqueteDAO.comando = new SqlCommand();
            PaqueteDAO.comando.Connection = PaqueteDAO.conexion;
            PaqueteDAO.comando.CommandType = CommandType.Text;
        }

        /// <summary>
        /// Guarda los datos de un paquete en la base de datos [correo-sp-2017].dbo.Paquetes
        /// </summary>
        /// <param name="p">Paquete a guardar.</param>
        /// <returns>Retorna true si se pudo establecer conexion y se pudieron guardar los datos del paquete, false caso contrario.</returns>
        public static bool Insertar(Paquete p)
        {
            bool retorno = false;

            try
            {
                PaqueteDAO.conexion.Open();
                PaqueteDAO.comando.CommandText = "INSERT INTO [correo-sp-2017].dbo.Paquetes(direccionEntrega, trackingID, alumno) VALUES('" + p.DireccionEntrega + "', '" + p.TrackingID + "', 'Passucci Alan')";
                PaqueteDAO.comando.ExecuteNonQuery();
                retorno = true;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error al agregar paquete a la base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                PaqueteDAO.conexion.Close();
            }

            return retorno;
        }
    }
}
