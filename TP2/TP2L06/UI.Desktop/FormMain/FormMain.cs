using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Desktop;

namespace UI.Desktop
{
    public partial class FormMain : ApplicationForm
    {
        public int IdUsu { get; set; }
        public int Tipo { get; set; }
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
            else
            {
                IdUsu = appLogin.IdUsu;
                Tipo = appLogin.Tipo;
                segunUsuario();
            }
        }

        private void segunUsuario()
        {
            if (Tipo == 1) //Admin
            {
                miPerfilToolStripMenuItem.Enabled = false;
                miPerfilToolStripMenuItem.Visible = false;
                inscribirmeToolStripMenuItem.Enabled = false;
                inscribirmeToolStripMenuItem.Visible = false;
            }
            else //Alumno o Docente
            {
                usuariosToolStripMenuItem.Enabled = false;
                usuariosToolStripMenuItem.Visible = false;
                especialidadesToolStripMenuItem.Enabled = false;
                especialidadesToolStripMenuItem.Visible = false;
                planesToolStripMenuItem.Enabled = false;
                planesToolStripMenuItem.Visible = false;
                personasToolStripMenuItem.Enabled = false;
                personasToolStripMenuItem.Visible = false;
                materiasToolStripMenuItem.Enabled = false;
                materiasToolStripMenuItem.Visible = false;
                reportesToolStripMenuItem.Enabled = false;
                reportesToolStripMenuItem.Visible = false;
                verCursosToolStripMenuItem.Enabled = false;
                verCursosToolStripMenuItem.Visible = false;
                alumnosInscriptosToolStripMenuItem.Enabled = false;
                alumnosInscriptosToolStripMenuItem.Visible = false;
                docentesInscriptosToolStripMenuItem.Enabled = false;
                docentesInscriptosToolStripMenuItem.Visible = false;
                comisionesToolStripMenuItem.Enabled = false;
                comisionesToolStripMenuItem.Visible = false;
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
            FormREPORTE Rep = new FormREPORTE();
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

        private void configurarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MiPerfil editarPerfil = new MiPerfil(IdUsu, ApplicationForm.ModoForm.Modificacion);
            editarPerfil.ShowDialog();
        }

        private void cursosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void inscribirmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MateriasInscrip ABMMateriasInscrip = new MateriasInscrip(IdUsu);
            ABMMateriasInscrip.ShowDialog();
        }
    }
}
