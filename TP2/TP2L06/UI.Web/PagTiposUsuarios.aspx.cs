using Business.Entities;
using Business.Logic;
using System;
using Util;

namespace UI.Web
{
    public partial class PagTiposUsuarios : System.Web.UI.Page
    {
        TipoUsuarioLogic _logic;
        private TipoUsuarioLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new TipoUsuarioLogic();
                }
                return _logic;
            }
        }

#pragma warning disable CS0169 // El campo 'PagTiposUsuarios._EntityTipoUsuario' nunca se usa
        TipoUsuario _EntityTipoUsuario;
#pragma warning restore CS0169 // El campo 'PagTiposUsuarios._EntityTipoUsuario' nunca se usa

        private Business.Entities.TipoUsuario EntityTipoUsuario
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
                    return Convert.ToBoolean(this.gridView.SelectedRow.Cells[2].Text);
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
            this.EntityTipoUsuario = this.Logic.GetOne(idUsr);
            this.descripcionTextBox.Text = this.EntityTipoUsuario.Descripcion;
        }


        private void LoadEntity(Business.Entities.TipoUsuario tipoUsuario)
        {
            tipoUsuario.Descripcion = this.descripcionTextBox.Text;
        }

        private void SaveEntity(Business.Entities.TipoUsuario tipoUsuario)
        {
            this.Logic.Save(tipoUsuario);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            if (ValidaCampos(this.FormMode))
            {
                switch (this.FormMode)
                {
                    case FormModes.Alta:
                        this.EntityTipoUsuario = new TipoUsuario();
                        this.LoadEntity(this.EntityTipoUsuario);
                        this.EntityTipoUsuario.Habilitado = true;
                        this.SaveEntity(this.EntityTipoUsuario);
                        this.LoadGrid();
                        break;

                    case FormModes.Baja:
                        this.EntityTipoUsuario = new TipoUsuario();
                        this.EntityTipoUsuario.IdTipoUsuario = this.SelectedID;
                        this.LoadEntity(this.EntityTipoUsuario);
                        this.DeleteEntity(EntityTipoUsuario, BusinessEntity.States.Deleted);
                        this.LoadGrid();
                        cambiaNombreBtn();
                        break;

                    case FormModes.CancelaBaja:
                        this.EntityTipoUsuario = new TipoUsuario();
                        this.EntityTipoUsuario.IdTipoUsuario = this.SelectedID;
                        this.LoadEntity(this.EntityTipoUsuario);
                        this.DeleteEntity(EntityTipoUsuario, BusinessEntity.States.Undeleted);
                        this.LoadGrid();
                        cambiaNombreBtn();
                        break;

                    case FormModes.Modificacion:
                        this.EntityTipoUsuario = new TipoUsuario();
                        this.EntityTipoUsuario.IdTipoUsuario = this.SelectedID;
                        this.EntityTipoUsuario.State = BusinessEntity.States.Modified;
                        this.LoadEntity(this.EntityTipoUsuario);
                        this.EntityTipoUsuario.Habilitado = Convert.ToBoolean(this.gridView.SelectedRow.Cells[2].Text);
                        this.SaveEntity(this.EntityTipoUsuario);
                        this.LoadGrid();
                        break;

                    default:
                        break;
                }

                this.formPanel.Visible = false;
                this.formActionPanel.Visible = false;
            }
        }

        private void EnableForm(bool enable, bool en2)
        {
            this.descripcionTextBox.Enabled = enable;
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
            }
        }

        private void DeleteEntity(Business.Entities.TipoUsuario tipoUsuario, BusinessEntity.States est)
        {
            this.Logic.Delete(tipoUsuario, est);
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.formActionPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true, true);
        }

        private void ClearForm()
        {
            this.descripcionTextBox.Text = string.Empty;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            this.ClearForm();
            this.formPanel.Visible = false;
            this.formActionPanel.Visible = false;
        }


        private bool ValidaCampos(FormModes modo)
        {
            var correcto = true;
            if (!Validaciones.campoLleno(descripcionTextBox.Text))
            {
                correcto = false;
                descripcionValidator.Text = "*";
            }
            else { descripcionValidator.Text = ""; }


            return correcto;
        }
        private void LimpiarCampos()
        {
            descripcionValidator.Text = "";
        }
    }
}