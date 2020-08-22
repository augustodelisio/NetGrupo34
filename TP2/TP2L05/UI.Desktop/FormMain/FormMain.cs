using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
