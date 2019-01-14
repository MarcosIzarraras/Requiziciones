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
        public int cantidad { get; set; }
        public string rutaDibujo { get; set; }
        public string modelo { get; set; }
        public string descripcion { get; set; }
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
                solicitud = (int)Conexion.LeerRegistro("SELECT sol_id FROM Solicitud ORDER BY sol_id DESC")[0];

                SqlCommand comando = new SqlCommand("INSERT INTO DetalleSolicitud VALUES (@cantidad, @ruta, @modelo, @descripcion, @estacion, @urgente, @solicitud)");
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@cantidad", cantidad);
                comando.Parameters.AddWithValue("@ruta", rutaDibujo);
                comando.Parameters.AddWithValue("@modelo", modelo);
                comando.Parameters.AddWithValue("@descripcion", descripcion);
                comando.Parameters.AddWithValue("@estacion", estacionTrabajo);
                comando.Parameters.AddWithValue("@urgente", urgente);
                comando.Parameters.AddWithValue("@solicitud", solicitud);

                correcto = Conexion.EjecutarComando(comando);
            }
            return correcto;
        }
        private bool verificarDatos()
        {
            bool continuar = true;
            return continuar;
        }
    }
}
