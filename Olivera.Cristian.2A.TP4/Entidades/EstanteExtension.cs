using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Entidades
{
    public static class Extensora
    {
        #region metodos
        /// <summary>
        /// Metodo de extension que permite eliminar un elemento de la base de datos
        /// </summary>
        /// <param name="c"></param>
        /// <param name="id"></param>
        /// <returns>retorna true si se elimino, caso contrario false</returns>
        public static bool EliminarFruta(this Estante<Manzana> c, int id)
        {
            bool retorno = false;

            try
            {

                using (SqlConnection sqlConexion = new SqlConnection(Properties.Settings.Default.Conexion))
                {
                    sqlConexion.Open();
                    SqlCommand comando = new SqlCommand();
                    comando.Connection = sqlConexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "DELETE FROM frutas WHERE id = @id ";
                    comando.Parameters.AddWithValue("@id", id);
                    int filas = comando.ExecuteNonQuery();

                    if (filas != 0)
                    {
                        retorno = true;
                    }


                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return retorno;

        }
        #endregion

    }
}
