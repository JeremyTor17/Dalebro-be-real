using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Detenciones
{
    public partial class Reportico : Form
    {
        public Reportico()
        {
            InitializeComponent();
        }

        private void Top5Reportes()
        {
            DataTable datos = DetencionesDAL.Top5Det();

            ReportDataSource red = new ReportDataSource("SexData5", datos);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(red);
            reportViewer1.LocalReport.ReportPath = "QuintetoMundial.rdlc";
            reportViewer1.Refresh();
        }

        private void Reportico_Load(object sender, EventArgs e)
        {
            Top5Reportes();
            this.reportViewer1.RefreshReport();
        }

    }
  
}

