using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cotizaciones
{
    public class Departamento
    {
        public string nombre;
        public Departamento(int id)
        {
            DataRow registro = Conexion.LeerRegistro("SELECT dpto_nombre FROM Departamento WHERE dpto_id = " + id + "");
            nombre = registro.ItemArray[0].ToString();
        }
        public static DataTable obtenerDepartamentos()
        {
           return Conexion.LeerTabla("select *from departamento");
        }
           
    }
}
