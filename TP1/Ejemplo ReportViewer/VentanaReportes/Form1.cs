using PoryectoReporte;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace VentanaReportes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            List<Persona> Agregar = new List<Persona>();
            Agregar.Add(new Persona { Nombre = "Augusto", Apellido = "De Lisio", Correo = "augustodelisio@gmail.com"});
            Agregar.Add(new Persona { Nombre = "Ignacio", Apellido = "Cabanellas", Correo = "ignaciocabanellas@gmail.com" });
            Agregar.Add(new Persona { Nombre = "Mariano", Apellido = "O shea", Correo = "marianooshea@gmail.com" });
            Agregar.Add(new Persona { Nombre = "Augusto", Apellido = "De Lisio", Correo = "augustodelisio@gmail.com" });
            Agregar.Add(new Persona { Nombre = "Ignacio", Apellido = "Cabanellas", Correo = "ignaciocabanellas@gmail.com" });
            Agregar.Add(new Persona { Nombre = "Mariano", Apellido = "O shea", Correo = "marianooshea@gmail.com" });

            ///Mostrar datos en el reporte
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "VentanaReportes.Reporte.rdlc";
            ReportDataSource rds1 = new ReportDataSource("Personas", Agregar);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds1);
            this.reportViewer1.RefreshReport();

        }
    }
}
