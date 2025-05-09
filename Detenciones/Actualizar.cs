using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Detenciones
{
    public class Actualizar
    {
        public static int actualizar(Detenciones detenciones)
        {
            int retorna = 0;
            Class1 conn = new Class1();

            using (SqlConnection conexion = new SqlConnection(conn.ObtenerConexion()))
            {
                conexion.Open();

                string query = "EXEC ActualizarDetencion @id, @fecha, @motivo, @tipo, @estado, @estudiante_id";

                using (SqlCommand comandos = new SqlCommand(query, conexion))
                {
                    comandos.Parameters.AddWithValue("@id", detenciones.id);
                    comandos.Parameters.AddWithValue("@fecha", detenciones.fecha);
                    comandos.Parameters.AddWithValue("@motivo", detenciones.motivo);
                    comandos.Parameters.AddWithValue("@tipo", detenciones.tipo);
                    comandos.Parameters.AddWithValue("@estado", detenciones.estado);
                    comandos.Parameters.AddWithValue("@estudiante_id", detenciones.Estudiante_id);

                    retorna = comandos.ExecuteNonQuery();
                }

                return retorna;

            }

        }


    }
}
