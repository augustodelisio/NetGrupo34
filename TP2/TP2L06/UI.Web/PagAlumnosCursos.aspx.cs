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
    public partial class AlumnosCursos : System.Web.UI.Page
    {

        //////////////////////////Informacion de ALUMNO CURSO//////////////////////////

        AlumnoCursoLogic _alumnoCurso;
        private AlumnoCursoLogic AlumnoCurso
        {
            get
            {
                if (_alumnoCurso == null)
                {
                    _alumnoCurso = new AlumnoCursoLogic();
                }
                return _alumnoCurso;
            }
        }

        AlumnoCurso _EntityAlumnoCurso;

        private AlumnoCurso EntityAlumnoCurso
        {
            get;
            set;
        }

        //////////////////////////Informacion de curso//////////////////////////


        CursoLogic _curso;
        private CursoLogic Curso
        {
            get
            {
                if (_curso == null)
                {
                    _curso = new CursoLogic();
                }
                return _curso;
            }
        }

        Curso _EntityCurso;

        private Curso EntityCurso
        {
            get;
            set;
        }

        //////////////////////////Informacion de materia//////////////////////////


        MateriaLogic _materiaLogic;
        private MateriaLogic MateriaLogic
        {
            get
            {
                if (_materiaLogic == null)
                {
                    _materiaLogic = new MateriaLogic();
                }
                return _materiaLogic;
            }
        }

        AlumnoCurso _EntityMateria;

        private MateriaLogic EntityMateria
        {
            get;
            set;
        }

        //////////////////////////Informacion de Comision//////////////////////////

        ComisionLogic _comisionLogic;
        private ComisionLogic ComisionLogic
        {
            get
            {
                if (_comisionLogic == null)
                {
                    _comisionLogic = new ComisionLogic();
                }
                return _comisionLogic;
            }
        }

        AlumnoCurso _EntityComision;

        private ComisionLogic EntityComision
        {
            get;
            set;
        }

        //////////////////////////////////////////////////////////////////////////////

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
            LoadGridMaterias();
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

        private void limpiarVariables()
        {
            this.SelectedIdMateria = 0;
            this.SelectedIdComision = 0;
        }

        private void limpiarIdComision()
        {
            this.SelectedIdComision = 0;
        }

        private void limpiarIdMateria()
        {
            this.SelectedIdMateria = 0;
        }



        //////////////////////////  Primer pantalla (Elección de Materia) //////////////////////////


        private int SelectedIdMateria
        {
            get
            {
                if (this.ViewState["SelectedIdMateria"] != null)
                {
                    return (int)this.ViewState["SelectedIdMateria"];
                }
                else return 0;
            }

            set
            {
                this.ViewState["SelectedIdMateria"] = value;
            }
        }

        private bool IsEntityMateriaSelected
        {
            get { return (this.SelectedIdMateria != 0); }
        }


        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedIdMateria = (int)this.gridView.SelectedValue;
            //cambiaNombreBtn();
        }


        protected void inscribirseLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntityMateriaSelected)
            {
                this.EnableForm(true, true);
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedIdMateria);
            }
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            limpiarIdMateria();
            
            Response.Redirect("https://localhost:44313/Home.aspx"); //No se que otra manera hay de redireccionarlo al home
        }

        private void LoadGridMaterias()                                     //Aca hay que cargar las materias -->   ( * | Materia | Año)
        {
            this.gridView.DataSource = this.MateriaLogic.GetAll();
            this.gridView.DataBind();

            this.gridPanel.Enabled = true;
            this.gridPanel.Visible = true;

            this.gridView.Enabled = true;
            this.gridView.Visible = true;

            this.gridActionsPanel.Enabled = true;
            this.gridActionsPanel.Visible = true;
        }



        private void hideMateriasGrid()
        {
            this.gridPanel.Enabled = false;
            this.gridPanel.Visible = false;
            
            this.gridView.Enabled = false;
            this.gridView.Visible = false;

            this.gridActionsPanel.Enabled = false;
            this.gridActionsPanel.Visible = false;

        }


        //////////////////////////  Segunda pantalla (Elección de Comisión) //////////////////////////


        private int SelectedIdComision
        {
            get
            {
                if (this.ViewState["SelectedIdComision"] != null)
                {
                    return (int)this.ViewState["SelectedIdComision"];
                }
                else return 0;
            }

            set
            {
                this.ViewState["SelectedIdComision"] = value;
            }
        }

        private bool IsEntityComisionSelected
        {
            get { return (this.SelectedIdComision != 0); }
        }



        private void LoadGridComision()                                     //Aca hay que cargar las Comisiones -->   ( * | Comision | Año | ID)
        {
            this.gridComision.DataSource = this.ComisionLogic.GetComisionesPorCurso(this.SelectedIdMateria);     
            this.gridComision.DataBind();



            this.comisionPanel.Enabled = true;
            this.comisionPanel.Visible = true;

            this.gridComision.Enabled = true;
            this.gridComision.Visible = true;

            this.panelInscripcionCursado.Enabled = true;
            this.panelInscripcionCursado.Visible = true;
        }

        private void hideComisionGrid()
        {
            this.comisionPanel.Enabled = false;
            this.comisionPanel.Visible = false;

            this.gridComision.Enabled = false;
            this.gridComision.Visible = false;

            this.panelInscripcionCursado.Enabled = false;
            this.panelInscripcionCursado.Visible = false;

        }



        protected void gridComision_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedIdComision = (int)this.gridComision.SelectedValue;
            //cambiaNombreBtn();
        }



        private void EnableForm(bool enable, bool en2)
        {
            this.gridComision.Enabled = enable;
            this.aceptarLinkButton.Enabled = enable;
            this.cancelarCursoLinkButton.Enabled = enable;

        }


        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {

            if (IsEntityComisionSelected)
            {

                if (Session["tipoUsu"].ToString() == "1")           //Admin
                {

                    //Buscar usuario a inscribir o borrar                   
                    
                    //BORRAR. Este codigo va en alumno 

                    this.EntityAlumnoCurso = new AlumnoCurso();



                    this.LoadAlumnoCursoEntity(this.EntityAlumnoCurso);
                    this.SaveAlumnoCursoEntity(this.EntityAlumnoCurso);
                    //this.LoadGrid();


                }
                else if (Session["tipoUsu"].ToString() == "2")              //Alumno
                {
                    this.EntityCurso = this.Curso.BuscarCursoPorMateriaComision(SelectedIdMateria, SelectedIdComision);
                    
                    this.EntityAlumnoCurso.IdCurso = this.EntityCurso.IdCurso;
                    this.EntityAlumnoCurso.IdUsuario = Convert.ToInt32(Session["idUsuario"]);
                }
                else if (Session["tipoUsu"].ToString() == "3")  //Profesor
                {

                }
                else
                {
                    Response.Redirect("Login.aspx"); //Si no está logueado.
                }
            }
        }


        protected void cancelarCursoLinkButton_Click(object sender, EventArgs e)
        {
            limpiarIdComision();
            hideComisionGrid();
            LoadGridMaterias();
        }


        private void LoadForm(int idMateria)
        {

            if(this.IsEntityMateriaSelected && !this.IsEntityComisionSelected)
            {
                hideMateriasGrid();
                LoadGridComision();
            }
            else if (this.IsEntityMateriaSelected && this.IsEntityComisionSelected)
            {
                //Muestra un formulario modal (a hacer) que diga que salió todo ok y preguntar si quiere volver a inscribirse
            }
            else if(!this.IsEntityMateriaSelected && !this.IsEntityComisionSelected)
            {
                // Vuelve?
            }
                   
        }

        //protected void cambiaNombreBtn()
        //{
        //    if (this.SelectedID > 0)
        //    {
        //        if (SelectedHab)
        //        {
        //            this.elimiarLinkButton.Text = "Eliminar";
        //        }
        //        else
        //        {
        //            this.elimiarLinkButton.Text = "Habilitar";
        //        }
        //    }
        //}

        private void LoadAlumnoCursoEntity(AlumnoCurso alumnoCursoActual)
        {
            this.EntityCurso = this.Curso.BuscarCursoPorMateriaComision(SelectedIdMateria, SelectedIdComision);     //Obtenemos el objeto curso para usar el id

            alumnoCursoActual.IdCurso = this.EntityCurso.IdCurso;
            alumnoCursoActual.IdUsuario = Convert.ToInt32(Session["idUsuario"]);
            alumnoCursoActual.Nota = 0;
            alumnoCursoActual.Condicion = "Inscripto";

        }

        private void SaveAlumnoCursoEntity(AlumnoCurso alumnoCursoActual)
        {

                this.AlumnoCurso.Save(alumnoCursoActual);

        }
    }
}
