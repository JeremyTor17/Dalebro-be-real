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
    public partial class REPOLTEPRO : Form
    {
        public REPOLTEPRO()
        {
            InitializeComponent();
        }

        private void REPOLTEPRO_Load()
        {
            DataTable datos = DetencionesDAL.AllDet();

            ReportDataSource red = new ReportDataSource("DataSet2", datos);
            reportViewer2.LocalReport.DataSources.Clear();
            reportViewer2.LocalReport.DataSources.Add(red);
            reportViewer2.LocalReport.ReportPath = "Report1.rdlc";
            reportViewer2.Refresh();
        }

        private void REPOLTEPRO_Load2(object sender, EventArgs e)
        {
            REPOLTEPRO_Load();
            this.reportViewer2.RefreshReport();
        }
    }
    }

