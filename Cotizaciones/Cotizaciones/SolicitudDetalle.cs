using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cotizaciones
{
    public class SolicitudDetalle : InterfazClasesBD
    {
        public string producto { get; set; }
        public int cantidad { get; set; }
        public string rutaDibujo { get; set; }
        public string modelo { get; set; }
        public string descripcion { get; set; }
        public string comentario { get; set; }
        public string estacionTrabajo { get; set; }
        public bool urgente { get; set; }
        public int solicitud { get; set; }
        public SolicitudDetalle()
        {

        }
        public bool guardar()
        {
            bool correcto = false; 
            if (verificarDatos())
            {
                SqlCommand comando = new SqlCommand("INSERT INTO DetalleSolicitud VALUES ()");
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("", "");
            }
            return correcto;
        }
        private bool verificarDatos()
        {
            bool continuar = false;
            return continuar;
        }
    }
}
