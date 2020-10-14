using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Desktop.FormReportes;

namespace UI.Desktop
{
    public partial class FormMain : ApplicationForm
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            FormLogin appLogin = new FormLogin();
            if (appLogin.ShowDialog() != DialogResult.OK)
            {
                this.Dispose();
            }
        }

        private void administrarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuarios ABMUsuarios = new Usuarios();
            ABMUsuarios.ShowDialog();
        }

        private void administrarEspecialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Especialidades ABMEspecialidades = new Especialidades();
            ABMEspecialidades.ShowDialog();
        }

        private void administrarPlanesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Planes ABMPlanes = new Planes();
            ABMPlanes.ShowDialog();
        }

        private void administrarPersonasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Personas ABMPersonas = new Personas();
            ABMPersonas.ShowDialog();
        }

        private void tiposDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TiposUsuarios ABMTiposUsu = new TiposUsuarios();
            ABMTiposUsu.ShowDialog();
        }

        private void administrarMateriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Materias ABMMaterias = new Materias();
            ABMMaterias.ShowDialog();
        }

        private void generarReporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reportes Rep = new Reportes();
            Rep.ShowDialog();
        }

        private void verCursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursos ABMCur = new Cursos();
            ABMCur.ShowDialog();
        }

        private void verComisionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Comisiones ABMCom = new Comisiones();
            ABMCom.ShowDialog();
        }
    }
}
