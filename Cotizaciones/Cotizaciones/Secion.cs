using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cotizaciones
{
    public static class Secion
    {
        public static int id;
        public static string nombre;
        public static int numeroEmpleado;
        public static int departamento;

        public static bool iniciarSecion(string usuario, string contraseña)
        {
            bool conectado;
            SqlCommand comando = new SqlCommand("SELECT usu_id, usu_nombre + ' ' + usu_apellido, usu_numeroEmpleado, usu_departamento_id FROM Usuario WHERE usu_usuario = @usuario AND usu_contrasenia = @contraseña");
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@usuario", usuario);
            comando.Parameters.AddWithValue("@contraseña", contraseña);
            DataTable tabla = Conexion.LeerTablaComando(comando);
            if (tabla.Rows.Count > 0)
            {
                conectado = true;
                id = (int)tabla.Rows[0].ItemArray[0];
                nombre = (string)tabla.Rows[0].ItemArray[1];
                numeroEmpleado = (int)tabla.Rows[0].ItemArray[2];
                departamento = (int)tabla.Rows[0].ItemArray[3];
            }
            else
            {
                conectado = false;
            }

            return conectado;
        }
    }
}
