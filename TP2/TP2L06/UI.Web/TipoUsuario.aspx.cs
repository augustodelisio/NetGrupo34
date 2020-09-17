using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class TipoUsuario : System.Web.UI.Page
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


        Usuario _EntityTipoUsuario;

        private Business.Entities.TipoUsuario EntityTipoUsuario
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
            this.EntityTipoUsuario = this.Logic.GetOne(idUsr);


            this.idTipoUsuarioTextBox.Text = this.EntityTipoUsuario.IdTipoUsuario.ToString();
            this.descripcionTextBox.Text = this.EntityTipoUsuario.Descripcion;
            this.habilitadoCheckBox.Checked = this.EntityTipoUsuario.Habilitado; 

        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.EnableForm(true);
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
            }
        }

        private void LoadEntity(Business.Entities.TipoUsuario tipoUsuario)
        {

            tipoUsuario.IdTipoUsuario = Convert.ToInt32(this.idTipoUsuarioTextBox.Text);
            tipoUsuario.Descripcion = this.descripcionTextBox.Text;
            tipoUsuario.Habilitado = this.habilitadoCheckBox.Checked;


        }


        private void SaveEntity(Business.Entities.TipoUsuario tipoUsuario)
        {
            this.Logic.Save(tipoUsuario);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Alta:
                    this.EntityTipoUsuario = new Business.Entities.TipoUsuario();
                    this.LoadEntity(this.EntityTipoUsuario);
                    this.SaveEntity(this.EntityTipoUsuario);
                    this.LoadGrid();
                    break;


                case FormModes.Baja:
                    this.EntityTipoUsuario = new Business.Entities.TipoUsuario();
                    this.EntityTipoUsuario.ID = this.SelectedID;
                    this.LoadEntity(this.EntityTipoUsuario);
                    this.DeleteEntity(EntityTipoUsuario, BusinessEntity.States.Deleted);
                    this.LoadGrid();
                    break;

                case FormModes.Modificacion:
                    this.EntityTipoUsuario = new Business.Entities.TipoUsuario();
                    this.EntityTipoUsuario.ID = this.SelectedID;
                    this.EntityTipoUsuario.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.EntityTipoUsuario);
                    this.SaveEntity(this.EntityTipoUsuario);
                    this.LoadGrid();
                    break;

                default:
                    break;
            }

            this.formPanel.Visible = false;
        }

        private void EnableForm(bool enable)
        {
            this.idTipoUsuarioTextBox.Enabled = enable;
            this.descripcionTextBox.Enabled = enable;
            this.habilitadoCheckBox.Enabled = enable;


        }

        protected void elimiarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
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
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
        }

        private void ClearForm()
        {
            this.idTipoUsuarioTextBox.Text = string.Empty;
            this.descripcionTextBox.Text = string.Empty;
            this.habilitadoCheckBox.Checked = false;
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