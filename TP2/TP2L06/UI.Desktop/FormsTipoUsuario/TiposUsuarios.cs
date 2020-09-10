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
    public partial class TiposUsuarios : ApplicationForm
    {
        public TiposUsuarios()
        {
            InitializeComponent();
            dgvTiposUsuarios.AutoGenerateColumns = false;
        }
        public void Listar()
        {
            try
            {
                TipoUsuarioLogic tul = new TipoUsuarioLogic();
                this.dgvTiposUsuarios.DataSource = tul.GetAll();
                FormatoDGV.ActualizaColor(dgvTiposUsuarios);
            }
            catch (Exception Ex)
            {
                Notificar("Error de carga de tipos", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void TiposUsuarios_Load(object sender, EventArgs e)
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
            TipoUsuarioDesktop formTipoUsuario = new TipoUsuarioDesktop(ApplicationForm.ModoForm.Alta);
            formTipoUsuario.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvTiposUsuarios.SelectedRows.Count>0)
            {
                int ID = ((TipoUsuario)this.dgvTiposUsuarios.SelectedRows[0].DataBoundItem).IdTipoUsuario;
                TipoUsuarioDesktop formTipoUsuario = new TipoUsuarioDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formTipoUsuario.ShowDialog();
                this.Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((TipoUsuario)this.dgvTiposUsuarios.SelectedRows[0].DataBoundItem).IdTipoUsuario;
            bool hab = ((TipoUsuario)this.dgvTiposUsuarios.SelectedRows[0].DataBoundItem).Habilitado;

            TipoUsuarioDesktop formTipoUsuario;
            if (hab == true)
                { formTipoUsuario = new TipoUsuarioDesktop(ID, ModoForm.Baja); }
            else
                { formTipoUsuario = new TipoUsuarioDesktop(ID, ModoForm.CancelaBaja); }
            
            formTipoUsuario.ShowDialog();
            this.Listar();
        }

        private void dgvTiposUsuarios_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (this.dgvTiposUsuarios.SelectedRows.Count > 0)
            {
                bool hab = ((TipoUsuario)this.dgvTiposUsuarios.SelectedRows[0].DataBoundItem).Habilitado;
                if (hab == false)
                { tsbEliminar.Image = Properties.Resources.apply.ToBitmap(); }
                else
                { tsbEliminar.Image = Properties.Resources.delete.ToBitmap(); }
            }
        }
    }
}
