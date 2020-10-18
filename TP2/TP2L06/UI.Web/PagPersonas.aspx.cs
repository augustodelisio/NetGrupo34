using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using Util;

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

        private void LoadForm(int idPersona)
        {
            this.EntityPersona = this.Logic.GetOne(idPersona);

            this.nombreTextBox.Text = this.EntityPersona.Nombre;
            this.apellidoTextBox.Text = this.EntityPersona.Apellido;
            this.direccionTextBox.Text = this.EntityPersona.Direccion;
            this.emailTextBox.Text = this.EntityPersona.Email;
            this.telefonoTextBox.Text = this.EntityPersona.Telefono;
            this.fechaNacimientoTextBox.Text = this.EntityPersona.FechaNacimiento.ToShortDateString();

        }
        private void LoadEntity(Persona persona)
        {
            persona.Nombre = this.nombreTextBox.Text;
            persona.Apellido = this.apellidoTextBox.Text;
            persona.Direccion = this.direccionTextBox.Text;
            persona.Email = this.emailTextBox.Text;
            persona.Telefono = this.telefonoTextBox.Text;
            persona.FechaNacimiento = Convert.ToDateTime(this.fechaNacimientoTextBox.Text);

        }
        private void SaveEntity(Persona persona)
        {
            this.Logic.Save(persona);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            if (ValidaCampos(this.FormMode))
            {
                switch (this.FormMode)
                {
                    case FormModes.Alta:
                        this.EntityPersona = new Persona();
                        this.LoadEntity(this.EntityPersona);
                        this.SaveEntity(this.EntityPersona);
                        this.LoadGrid();
                        break;


                    case FormModes.Baja:
                        this.EntityPersona = new Persona();
                        this.EntityPersona.IdPersona = this.SelectedID;
                        this.LoadEntity(this.EntityPersona);
                        this.DeleteEntity(EntityPersona, BusinessEntity.States.Deleted);
                        this.LoadGrid();
                        cambiaNombreBtn();
                        break;

                    case FormModes.CancelaBaja:
                        this.EntityPersona = new Persona();
                        this.EntityPersona.ID = this.SelectedID;
                        this.LoadEntity(this.EntityPersona);
                        this.DeleteEntity(EntityPersona, BusinessEntity.States.Undeleted);
                        this.LoadGrid();
                        cambiaNombreBtn();
                        break;

                    case FormModes.Modificacion:
                        this.EntityPersona = new Persona();
                        this.EntityPersona.IdPersona = this.SelectedID;
                        this.EntityPersona.State = BusinessEntity.States.Modified;
                        this.LoadEntity(this.EntityPersona);
                        this.SaveEntity(this.EntityPersona);
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
            this.nombreTextBox.Enabled = enable;
            this.apellidoTextBox.Enabled = enable;
            this.direccionTextBox.Enabled = enable;
            this.emailTextBox.Enabled = enable;
            this.telefonoTextBox.Enabled = enable;
            this.fechaNacimientoTextBox.Enabled = enable;
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
        private void DeleteEntity(Persona persona, BusinessEntity.States est)
        {
            this.Logic.Delete(persona, est);
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
            this.nombreTextBox.Text = string.Empty;
            this.apellidoTextBox.Text = string.Empty;
            this.direccionTextBox.Text = string.Empty;
            this.emailTextBox.Text = string.Empty;
            this.telefonoTextBox.Text = string.Empty;
            this.fechaNacimientoTextBox.Text = string.Empty;

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
            if (!Validaciones.campoLleno(nombreTextBox.Text))
            {
                correcto = false;
                nombreValidator.Text = "*";
            }
            else { nombreValidator.Text = ""; }

            if (!Validaciones.campoLleno(apellidoTextBox.Text))
            {
                correcto = false;
                apellidoValidator.Text = "*";
            }
            else { apellidoValidator.Text = ""; }

            if (!Validaciones.campoLleno(emailTextBox.Text))
            {
                correcto = false;
                emailValidator.Text = "*";
            }
            else if (!Validaciones.EsMailCorrecto(emailTextBox.Text))
            {
                correcto = false;
                emailValidator.Text = "Formato de email incorrecto";
            }
            else { emailValidator.Text = ""; }

            if (!Validaciones.campoLleno(direccionTextBox.Text))
            {
                correcto = false;
                direccionValidator.Text = "*";
            }
            else { direccionValidator.Text = ""; }

            if (!Validaciones.campoLleno(telefonoTextBox.Text))
            {
                correcto = false;
                telefonoValidator.Text = "*";
            }
            else { telefonoValidator.Text = ""; }

            if (!Validaciones.campoLleno(fechaNacimientoTextBox.Text))
            {
                correcto = false;
                fechaNacimientoValidator.Text = "*";
            }
            else { fechaNacimientoValidator.Text = ""; }
            
            return correcto;
        }
        private void LimpiarCampos()
        {
            nombreValidator.Text = "";
            apellidoValidator.Text = "";
            emailValidator.Text = "";
            direccionValidator.Text = "";
            telefonoValidator.Text = "";
            fechaNacimientoValidator.Text = "";
        }
    }
}