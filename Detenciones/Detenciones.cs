using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Detenciones
{
    public class Detenciones
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public string motivo { get; set; }
        public string tipo { get; set; }
        public string estado { get; set; }
        public int Estudiante_id { get; set; }


        public Detenciones() { }

        public Detenciones(int id, DateTime fecha, string motivo, string tipo, string estado, int estudiante_id)
        {
            this.id = id;
            this.fecha = fecha;
            this.motivo = motivo;
            this.tipo = tipo;
            this.estado = estado;
            Estudiante_id = estudiante_id;
        }


    }
}
