using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cotizaciones
{
    public static class TipoDePedidos
    {
        public static DataTable obtenerDatosPedido()
        {
            return Conexion.LeerTabla("SELECT tPed_id, tPed_nombre FROM tipoPedido");
        }
    }
}
