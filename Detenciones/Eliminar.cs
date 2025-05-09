using System;
using System.Data.SqlClient;

namespace Detenciones
{
    public class Eliminar
    {
        public static int eliminar(int id)
        {
            int retorna = 0;
            Class1 conn = new Class1();

            using (SqlConnection conexion = new SqlConnection(conn.ObtenerConexion()))
            {
                conexion.Open();

                string query = "EXEC EliminarDetencion @id";

                using (SqlCommand comandos = new SqlCommand(query, conexion))
                {
                    comandos.Parameters.AddWithValue("@id", id);
                    retorna = comandos.ExecuteNonQuery();
                }

                return retorna;
            }
        }
    }
}