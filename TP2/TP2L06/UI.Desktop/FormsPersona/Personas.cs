using Business.Entities;
using Business.Logic;
using System;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class Personas : ApplicationForm
    {
        public Personas()
        {
            InitializeComponent();
            dgvPersonas.AutoGenerateColumns = false;
        }
        public void Listar()
        {
            try
            {
                PersonaLogic pl = new PersonaLogic();
                this.dgvPersonas.DataSource = pl.GetAll();
                FormatoDGV.ActualizaColor(dgvPersonas);
            }
            catch (Exception Ex)
            {
                Notificar("Error de carga de usuarios", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Personas_Load(object sender, EventArgs e)
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
            PersonaDesktop formPersona = new PersonaDesktop(ApplicationForm.ModoForm.Alta);
            formPersona.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvPersonas.SelectedRows.Count > 0)
            {
                int ID = ((Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).IdPersona;
                PersonaDesktop formPersona = new PersonaDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formPersona.ShowDialog();
                this.Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).IdPersona;
            bool hab = ((Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).Habilitado;

            PersonaDesktop formPersona;
            if (hab == true)
            { formPersona = new PersonaDesktop(ID, ApplicationForm.ModoForm.Baja); }
            else
            { formPersona = new PersonaDesktop(ID, ApplicationForm.ModoForm.CancelaBaja); }

            formPersona.ShowDialog();
            this.Listar();
        }

        private void dgvPersonas_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (this.dgvPersonas.SelectedRows.Count > 0)
            {
                bool hab = ((Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).Habilitado;
                if (hab == false)
                { tsbEliminar.Image = Properties.Resources.apply.ToBitmap(); }
                else
                { tsbEliminar.Image = Properties.Resources.delete.ToBitmap(); }
            }
        }
    }
}
