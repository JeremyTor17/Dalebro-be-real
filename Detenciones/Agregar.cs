using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Detenciones
{
    public class Agregar
    {
        public void agregar(Detenciones detenciones)
        {
            int retorna = 0;
            Class1 conn = new Class1();
            using (SqlConnection conexion = new SqlConnection(conn.ObtenerConexion()))

            {
                conexion.Open();
            }
        }
    }
}
