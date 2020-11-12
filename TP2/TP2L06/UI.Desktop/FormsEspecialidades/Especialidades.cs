using Business.Entities;
using Business.Logic;
using System;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class Especialidades : ApplicationForm
    {
        public Especialidades()
        {
            InitializeComponent();
            dgvEspecialidades.AutoGenerateColumns = false;
        }
        public void Listar()
        {
            try
            {
                EspecialidadLogic el = new EspecialidadLogic();
                this.dgvEspecialidades.DataSource = el.GetAll();
                FormatoDGV.ActualizaColor(dgvEspecialidades);
            }
            catch (Exception Ex)
            {
                Notificar("Error de carga de especialidades", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Especialidades_Load(object sender, EventArgs e)
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
            EspecialidadDesktop formEspecialidad = new EspecialidadDesktop(ApplicationForm.ModoForm.Alta);
            formEspecialidad.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvEspecialidades.SelectedRows.Count > 0)
            {
                int ID = ((Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).IdEspecialidad;
                EspecialidadDesktop formEspecialidad = new EspecialidadDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formEspecialidad.ShowDialog();
                this.Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).IdEspecialidad;
            bool hab = ((Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).Habilitado;

            EspecialidadDesktop formEspecialidad;
            if (hab == true)
            { formEspecialidad = new EspecialidadDesktop(ID, ApplicationForm.ModoForm.Baja); }
            else
            { formEspecialidad = new EspecialidadDesktop(ID, ApplicationForm.ModoForm.CancelaBaja); }

            formEspecialidad.ShowDialog();
            this.Listar();
        }

        private void dgvEspecialidades_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (this.dgvEspecialidades.SelectedRows.Count > 0)
            {
                bool hab = ((Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).Habilitado;
                if (hab == false)
                { tsbEliminar.Image = Properties.Resources.apply.ToBitmap(); }
                else
                { tsbEliminar.Image = Properties.Resources.delete.ToBitmap(); }
            }
        }
    }
}
