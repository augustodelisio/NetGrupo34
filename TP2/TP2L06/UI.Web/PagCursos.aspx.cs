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
    public partial class PagCursos : Page
    {
        CursoLogic _logic;
        private CursoLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new CursoLogic();
                }
                return _logic;
            }
        }

        Curso _EntityCurso;

        private Curso EntityCurso
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
            this.EntityCurso = this.Logic.GetOne(idUsr);
            this.anioTextBox.Text = this.EntityCurso.AnioCalendario.ToString();
            this.cupoTextBox.Text = this.EntityCurso.Cupo.ToString();
            this.descripcionTextBox.Text = this.EntityCurso.Descripcion;
            this.ListarPersonas();
            this.ListarTiposCursos();

            try
            {
                int idMat = EntityCurso.IdMateria;
                var mat = new MateriaLogic().GetOne(idMat);
                idMateriaDDL.SelectedValue = mat.IdMateria.ToString();
                idMateriaDDL.DataBind();

                int idCom = EntityCurso.IdComision;
                var com = new ComisionLogic().GetOne(idCom);
                idComisionDDL.SelectedValue = com.IdComision.ToString();
                idComisionDDL.DataBind();
            }
            catch
            {
                Console.WriteLine("Error al cargar personas o tipos de curso");
            }
        }

        private void LoadEntity(Curso curso)
        {
            curso.AnioCalendario = Convert.ToInt32(this.anioTextBox.Text);
            curso.Cupo = Convert.ToInt32(this.cupoTextBox.Text);
            curso.Descripcion = this.descripcionTextBox.Text;
            curso.IdMateria = Convert.ToInt32(idMateriaDDL.SelectedValue.ToString());
            curso.IdComision = Convert.ToInt32(idComisionDDL.SelectedValue.ToString());
        }

        private void SaveEntity(Curso curso)
        {
            this.Logic.Save(curso);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            if (ValidaCampos(this.FormMode))
            {
                switch (this.FormMode)
                {
                    case FormModes.Alta:
                        this.EntityCurso = new Curso();
                        this.LoadEntity(this.EntityCurso);
                        this.EntityCurso.Habilitado = true;
                        this.SaveEntity(this.EntityCurso);
                        this.LoadGrid();
                        break;

                    case FormModes.Baja:
                        this.EntityCurso = new Curso();
                        this.EntityCurso.IdCurso = this.SelectedID;
                        this.LoadEntity(this.EntityCurso);
                        this.DeleteEntity(EntityCurso, BusinessEntity.States.Deleted);
                        this.LoadGrid();
                        cambiaNombreBtn();
                        break;

                    case FormModes.CancelaBaja:
                        this.EntityCurso = new Curso();
                        this.EntityCurso.IdCurso = this.SelectedID;
                        this.LoadEntity(this.EntityCurso);
                        this.DeleteEntity(EntityCurso, BusinessEntity.States.Undeleted);
                        this.LoadGrid();
                        cambiaNombreBtn();
                        break;

                    case FormModes.Modificacion:
                        this.EntityCurso = new Curso();
                        this.EntityCurso.IdCurso = this.SelectedID;
                        this.EntityCurso.State = BusinessEntity.States.Modified;
                        this.LoadEntity(this.EntityCurso);
                        //Guardo hab según el valor que tiene en el grid view
                        this.EntityCurso.Habilitado = Convert.ToBoolean(this.gridView.SelectedRow.Cells[4].Text);
                        this.SaveEntity(this.EntityCurso);
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
            this.anioTextBox.Enabled = enable;
            this.cupoTextBox.Enabled = enable;
            this.descripcionTextBox.Enabled = enable;
            this.idMateriaDDL.Enabled = enable;
            this.idComisionDDL.Enabled = enable;
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
                this.LoadForm(this.SelectedID);
            }
        }

        private void DeleteEntity(Curso curso, BusinessEntity.States est)
        {
            this.Logic.Delete(curso, est);
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.formActionPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true, true);
            ListarPersonas();
            ListarTiposCursos();
        }

        private void ClearForm()
        {
            this.anioTextBox.Text = string.Empty;
            this.cupoTextBox.Text = string.Empty;
            this.descripcionTextBox.Text = string.Empty;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.ClearForm();
            this.formPanel.Visible = false;
            this.formActionPanel.Visible = false;
        }

        private void ListarPersonas()
        {
            var materias = new MateriaLogic().GetAll();
            idMateriaDDL.DataSource = materias;
            idMateriaDDL.DataValueField = "IdMateria";
            idMateriaDDL.DataTextField = "Descripcion";
            idMateriaDDL.DataBind();
        }

        private void ListarTiposCursos()
        {
            var comisiones = new ComisionLogic().GetAll();
            idComisionDDL.DataSource = comisiones;
            idComisionDDL.DataValueField = "IdComision";
            idComisionDDL.DataTextField = "Descripcion";
            idComisionDDL.DataBind();
        }

        private bool ValidaCampos(FormModes modo)
        {
            var correcto = true;
            if (!Validaciones.campoLleno(anioTextBox.Text))
            {
                correcto = false;
                anioValidator.Text = "*";
            }
            else { anioValidator.Text = ""; }

            if (!Validaciones.campoLleno(descripcionTextBox.Text))
            {
                correcto = false;
                descripcionValidator.Text = "*";
            }
            else { descripcionValidator.Text = ""; }

            if (!Validaciones.campoLleno(cupoTextBox.Text))
            {
                correcto = false;
                cupoValidator.Text = "*";
            }
            else { cupoValidator.Text = ""; }

            return correcto;
        }
        private void LimpiarCampos()
        {
            anioValidator.Text = "";
            descripcionValidator.Text = "";
            cupoValidator.Text = "";
        }
    }
}