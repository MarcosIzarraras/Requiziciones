using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cotizaciones
{
    public class Solicitud
    {
        public int id { get; set; }
        public int tipoPedido { get; set; }
        public int cotizador { get; set; }
        public int solicitante { get; set; }
        public int estatus { get; set; }

        public Solicitud()
        {

        }
        public bool guardar()
        {
            bool completo = false;
            if(verificarCampos())
            {
                SqlCommand comando = new SqlCommand("INSERT INTO Solicitud VALUES (@fecha, @tipoPeido, @cotizador, @solicitante, @estatus)");
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@fecha", DateTime.Now);
                comando.Parameters.AddWithValue("@tipoPedido", tipoPedido);
                comando.Parameters.AddWithValue("@cotizador", cotizador);
                comando.Parameters.AddWithValue("@solicitante", solicitante);
                comando.Parameters.AddWithValue("@estatus", estatus);

                completo = Conexion.EjecutarComando(comando);
            }

            return completo;
        }

        private bool verificarCampos()
        {
            bool continuar = true;
            continuar = (continuar) ? tipoPedido == 0 : continuar;
            continuar = (continuar) ? cotizador == 0 : continuar;
            continuar = (continuar) ? solicitante == 0 : continuar;
            continuar = (continuar) ? estatus == 0 : continuar;

            return continuar;
        }
    }
}
