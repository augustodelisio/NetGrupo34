using Business.Entities;
using Business.Logic;
using System;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class Planes : ApplicationForm
    {
        public Planes()
        {
            InitializeComponent();
            dgvPlanes.AutoGenerateColumns = false;
        }
        public void Listar()
        {
            try
            {
                PlanLogic el = new PlanLogic();
                this.dgvPlanes.DataSource = el.GetAll();
                FormatoDGV.ActualizaColor(dgvPlanes);
            }
            catch (Exception Ex)
            {
                Notificar("Error de carga", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Planes_Load(object sender, EventArgs e)
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
            PlanDesktop formPlan = new PlanDesktop(ApplicationForm.ModoForm.Alta);
            formPlan.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvPlanes.SelectedRows.Count > 0)
            {
                int ID = ((Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).IdPlan;
                PlanDesktop formPlan = new PlanDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formPlan.ShowDialog();
                this.Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).IdPlan;
            bool hab = ((Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).Habilitado;

            PlanDesktop formPlan;
            if (hab == true)
            { formPlan = new PlanDesktop(ID, ApplicationForm.ModoForm.Baja); }
            else
            { formPlan = new PlanDesktop(ID, ApplicationForm.ModoForm.CancelaBaja); }

            formPlan.ShowDialog();
            this.Listar();
        }

        private void dgvPlanes_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (this.dgvPlanes.SelectedRows.Count > 0)
            {
                bool hab = ((Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).Habilitado;
                if (hab == false)
                { tsbEliminar.Image = Properties.Resources.apply.ToBitmap(); }
                else
                { tsbEliminar.Image = Properties.Resources.delete.ToBitmap(); }
            }
        }
    }
}
