using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Cotizaciones
{
    class TipoDeUsuario
    {
        public static DataTable obtenerTipoUsuario()
        {
            return Conexion.LeerTabla("SELECT tusu_id, tusu_nombre FROM TipoUsuario");
        }
    }
}
