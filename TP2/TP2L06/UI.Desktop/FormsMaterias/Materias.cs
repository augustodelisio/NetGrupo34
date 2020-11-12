using Business.Entities;
using Business.Logic;
using System;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class Materias : ApplicationForm
    {
        public Materias()
        {
            InitializeComponent();
            dgvMaterias.AutoGenerateColumns = false;
        }
        public void Listar()
        {
            try
            {
                MateriaLogic ml = new MateriaLogic();
                this.dgvMaterias.DataSource = ml.GetAll();
                FormatoDGV.ActualizaColor(dgvMaterias);
            }
            catch (Exception Ex)
            {
                Notificar("Error de carga", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Materias_Load(object sender, EventArgs e)
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
            MateriaDesktop formMateria = new MateriaDesktop(ApplicationForm.ModoForm.Alta);
            formMateria.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvMaterias.SelectedRows.Count > 0)
            {
                int ID = ((Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).IdMateria;
                MateriaDesktop formMateria = new MateriaDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formMateria.ShowDialog();
                this.Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).IdMateria;
            bool hab = ((Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).Habilitado;

            MateriaDesktop formMateria;
            if (hab == true)
            { formMateria = new MateriaDesktop(ID, ApplicationForm.ModoForm.Baja); }
            else
            { formMateria = new MateriaDesktop(ID, ApplicationForm.ModoForm.CancelaBaja); }

            formMateria.ShowDialog();
            this.Listar();
        }

        private void dgvMaterias_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (this.dgvMaterias.SelectedRows.Count > 0)
            {
                bool hab = ((Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).Habilitado;
                if (hab == false)
                { tsbEliminar.Image = Properties.Resources.apply.ToBitmap(); }
                else
                { tsbEliminar.Image = Properties.Resources.delete.ToBitmap(); }
            }
        }
    }
}
