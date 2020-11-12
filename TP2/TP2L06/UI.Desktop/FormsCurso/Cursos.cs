using Business.Entities;
using Business.Logic;
using System;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class Cursos : ApplicationForm
    {
        public Cursos()
        {
            InitializeComponent();
            dgvCursos.AutoGenerateColumns = false;
        }
        public void Listar()
        {
            try
            {
                CursoLogic ul = new CursoLogic();
                this.dgvCursos.DataSource = ul.GetAll();
                FormatoDGV.ActualizaColor(dgvCursos);
            }
            catch (Exception Ex)
            {
                Notificar("Error de carga de cursos", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cursos_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            CursoDesktop formCurso = new CursoDesktop(ApplicationForm.ModoForm.Alta);
            formCurso.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvCursos.SelectedRows.Count > 0)
            {
                int ID = ((Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).IdCurso;
                CursoDesktop formCurso = new CursoDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formCurso.ShowDialog();
                this.Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).IdCurso;
            bool hab = ((Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).Habilitado;

            CursoDesktop formCurso;
            if (hab == true)
            { formCurso = new CursoDesktop(ID, ApplicationForm.ModoForm.Baja); }
            else
            { formCurso = new CursoDesktop(ID, ApplicationForm.ModoForm.CancelaBaja); }

            formCurso.ShowDialog();
            this.Listar();
        }

        private void dgvCursos_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (this.dgvCursos.SelectedRows.Count > 0)
            {
                bool hab = ((Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).Habilitado;
                if (hab == false)
                { tsbEliminar.Image = Properties.Resources.apply.ToBitmap(); }
                else
                { tsbEliminar.Image = Properties.Resources.delete.ToBitmap(); }
            }
        }
    }
}
