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
    public partial class PagEspecialidades : System.Web.UI.Page
    {
        EspecialidadLogic _logic;

        private EspecialidadLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new EspecialidadLogic();
                }
                return _logic;
            }
           
        }

        Especialidad _EntityEspecialidad;

        private Especialidad EntityEspecialidad
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
                    return Convert.ToBoolean(this.gridView.SelectedRow.Cells[3].Text);
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
                this.eliminarLinkButton.Text = "Eliminar";
            }
            else
            {
                this.eliminarLinkButton.Text = "Habilitar";
            }
        }
        private void LoadForm(int idEsp)
        {
            this.EntityEspecialidad = this.Logic.GetOne(idEsp);
            this.idEspecialidadTextBox.Text = Convert.ToString(this.EntityEspecialidad.IdEspecialidad);
            this.descripcionTextBox.Text = this.EntityEspecialidad.Descripcion;
            
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
        private void LoadEntity(Especialidad especialidad)
        {
            especialidad.IdEspecialidad = Convert.ToInt32(this.EntityEspecialidad.IdEspecialidad);
            especialidad.Descripcion = this.descripcionTextBox.Text;
        }
        private void SaveEntity(Especialidad especialidad)
        {
            this.Logic.Save(especialidad);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Alta:
                    this.EntityEspecialidad = new Especialidad();
                    this.LoadEntity(this.EntityEspecialidad);
                    this.EntityEspecialidad.Habilitado = true;
                    this.SaveEntity(this.EntityEspecialidad);
                    this.LoadGrid();
                    break;

                case FormModes.Baja:
                    this.EntityEspecialidad = new Especialidad();
                    this.EntityEspecialidad.ID = this.SelectedID;
                    this.LoadEntity(this.EntityEspecialidad);
                    this.DeleteEntity(EntityEspecialidad, BusinessEntity.States.Deleted);
                    this.LoadGrid();
                    break;

                case FormModes.CancelaBaja:
                    this.EntityEspecialidad = new Especialidad();
                    this.EntityEspecialidad.ID = this.SelectedID;
                    this.LoadEntity(this.EntityEspecialidad);
                    this.DeleteEntity(EntityEspecialidad, BusinessEntity.States.Undeleted);
                    this.LoadGrid();
                    break;

                case FormModes.Modificacion:
                    this.EntityEspecialidad = new Especialidad();
                    this.EntityEspecialidad.ID = this.SelectedID;
                    this.EntityEspecialidad.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.EntityEspecialidad);
                    //Guardo hab según el valor que tiene en el grid view
                    this.EntityEspecialidad.Habilitado = Convert.ToBoolean(this.gridView.SelectedRow.Cells[3].Text);
                    this.SaveEntity(this.EntityEspecialidad);
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
            this.idEspecialidadTextBox.Enabled = enable;
            this.descripcionTextBox.Enabled = enable;
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
        private void DeleteEntity(Especialidad especialidad, BusinessEntity.States est)
        {
            this.Logic.Delete(especialidad, est);
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
            this.idEspecialidadTextBox.Text = string.Empty;
            this.descripcionTextBox.Text = string.Empty;
        }
        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.ClearForm();
            this.formPanel.Visible = false;
            this.formActionPanel.Visible = false;
        }
    }
}