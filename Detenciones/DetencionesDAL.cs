using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Detenciones
{
    public static class DetencionesDAL
    {
        private static Class1 conn = new Class1();

        public static int AgregarDetenciones(Detenciones detenciones)
        {
            int retorna = 0;
            using (SqlConnection conexion = new SqlConnection(conn.ObtenerConexion()))
            {
                conexion.Open();

                string query = "INSERT INTO Detenciones (fecha,motivo,tipo,estado,Estudiante_id) values('" + detenciones.fecha + "','" + detenciones.motivo + "','" + detenciones.tipo + "','" + detenciones.estado + "'," + detenciones.Estudiante_id + ")";
                using (SqlCommand comandos = new SqlCommand(query, conexion))
                {
                    retorna = comandos.ExecuteNonQuery();

                }
                return retorna;
            }
        }
        public static DataTable Refrescar()
        {
            using (SqlConnection conexion = new SqlConnection(conn.ObtenerConexion()))
            {
                DataTable dt = new DataTable();
                conexion.Open();

                string query = "SELECT * FROM Detenciones";
                using (SqlCommand comandos = new SqlCommand(query, conexion))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(comandos))
                    {
                        adapter.Fill(dt);
                        return dt;
                    }

                }
            }
        }

        public static DataTable Top5Det()
        {
            DataTable jer = new DataTable();

            using (SqlConnection conexion = new SqlConnection(conn.ObtenerConexion()))
            {
                string query = @"SELECT TOP 5 
                E.id AS ID_Estudiante,
                E.nombre AS Nombre,
                COUNT(D.id) AS TotalDetenciones
            FROM 
                Detenciones D
            INNER JOIN 
                Estudiantes E ON D.Estudiante_id = E.id
            GROUP BY 
                E.id, E.nombre
            ORDER BY 
                TotalDetenciones DESC;
                ";

                SqlCommand comandos = new SqlCommand(query, conexion);
                SqlDataAdapter datos = new SqlDataAdapter(comandos);
                datos.Fill(jer);
            }
            return jer;
        }

        public static DataTable AllDet()
        {
            DataTable jere = new DataTable();

            using (SqlConnection conexion = new SqlConnection(conn.ObtenerConexion()))
            {
                string query = @"SELECT 
                E.nombre,
                COUNT(D.id) AS total_detenciones
                FROM Detenciones D
                JOIN Estudiantes E ON D.Estudiante_id = E.id
                GROUP BY E.nombre;
";

                SqlCommand comandos = new SqlCommand(query, conexion);
                SqlDataAdapter datos = new SqlDataAdapter(comandos);
                datos.Fill(jere);

            }
            return jere;
        }
    }
}