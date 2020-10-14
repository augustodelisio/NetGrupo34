using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;

namespace UI.Web
{
    public partial class PagUsuarios : System.Web.UI.Page
    {
        UsuarioLogic _logic;
        private UsuarioLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new UsuarioLogic();
                }
                return _logic;
            }
        }

        Usuario _EntityUsuario;

        private Usuario EntityUsuario
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (Session["tipoUsu"].ToString() != "1") //Si no sos Admin te saca
                {
                    Response.Redirect("Home.aspx");
                }
            }
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
            CancelaBaja,
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

        private bool SelectedHab
        {
            get
            {
                if (this.ViewState["SelectedID"] != null)
                {
                    return Convert.ToBoolean(this.gridView.SelectedRow.Cells[4].Text);
                }
                else return false;
            }
        }

        private bool IsEntitySelected
        {
            get { return (this.SelectedID != 0); }
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
            if (SelectedHab)
            {
                this.elimiarLinkButton.Text = "Eliminar";
            }
            else
            {
                this.elimiarLinkButton.Text = "Habilitar";
            }
        }

        private void LoadForm(int idUsr)
        {
            this.EntityUsuario = this.Logic.GetOne(idUsr);
            this.usuarioTextBox.Text = this.EntityUsuario.NombreUsuario;
            this.claveTextBox.Text = this.EntityUsuario.Clave;
            this.legajoTextBox.Text = this.EntityUsuario.Legajo.ToString();
            this.idTipoUsuarioTextbox.Text = this.EntityUsuario.IdTipoUsuario.ToString();
            this.idPersonaTextBox.Text = this.EntityUsuario.IdPersona.ToString();
            this.ListarPersonas();
            int idPer = EntityUsuario.IdPersona;
            var per = new PersonaLogic().GetOne(idPer);
            idPersonaDDL.SelectedValue = per.IdPersona.ToString();
            idPersonaDDL.DataBind();
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.EnableForm(true);
                this.formPanel.Visible = true;
                this.formActionPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
            }
        }

        private void LoadEntity(Usuario usuario)
        {
            usuario.NombreUsuario = this.usuarioTextBox.Text;
            usuario.Clave = this.claveTextBox.Text;
            usuario.Legajo = Convert.ToInt32(this.legajoTextBox.Text);
            usuario.IdTipoUsuario = Convert.ToInt32(this.idTipoUsuarioTextbox.Text);
            usuario.IdPersona = Convert.ToInt32(this.idPersonaTextBox.Text);
        }


        private void SaveEntity(Usuario usuario)
        {
            this.Logic.Save(usuario);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Alta:
                    this.EntityUsuario = new Usuario();
                    this.LoadEntity(this.EntityUsuario);
                    this.EntityUsuario.Habilitado = true;
                    this.SaveEntity(this.EntityUsuario);
                    this.LoadGrid();
                    break;

                case FormModes.Baja:
                    this.EntityUsuario = new Usuario();
                    this.EntityUsuario.ID = this.SelectedID;
                    this.LoadEntity(this.EntityUsuario);
                    this.DeleteEntity(EntityUsuario, BusinessEntity.States.Deleted);
                    this.LoadGrid();
                    break;

                case FormModes.CancelaBaja:
                    this.EntityUsuario = new Usuario();
                    this.EntityUsuario.ID = this.SelectedID;
                    this.LoadEntity(this.EntityUsuario);
                    this.DeleteEntity(EntityUsuario, BusinessEntity.States.Undeleted);
                    this.LoadGrid();
                    break;

                case FormModes.Modificacion:
                    this.EntityUsuario = new Usuario();
                    this.EntityUsuario.ID = this.SelectedID;
                    this.EntityUsuario.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.EntityUsuario);
                    //Guardo hab según el valor que tiene en el grid view
                    this.EntityUsuario.Habilitado = Convert.ToBoolean(this.gridView.SelectedRow.Cells[4].Text);
                    this.SaveEntity(this.EntityUsuario);
                    this.LoadGrid();
                    break;

                default:
                    break;
            }
            this.formPanel.Visible = false;
            this.formActionPanel.Visible = false;
        }

        private void EnableForm(bool enable)
        {
            this.usuarioTextBox.Enabled = enable;
            this.claveTextBox.Enabled = enable;
            this.legajoTextBox.Enabled = enable;
            this.idTipoUsuarioTextbox.Enabled = enable;
            this.idPersonaTextBox.Enabled = enable;
            this.aceptarLinkButton.Enabled = enable;
            this.cancelarLinkButton.Enabled = enable;
        }

        protected void elimiarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.formActionPanel.Visible = true;
                if (SelectedHab)
                {
                    this.FormMode = FormModes.Baja;
                }
                else
                {
                    this.FormMode = FormModes.CancelaBaja;
                }
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }


        private void DeleteEntity(Usuario usuario, BusinessEntity.States est)
        {
            this.Logic.Delete(usuario, est);
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.formActionPanel.Visible = true;
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
            this.idPersonaTextBox.Text = string.Empty;
            this.idTipoUsuarioTextbox.Text = string.Empty;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.ClearForm();
            this.formPanel.Visible = false;
            this.formActionPanel.Visible = false;
        }

        private void ListarPersonas()
        {
            var personas = new PersonaLogic().GetAll();
            idPersonaDDL.DataSource = personas;
            idPersonaDDL.DataValueField = "idPersona";
            idPersonaDDL.DataTextField = "NombreYApellido";
            idPersonaDDL.DataBind();
        }

        //idPersonaTextBox.Text = idPersonaDDL.SelectedValue; Esto deberia modificar el id segun el selected value.
        
    }
}