using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class Comisiones : ApplicationForm
    {
        public Comisiones()
        {
            InitializeComponent();
            dgvComisiones.AutoGenerateColumns = false;
        }
        public void Listar()
        {
            try
            {
                ComisionLogic cl = new ComisionLogic();
                this.dgvComisiones.DataSource = cl.GetAll();
                FormatoDGV.ActualizaColor(dgvComisiones);
            }
            catch (Exception Ex)
            {
                Notificar("Error de carga de comisiones", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Comisiones_Load(object sender, EventArgs e)
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
            ComisionDesktop formComision = new ComisionDesktop(ApplicationForm.ModoForm.Alta);
            formComision.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvComisiones.SelectedRows.Count>0)
            {
                int ID = ((Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).IdComision;
                ComisionDesktop formComision = new ComisionDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formComision.ShowDialog();
                this.Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).IdComision;
            bool hab = ((Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).Habilitado;

            ComisionDesktop formComision;
            if (hab == true)
            { formComision = new ComisionDesktop(ID, ApplicationForm.ModoForm.Baja); }
            else
            { formComision = new ComisionDesktop(ID, ApplicationForm.ModoForm.CancelaBaja); }

            formComision.ShowDialog();
            this.Listar();
        }

        private void dgvComisiones_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (this.dgvComisiones.SelectedRows.Count > 0)
            {
                bool hab = ((Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).Habilitado;
                if (hab == false)
                { tsbEliminar.Image = Properties.Resources.apply.ToBitmap(); }
                else
                { tsbEliminar.Image = Properties.Resources.delete.ToBitmap(); }
            }
        }
    }
}
