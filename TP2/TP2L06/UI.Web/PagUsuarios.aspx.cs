using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;
using Util;

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
            cambiaNombreBtn();
            LimpiarCampos();
        }

        protected void cambiaNombreBtn()
        {
            if (this.SelectedID > 0)
            {
                if (SelectedHab)
                {
                    this.elimiarLinkButton.Text = "Eliminar";
                }
                else
                {
                    this.elimiarLinkButton.Text = "Habilitar";
                }
            }
        }

        private void LoadForm(int idUsr)
        {
            this.EntityUsuario = this.Logic.GetOne(idUsr);
            this.usuarioTextBox.Text = this.EntityUsuario.NombreUsuario;
            this.claveTextBox.Text = this.EntityUsuario.Clave;
            this.legajoTextBox.Text = this.EntityUsuario.Legajo.ToString();
            this.ListarPersonas();
            this.ListarTiposUsuarios();

            try
            {
                int idPer = EntityUsuario.IdPersona;
                var per = new PersonaLogic().GetOne(idPer);
                idPersonaDDL.SelectedValue = per.IdPersona.ToString();
                idPersonaDDL.DataBind();

                int idTU = EntityUsuario.IdTipoUsuario;
                var tipo = new TipoUsuarioLogic().GetOne(idTU);
                idTipoUsuarioDDL.SelectedValue = tipo.IdTipoUsuario.ToString();
                idTipoUsuarioDDL.DataBind();
            }
            catch
            {
                Console.WriteLine("Error al cargar personas o tipos de usuario");
            }
        }

        private void LoadEntity(Usuario usuario)
        {
            usuario.NombreUsuario = this.usuarioTextBox.Text;
            usuario.Clave = this.claveTextBox.Text;
            usuario.Legajo = Convert.ToInt32(this.legajoTextBox.Text);
            usuario.IdTipoUsuario = Convert.ToInt32(idTipoUsuarioDDL.SelectedValue.ToString());
            usuario.IdPersona = Convert.ToInt32(idPersonaDDL.SelectedValue.ToString());
        }

        private void SaveEntity(Usuario usuario)
        {
            this.Logic.Save(usuario);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            if (ValidaCampos(this.FormMode))
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
                        cambiaNombreBtn();
                        break;

                    case FormModes.CancelaBaja:
                        this.EntityUsuario = new Usuario();
                        this.EntityUsuario.ID = this.SelectedID;
                        this.LoadEntity(this.EntityUsuario);
                        this.DeleteEntity(EntityUsuario, BusinessEntity.States.Undeleted);
                        this.LoadGrid();
                        cambiaNombreBtn();
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
                this.repetirClaveLabel.Enabled = false;
                this.repetirClaveTextBox.Enabled = false;
                this.repetirClaveLabel.Visible = false;
                this.repetirClaveTextBox.Visible = false;
            }
        }

        private void EnableForm(bool enable, bool en2)
        {
            this.usuarioTextBox.Enabled = enable;
            this.claveTextBox.Enabled = enable;
            this.legajoTextBox.Enabled = enable;
            this.idPersonaDDL.Enabled = enable;
            this.idTipoUsuarioDDL.Enabled = enable;
            this.aceptarLinkButton.Enabled = en2;
            this.cancelarLinkButton.Enabled = en2;
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.EnableForm(true, true);
                this.formPanel.Visible = true;
                this.formActionPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
                this.repetirClaveLabel.Enabled = false;
                this.repetirClaveTextBox.Enabled = false;
                this.repetirClaveLabel.Visible = false;
                this.repetirClaveTextBox.Visible = false;
            }
        }

        protected void elimiarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.EnableForm(false, true);
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
                //this.EnableForm(false);
                this.LoadForm(this.SelectedID);
                this.repetirClaveLabel.Enabled = false;
                this.repetirClaveTextBox.Enabled = false;
                this.repetirClaveLabel.Visible = false;
                this.repetirClaveTextBox.Visible = false;
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
            this.EnableForm(true, true);
            ListarPersonas();
            ListarTiposUsuarios();
            this.repetirClaveLabel.Enabled = true;
            this.repetirClaveTextBox.Enabled = true;
            this.repetirClaveLabel.Visible = true;
            this.repetirClaveTextBox.Visible = true;
        }

        private void ClearForm()
        {
            this.usuarioTextBox.Text = string.Empty;
            this.claveTextBox.Text = string.Empty;
            this.repetirClaveTextBox.Text = string.Empty;
            this.legajoTextBox.Text = string.Empty;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            this.ClearForm();
            this.formPanel.Visible = false;
            this.formActionPanel.Visible = false;
            this.repetirClaveLabel.Enabled = false;
            this.repetirClaveTextBox.Enabled = false;
        }

        private void ListarPersonas()
        {
            var personas = new PersonaLogic().GetAll();
            idPersonaDDL.DataSource = personas;
            idPersonaDDL.DataValueField = "IdPersona";
            idPersonaDDL.DataTextField = "NombreYApellido";
            idPersonaDDL.DataBind();
        }

        private void ListarTiposUsuarios()
        {
            var tipos = new TipoUsuarioLogic().GetAll();
            idTipoUsuarioDDL.DataSource = tipos;
            idTipoUsuarioDDL.DataValueField = "IdTipoUsuario";
            idTipoUsuarioDDL.DataTextField = "Descripcion";
            idTipoUsuarioDDL.DataBind();
        }

        private bool ValidaCampos(FormModes modo)
        {
            var correcto = true;
            if (!Validaciones.campoLleno(legajoTextBox.Text))
            {
                correcto = false;
                legajoValidator.Text = "*";
            }
            else { legajoValidator.Text = ""; }

            if (!Validaciones.campoLleno(usuarioTextBox.Text))
            {
                correcto = false;
                usuarioValidator.Text = "*";
            }
            else { usuarioValidator.Text = ""; }

            if (!Validaciones.campoLleno(claveTextBox.Text))
            {
                correcto = false;
                claveValidator.Text = "*";
            }
            else if (!Validaciones.minAlcanzado(claveTextBox.Text, 8))
            {
                correcto = false;
                claveValidator.Text = "La clave debe tener al menos 8 caracteres";
            }
            else { claveValidator.Text = ""; }

            if (modo == FormModes.Alta)
            {
                if (!Validaciones.campoLleno(repetirClaveTextBox.Text))
                {
                    correcto = false;
                    repiteClaveValidator.Text = "*";
                }
                else { repiteClaveValidator.Text = ""; }

                if (!Validaciones.clavesIguales(claveTextBox.Text, repetirClaveTextBox.Text))
                {
                    correcto = false;
                    repiteClaveValidator.Text = "Las claves no son idénticas";
                }
                else { repiteClaveValidator.Text = ""; }
            }
            else
            { repiteClaveValidator.Text = ""; }

            return correcto;
        }
        private void LimpiarCampos()
        {
            legajoValidator.Text = "";
            usuarioValidator.Text = "";
            claveValidator.Text = "";
            repiteClaveValidator.Text = "";
        }
    }
}