using ConsultorioDesktop.Models;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ConsultorioDesktop.Forms
{
    public partial class FrmListadoDoctores : Form
    {
        private readonly ReportViewer reporte;

        public FrmListadoDoctores()
        {
            InitializeComponent();
            //instanciamos un visor de reportes
            reporte = new ReportViewer();
            //hacemos que ocupe todo el formulario
            reporte.Dock = DockStyle.Fill;
            //agregamos visualmente el visor de reportes al formulario
            Controls.Add(reporte);
        }

        private void FrmListadoDoctores_Load(object sender, EventArgs e)
        {
            //abrumos el reporte utilizando la clase FileStream
            using var fs = new FileStream(@"..\..\..\reportes\ReporteDoctores.rdlc", FileMode.Open);

            //asignamos el archivo a la propiedad LocalReport del objeto RepoViewer
            reporte.LocalReport.LoadReportDefinition(fs);

            //buscamos los datos que va a graficar el reporte
            using var db = new ConsultorioContext();
            var doctores = db.Doctores.ToList();

            //asignamos los datos a la propiedad DataSources de Local Report utilizando un objeto de tipo ReportDataSource
            reporte.LocalReport.DataSources.Add(new ReportDataSource("DataSetDoctores", doctores));
            reporte.SetDisplayMode(DisplayMode.PrintLayout);
            reporte.RefreshReport();

        }
    }
}
