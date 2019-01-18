using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Cotizaciones
{
    public class Conexion
    {
        #region "atributos"

        private static string cadenaConexion = "Data Source=SQL5006.site4now.net;Initial Catalog=DB_A4455B_Requisiciones;User Id=DB_A4455B_Requisiciones_admin;Password=Megabanilike1;";

        private static SqlConnection _conexion = new SqlConnection();
        #endregion

        #region "metodos"

        /// <summary>
        /// Conexion a BD
        /// </summary>
        /// <returns>conectado TRUE/FALSE</returns>
        /// <remarks></remarks>
        private static bool Conectar()
        {
            bool conectado = false;
            if (_conexion.State == ConnectionState.Open)
            {
                _conexion.Close();
            }

            try
            {

                _conexion.ConnectionString = cadenaConexion;
                _conexion.Open();
                conectado = true;

            }
            catch (SqlException ex)
            {
            }

            return conectado;

        }

        /// <summary>
        /// Desconecta la BD
        /// </summary>
        /// <remarks></remarks>

        private static void Desconectar()
        {
            if (_conexion.State == ConnectionState.Open)
            {
                _conexion.Close();
            }
        }

        /// <summary>
        /// Leer tabla 
        /// </summary>
        /// <param name="consulta"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static DataTable LeerTabla(string consulta)
        {
            DataTable tabla = new DataTable();

            if (Conectar())
            {
                SqlCommand comando = new SqlCommand(consulta, _conexion);
                comando.CommandTimeout = 0;
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                try
                {
                    adaptador.Fill(tabla);
                }
                catch (SqlException ex)
                {
                }
                Desconectar();
            }
            return tabla;
        }

        /// <summary>
        /// Leer Tabla Comando
        /// </summary>
        /// <param name="comando"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static DataTable LeerTablaComando(SqlCommand comando)
        {

            DataTable tabla = new DataTable();

            if (Conectar())
            {
                try
                {
                    comando.Connection = _conexion;
                    comando.CommandTimeout = 0;
                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    adaptador.Fill(tabla);
                }
                catch (SqlException ex)
                {
                }
                Desconectar();
            }

            return tabla;
        }


        /// <summary>
        /// Leer registro
        /// </summary>
        /// <param name="consulta"></param>
        /// <returns>registro</returns>
        /// <remarks></remarks>
        public static DataRow LeerRegistro(string consulta)
        {
            DataRow registro = default(DataRow);
            registro = null;

            DataTable tabla = LeerTabla(consulta);

            if (tabla.Rows.Count > 0)
            {
                registro = tabla.Rows[0];
            }

            return registro;
        }

        /// <summary>
        /// Ejecutar instruccion
        /// </summary>
        /// <param name="instruccion"></param>
        /// <returns>ejecuto</returns>
        /// <remarks></remarks>
        public static bool EjecutarInstruccion(string instruccion)
        {
            bool ejecutado = false;
            ejecutado = false;

            if (Conectar())
            {
                try
                {
                    SqlCommand comando = new SqlCommand(instruccion, _conexion);

                    comando.ExecuteNonQuery();

                    ejecutado = true;

                }
                catch (SqlException ex)
                {
                }
                Desconectar();
            }

            return ejecutado;
        }

        /// <summary>
        /// Ejecutar Comando
        /// </summary>
        /// <param name="comando"></param>
        /// <returns>ejecuto</returns>
        /// <remarks></remarks>
        public static bool EjecutarComando(SqlCommand comando)
        {
            bool ejecuto = false;

            if (Conectar())
            {
                try
                {
                    comando.Connection = _conexion;

                    comando.ExecuteNonQuery();

                    ejecuto = true;

                }
                catch (SqlException ex)
                {
                }
                Desconectar();
            }

            return ejecuto;
        }

        /// <summary>
        /// Ejecutar procedimiento
        /// </summary>
        /// <param name="comando"></param>
        /// <returns>ejecuto</returns>
        /// <remarks></remarks>
        public static bool EjecutarProcedimiento(SqlCommand comando)
        {
            bool ejecuto = false;

            if (Conectar())
            {
                try
                {
                    comando.Connection = _conexion;
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.ExecuteNonQuery();

                    ejecuto = true;

                }
                catch (SqlException ex)
                {
                }
                Desconectar();
            }

            return ejecuto;
        }

        /// <summary>
        /// Ejecutar comando Ultimo ID
        /// </summary>
        /// <param name="storedProcedure">nombre de stored procedure</param>
        /// <param name="parametros">lista de parametros</param>
        /// <returns>ID</returns>
        /// <remarks></remarks>
        //public static int EjecutarProcedimientoOutError(string storedProcedure, List<Parametro> parametros)
        //{

        //	SqlCommand comando = new SqlCommand(storedProcedure);
        //	int parametroError = 0;
        //	if (Conectar()) {

        //		try {
        //			SqlParameter parametross = new SqlParameter("error", DbType.Int32);
        //			parametross.Direction = ParameterDirection.Output;

        //			comando.Connection = _conexion;
        //			comando.CommandType = CommandType.StoredProcedure;

        //			foreach (Parametro item in parametros) {
        //				comando.Parameters.Add(new SqlParameter(item.Nombre, item.Valor));
        //			}

        //			comando.Parameters.Add(parametross);

        //			comando.ExecuteNonQuery();


        //			parametroError = Int32.Parse(comando.Parameters["error"].Value.ToString());


        //		} catch (SqlException ex) {
        //		}
        //		Desconectar();
        //	}

        //	return parametroError;
        //}


        #endregion
    }
}
