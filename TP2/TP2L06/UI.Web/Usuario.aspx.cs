using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class Usuario : System.Web.UI.Page
    {
        UsuarioLogic _logic;
        private UsuarioLogic Logic
        {
            get
            {
                if(_logic==null)
                {
                    _logic = new UsuarioLogic();
                }
                return _logic;
            }
        }


        Usuario _EntityUsuario;

        private Business.Entities.Usuario EntityUsuario
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadGrid()
        {
            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();
        }

        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }

        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }



        private int SelectedID
        {
            get
            {
                if (this.ViewState["SelectedID"] != null)
                {
                    return (int)this.ViewState["SelectedID"];
                }
                else return 0;
            }

            set
            {
                this.ViewState["SelectedID"] = value;
            }
        }

        private bool IsEntitySelected
        {
            get { return (this.SelectedID != 0); }
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        private void LoadForm(int idUsr)
        {
            this.EntityUsuario = this.Logic.GetOne(idUsr);
            
            this.usuarioTextBox.Text = this.EntityUsuario.NombreUsuario;
            this.claveTextBox.Text = this.EntityUsuario.Clave;
            this.legajoTextBox.Text = this.EntityUsuario.Legajo.ToString();
            this.idTipoUsuarioTextbox.Text = this.EntityUsuario.IdTipoUsuario.ToString();
            this.idPersonaTextBox.Text = this.EntityUsuario.IdPersona.ToString();
            this.habilitadoCheckBox.Checked = this.EntityUsuario.Habilitado;

        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if(this.IsEntitySelected)
            {
                this.EnableForm(true);
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
            }
        }

        private void LoadEntity(Business.Entities.Usuario usuario)
        {
            usuario.NombreUsuario = this.usuarioTextBox.Text;
            usuario.Clave = this.claveTextBox.Text;
            usuario.Legajo = Convert.ToInt32(this.legajoTextBox.Text);
            usuario.IdTipoUsuario = Convert.ToInt32(this.idTipoUsuarioTextbox.Text);
            usuario.IdPersona = Convert.ToInt32(this.idPersonaTextBox.Text);
            usuario.Habilitado = this.habilitadoCheckBox.Checked;

        }


        private void SaveEntity(Business.Entities.Usuario usuario)
        {
            this.Logic.Save(usuario);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch(this.FormMode)
            {
                case FormModes.Alta:
                    this.EntityUsuario = new Business.Entities.Usuario();
                    this.LoadEntity(this.EntityUsuario);
                    this.SaveEntity(this.EntityUsuario);
                    this.LoadGrid();
                    break;


                case FormModes.Baja:
                    this.EntityUsuario = new Business.Entities.Usuario();
                    this.EntityUsuario.ID = this.SelectedID;
                    this.LoadEntity(this.EntityUsuario);
                    this.DeleteEntity(EntityUsuario, BusinessEntity.States.Deleted);
                    this.LoadGrid();
                    break;

                case FormModes.Modificacion:
                    this.EntityUsuario = new Business.Entities.Usuario();
                    this.EntityUsuario.ID = this.SelectedID;
                    this.EntityUsuario.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.EntityUsuario);
                    this.SaveEntity(this.EntityUsuario);
                    this.LoadGrid();
                    break;

                default:
                    break;
            }

            this.formPanel.Visible = false;
        }

        private void EnableForm(bool enable)
        {
            this.usuarioTextBox.Enabled = enable;
            this.claveTextBox.Enabled = enable;
            this.legajoTextBox.Enabled = enable;
            this.idTipoUsuarioTextbox.Enabled = enable;
            this.idPersonaTextBox.Enabled = enable;
            this.habilitadoCheckBox.Enabled = enable;
        }

        protected void elimiarLinkButton_Click(object sender, EventArgs e)
        {
            if(this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }


        private void DeleteEntity(Business.Entities.Usuario usuario, BusinessEntity.States est)
        {
            this.Logic.Delete(usuario, est);
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
        }

        private void ClearForm()
        {
            this.usuarioTextBox.Text = string.Empty;
            this.claveTextBox.Text = string.Empty;
            this.repetirClaveTextBox.Text = string.Empty;
            this.legajoTextBox.Text = string.Empty;
            this.habilitadoCheckBox.Checked = false;
            this.idPersonaTextBox.Text = string.Empty;
            this.idTipoUsuarioTextbox.Text = string.Empty;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.ClearForm();
                this.formPanel.Visible = false;
            }
        }
    }
}