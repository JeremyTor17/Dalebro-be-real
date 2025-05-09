using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Detenciones
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void RefrescarPantalla()
        {
            dataGridView1.DataSource = DetencionesDAL.Refrescar();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            txtEstudiante.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Estudiante_id"].Value);
            txtTipoDetencion.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["tipo"].Value);
            txtMotivo.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["motivo"].Value);
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["fecha"].Value);
            txtEstado.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["estado"].Value);
            txtDetencion.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["id"].Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMotivo.Text) || string.IsNullOrEmpty(txtEstudiante.Text) || string.IsNullOrEmpty(txtEstado.Text) || string.IsNullOrEmpty(txtDetencion.Text) || string.IsNullOrEmpty(dateTimePicker1.Text) || string.IsNullOrEmpty(txtTipoDetencion.Text))
            {
                MessageBox.Show("Error");
                return;
            }

            Detenciones detenciones = new Detenciones(
                0,
                Convert.ToDateTime(dateTimePicker1.Text),
                (txtMotivo.Text),
                (txtTipoDetencion.Text),
                (txtEstado.Text),
                Convert.ToInt32(txtDetencion.Text)
            );

            int result = DetencionesDAL.AgregarDetenciones(detenciones);

            if (result > 0)
            {
                MessageBox.Show("Exito al agregar");
            }   
            else
            {
                MessageBox.Show("No se pudo agregar");

            }

            RefrescarPantalla();
        }


        private void Form1_Load_1(object sender, EventArgs e)
        {
            RefrescarPantalla();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione una fila primero.");
                    return;
                }

                Detenciones detenciones = new Detenciones();

                detenciones.Estudiante_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Estudiante_id"].Value);
                detenciones.fecha = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["fecha"].Value);
                detenciones.tipo = Convert.ToString(dataGridView1.CurrentRow.Cells["tipo"].Value);
                detenciones.motivo = Convert.ToString(dataGridView1.CurrentRow.Cells["motivo"].Value);
                detenciones.estado = Convert.ToString(dataGridView1.CurrentRow.Cells["estado"].Value);
                detenciones.id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);

                int result = Actualizar.actualizar(detenciones);

                if (result > 0)
                {
                    MessageBox.Show("Registro actualizado con éxito.");
                    RefrescarPantalla();
                }
                else
                {
                    MessageBox.Show("No se actualizó ningún registro.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtEstudiante.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Estudiante_id"].Value);
            txtTipoDetencion.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["tipo"].Value);
            txtMotivo.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["motivo"].Value);
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["fecha"].Value);
            txtEstado.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["estado"].Value);
            txtDetencion.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["id"].Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reportico Top5 = new Reportico();
            Top5.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            REPOLTEPRO AllDet = new REPOLTEPRO();
            AllDet.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Eliminar.eliminar(Convert.ToInt32(txtDetencion.Text));
            MessageBox.Show("Registro Eliminado");
            RefrescarPantalla();
        }
    }
}