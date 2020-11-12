using Business.Entities;
using Business.Logic;
using System;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class Usuarios : ApplicationForm
    {
        public Usuarios()
        {
            InitializeComponent();
            dgvUsuarios.AutoGenerateColumns = false;
        }
        public void Listar()
        {
            try
            {
                UsuarioLogic ul = new UsuarioLogic();
                this.dgvUsuarios.DataSource = ul.GetAll();
                FormatoDGV.ActualizaColor(dgvUsuarios);
            }
            catch (Exception Ex)
            {
                Notificar("Error de carga de usuarios", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Usuarios_Load(object sender, EventArgs e)
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
            UsuarioDesktop formUsuario = new UsuarioDesktop(ApplicationForm.ModoForm.Alta);
            formUsuario.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvUsuarios.SelectedRows.Count > 0)
            {
                int ID = ((Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                UsuarioDesktop formUsuario = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formUsuario.ShowDialog();
                this.Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
            bool hab = ((Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).Habilitado;

            UsuarioDesktop formUsuario;
            if (hab == true)
            { formUsuario = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Baja); }
            else
            { formUsuario = new UsuarioDesktop(ID, ApplicationForm.ModoForm.CancelaBaja); }

            formUsuario.ShowDialog();
            this.Listar();
        }

        private void dgvUsuarios_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (this.dgvUsuarios.SelectedRows.Count > 0)
            {
                bool hab = ((Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).Habilitado;
                if (hab == false)
                { tsbEliminar.Image = Properties.Resources.apply.ToBitmap(); }
                else
                { tsbEliminar.Image = Properties.Resources.delete.ToBitmap(); }
            }
        }
    }
}
