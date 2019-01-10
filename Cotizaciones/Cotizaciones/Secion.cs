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
        private static int id;

        public static bool iniciarSecion(string usuario, string contraseña)
        {
            bool conectado;
            SqlCommand comando = new SqlCommand("SELECT * FROM Usuario WHERE usu_usuario = @usuario AND usu_contrasenia = @contraseña");
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@usuario", usuario);
            comando.Parameters.AddWithValue("@contraseña", contraseña);
            DataTable tabla = Conexion.LeerTablaComando(comando);
            if (tabla.Rows.Count > 0)
            {
                conectado = true;
                id = (int)tabla.Rows[0].ItemArray[0];
            }
            else
            {
                conectado = false;
            }

            return conectado;
        }
    }
}
