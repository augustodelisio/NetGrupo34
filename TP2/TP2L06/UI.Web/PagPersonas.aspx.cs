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
    public partial class PagPersonas : System.Web.UI.Page
    {
        PersonaLogic _logic;


        private PersonaLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new PersonaLogic();
                }
                return _logic;
            }
        }

        private Persona EntityPersona;
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



        private void LoadForm(int idPersona)
        {
            this.EntityPersona = this.Logic.GetOne(idPersona);

            this.nombreTextBox.Text = this.EntityPersona.Nombre;
            this.apellidoTextBox.Text = this.EntityPersona.Apellido;
            this.direccionTextBox.Text = this.EntityPersona.Direccion.ToString();
            this.emailTextBox.Text = this.EntityPersona.Email.ToString();
            this.fechaNacimientoTextBox.Text = this.EntityPersona.FechaNacimiento.ToString();
            this.emailTextBox.Text = this.EntityPersona.FechaNacimiento.ToString();
            this.habilitadoCheckBox.Checked = this.EntityPersona.Habilitado;

        }
        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
            }
        }
        private void LoadEntity(Business.Entities.Persona persona)
        {
            persona.Nombre = this.nombreTextBox.Text;
            persona.Apellido = this.apellidoTextBox.Text;
            persona.Direccion = this.direccionTextBox.Text;
            persona.Email = this.emailTextBox.Text;
            persona.FechaNacimiento = Convert.ToDateTime(this.EntityPersona.FechaNacimiento);
            persona.Habilitado = this.habilitadoCheckBox.Checked;

        }
        private void SaveEntity(Business.Entities.Persona persona)
        {
            this.Logic.Save(persona);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Alta:
                    this.EntityPersona = new Business.Entities.Persona();
                    this.LoadEntity(this.EntityPersona);
                    this.SaveEntity(this.EntityPersona);
                    this.LoadGrid();
                    break;


                case FormModes.Baja:
                    this.EntityPersona = new Business.Entities.Persona();
                    this.EntityPersona.ID = this.SelectedID;
                    this.LoadEntity(this.EntityPersona);
                    this.DeleteEntity(EntityPersona, BusinessEntity.States.Deleted);
                    this.LoadGrid();
                    break;

                case FormModes.Modificacion:
                    this.EntityPersona = new Business.Entities.Persona();
                    this.EntityPersona.ID = this.SelectedID;
                    this.EntityPersona.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.EntityPersona);
                    this.SaveEntity(this.EntityPersona);
                    this.LoadGrid();
                    break;

                default:
                    break;
            }
        }
        private void EnableForm(bool enable)
        {
            this.nombreTextBox.Enabled = enable;
            this.apellidoTextBox.Enabled = enable;
            this.direccionTextBox.Enabled = enable;
            this.emailTextBox.Enabled = enable;
            this.fechaNacimientoTextBox.Enabled = enable;
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
        private void DeleteEntity(Business.Entities.Persona persona, BusinessEntity.States est)
        {
            this.Logic.Delete(persona, est);
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
            this.nombreTextBox.Text = string.Empty;
            this.apellidoTextBox.Text = string.Empty;
            this.direccionTextBox.Text = string.Empty;
            this.emailTextBox.Text = string.Empty;
            this.fechaNacimientoTextBox.Text = string.Empty;
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