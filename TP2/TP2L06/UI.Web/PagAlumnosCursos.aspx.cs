using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;
using System.Security.Cryptography.X509Certificates;

namespace UI.Web
{
    public partial class AlumnosCursos : Page
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
            set { _alumnoCurso = value; }
        }

        AlumnoCurso _EntityAlumnoCurso;

        private AlumnoCurso EntityAlumnoCurso
        {
            get
            {
                if (_EntityAlumnoCurso == null)
                {
                    _EntityAlumnoCurso = new AlumnoCurso();
                }
                return _EntityAlumnoCurso;
            }

            set { _EntityAlumnoCurso = value; }
        }


        //////////////////////////  Informacion de DOCENTE CURSO  //////////////////////////

        DocenteCursoLogic _docenteCurso;
        private DocenteCursoLogic DocenteCurso
        {
            get
            {
                if (_docenteCurso == null)
                {
                    _docenteCurso = new DocenteCursoLogic();
                }
                return _docenteCurso;
            }
        }

        AlumnoCurso _EntityDocenteCurso;

        private DocenteCurso EntityDocenteCurso
        {
            get;
            set;
        }

        //////////////////////////  Informacion de CURSO  //////////////////////////


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

        //////////////////////////  Informacion de materia  //////////////////////////


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

        //////////////////////////  Informacion de Comision  //////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Page_Load(object sender, EventArgs e)            
        {
            if (Session["usuario"] == null)         //Si no estas logueado te saca
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (Session["tipoUsu"].ToString() == "1") //Si sos admin
                {

                    if (!this.IsPostBack)
                    {
                        showAdminSelectionPage();       //Muestra panel de opciones del admin
                    }
                    else
                    {

                    }
                                                 
                }

                else if (Session["tipoUsu"].ToString() == "2")  //Si sos alumno
                {
                    if (!this.IsPostBack)
                    {
                        LoadGridMaterias();       
                    }
                    else
                    {

                    }
                }
                else if (Session["tipoUsu"].ToString() == "3")  //Si sos docente
                {
                    if (!this.IsPostBack)
                    {
                        LoadGridMaterias();       
                    }
                    else
                    {

                    }
                }
                else
                {
                    //Si no sos admin/docente/alumno te saca
                    Response.Redirect("Home.aspx");
                }
            }
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
            this.SelectedTipoUsuario = 0;
            Session["tipoUsuarioAModificar"] = "";
        }

        private void limpiarIdComision()
        {
            this.SelectedIdComision = 0;
        }

        private void limpiarIdMateria()
        {
            this.SelectedIdMateria = 0;
        }



        //////////////////////////  MATERIA: Seleccion de materia en el gridview //////////////////////////


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


        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)        //Indice del grid que muestra las materias
        {
            this.SelectedIdMateria = (int)this.gridView.SelectedValue;           
        }

        
        protected void seleccionarMateriaLinkButton_Click(object sender, EventArgs e)      //Seleccionar materia inscribirseLinkButton
        {
            if (this.IsEntityMateriaSelected)
            {
                //this.EnableForm(true, true);
                this.FormMode = FormModes.Alta;
                this.LoadForm(this.SelectedIdMateria);

                if (Session["tipoUsuario"] == "3")
                {
                    this.showCargosDDL();
                }
            }
        }

        protected void cancelarMateriaLinkButton_Click(object sender, EventArgs e)
        {
            limpiarIdMateria();
            this.hideMateriasPage();

            if (Session["tipoUsu"].ToString() == "1")
            {
                this.limpiarVariables();
                this.showAdminSelectionPage();
            }
            else
            {
                limpiarVariables();
                Response.Redirect("Home.aspx");
            }
                
                
        }

        private void hideMateriasPage()
        {

            this.gridPanel.Visible = false;
            this.gridPanel.Enabled = false;

            this.gridActionsPanel.Visible = false;
            this.gridActionsPanel.Enabled = false;
        }

        private void showMateriasPage()
        {
            this.gridPanel.Visible = true;
            this.gridPanel.Enabled = true;

            this.gridActionsPanel.Visible = true;
            this.gridActionsPanel.Enabled = true;
        }

        private void LoadGridMaterias()                            //Carga el grid de materias
        {

            this.gridPanel.Visible = true;
            this.gridPanel.Enabled = true;

            this.gridPanel.DataBind();


            this.gridActionsPanel.Visible = true;
            this.gridActionsPanel.Enabled = true;
    
        }


        //////////////////////////  Comision: Seleccion de comision en el gridview //////////////////////////


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



        private void LoadGridComision()                                     
        {
            this.gridComision.DataSource = this.ComisionLogic.GetComisionesPorCurso(this.SelectedIdMateria);
            this.gridComision.DataBind();

            this.comisionPanel.Enabled = true;
            this.comisionPanel.Visible = true;

            this.gridComision.Enabled = true;
            this.gridComision.Visible = true;

            this.panelInscripcionCursado.Enabled = true;
            this.panelInscripcionCursado.Visible = true;

            if (Session["tipoUsuarioAModificar"].ToString() == "3")    //Si es docente te muestra el DDL de cargos
            {

                this.showCargosDDL();
     
            }
            else if(Session["tipoUsu"].ToString() == "3")
            {
                this.showCargosDDL();
            }
            else
            {

            }

        }

        private void showCargosDDL()
        {
            this.cargosDDL.Visible = true;
            this.cargosDDL.Enabled = true;
        }

        private void hideCargosDDL()
        {
            this.cargosDDL.Visible = false;
            this.cargosDDL.Enabled = false;
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


        protected void aceptarLinkButton_Click(object sender, EventArgs e)          //Ingresa comision
        {

            if (IsEntityComisionSelected)
            {

                if (Session["tipoUsu"].ToString() == "1")           //Admin
                {

                    if(Session["tipoUsuarioAModificar"].ToString() == "2")
                    {
                        this.EntityAlumnoCurso = new AlumnoCurso();

                        this.LoadAlumnoCursoEntity(this.EntityAlumnoCurso);
                        this.SaveAlumnoCursoEntity(this.EntityAlumnoCurso);

                    }
                    else
                    {
                        this.EntityDocenteCurso = new DocenteCurso();

                        this.LoadDocenteCursoEntity(this.EntityDocenteCurso);
                        this.SaveDocenteCursoEntity(this.EntityDocenteCurso);

                        //Response.Redirect("PagAlumnosCursos.aspx");
                    }

                }
                else if (Session["tipoUsu"].ToString() == "2")              //Alumno
                {
                    
                    
                    this.EntityCurso = this.Curso.BuscarCursoPorMateriaComision(SelectedIdMateria, SelectedIdComision);

                    this.AlumnoCurso = new AlumnoCursoLogic();
                    
                    this.EntityAlumnoCurso.IdCurso = this.EntityCurso.IdCurso;
                    this.EntityAlumnoCurso.IdUsuario = Convert.ToInt32(Session["idUsuario"]);
                }
                else if (Session["tipoUsu"].ToString() == "3")  //Profesor
                {
                    this.EntityDocenteCurso = new DocenteCurso();



                    this.LoadAlumnoCursoEntity(this.EntityAlumnoCurso);
                    this.SaveAlumnoCursoEntity(this.EntityAlumnoCurso);
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


        private void LoadForm(int idMateria)                //Carga form comision
        {

            if(this.IsEntityMateriaSelected && !this.IsEntityComisionSelected)      //Muestra el grid de comision
            {
                this.hideMateriasPage();
                LoadGridComision();

            }
            else if (this.IsEntityMateriaSelected && this.IsEntityComisionSelected)     //Guarda
            {
                //Muestra un formulario modal (a hacer) que diga que salió todo ok y preguntar si quiere volver a inscribirse
            }
                   
        }



        ////////////////////////// Inscripcion Alumno //////////////////////////
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

            bool codigo = this.AlumnoCurso.Save(alumnoCursoActual);

            if (codigo)
            {
                //Response.Write("\n\nAlumno inscripto con éxito!");
                this.limpiarVariables();
                Response.Redirect("Home.aspx");
            }
            else
            {
                Response.Write("\n\nEl alumno ya está inscripto en este curso.");
            }

        }


        ////////////////////////// Inscripcion Docente  //////////////////////////


        private void LoadDocenteCursoEntity(DocenteCurso docenteCursoActual)    //DOCENTE
        {
            this.EntityCurso = this.Curso.BuscarCursoPorMateriaComision(SelectedIdMateria, SelectedIdComision);     //Obtenemos el objeto curso para usar el id

            docenteCursoActual.IdCurso = this.EntityCurso.IdCurso;
            docenteCursoActual.IdUsuario = Convert.ToInt32(Session["idUsuario"]);
            //docenteCursoActual.Cargos = Convert.ToInt32(cargosDDL.SelectedValue);
            //docenteCursoActual.Cargos = Convert.ToInt32(this.cargosDDL.SelectedValue.ToString());

        }

        private void SaveDocenteCursoEntity(DocenteCurso docenteCursoActual)
        {
            //this.DocenteCurso.Save(docenteCursoActual);
            bool codigo = this.DocenteCurso.Save(docenteCursoActual);

            if (codigo)
            {
                //Response.Write("\n\nDocente inscripto con éxito!");
                this.limpiarVariables();
                Response.Redirect("Home.aspx");
            }
            else
            {
                Response.Write("\n\nEl docente ya está inscripto en este curso.");
            }

        }




        ////////////////////////// ADMIN: Bloque selección de usuario en DDL  //////////////////////////
        private int SelectedTipoUsuario
        {
            get;
            set;
        }
        protected void seleccionRadioButtonList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedTipoUsuario = Convert.ToInt32(this.seleccionRadioButtonList.SelectedValue);
        }

        private void showAdminSelectionPage()
        {
            this.panelAdmin.Enabled = true;
            this.panelAdmin.Visible = true;
        }


        private void hideAdminSelectionPage()
        {
            this.panelAdmin.Enabled = false;
            this.panelAdmin.Visible = false;
        }

        protected void aceptarSeleccionAdminLinkButton_Click(object sender, EventArgs e)
        {
            if (this.seleccionRadioButtonList.SelectedValue != null)
            {
                showDDL(this.seleccionRadioButtonList.SelectedValue.ToString());
                this.panelAdmin.Enabled = false;
                Session["tipoUsuarioAModificar"] = this.seleccionRadioButtonList.SelectedValue.ToString();
            }
        }

        protected void cancelarSeleccionAdminLinkButton_Click(object sender, EventArgs e)
        {
            this.limpiarVariables();
            Response.Redirect("Home.aspx");

            //this.panelAdmin.Enabled = true;
            //hideDDLs();
            //Response.Redirect("Home.aspx");
        }


        private void showDDL(string seleccion)
        {
            if (seleccion == "2") //Carga DDL Alumno
            {
                this.panelDDL.Visible = true;
                this.panelDDL.Enabled = true;

                this.DocentesDDL.Visible = false;
                this.AlumnosDDL.Enabled = true;
                this.AlumnosDDL.Visible = true;

                this.panelSeleccionDeUsuario.Visible = true;
                this.panelSeleccionDeUsuario.Enabled = true;

                Session["tipoUsuarioAModificar"] = seleccion;

                AlumnosDDL.DataBind();
            }
            else if (seleccion == "3") //Carga DDL Docente
            {
                this.panelDDL.Visible = true;
                this.panelDDL.Enabled = true;

                this.AlumnosDDL.Visible = false;
                this.DocentesDDL.Visible = true;
                this.DocentesDDL.Enabled = true;

                this.panelSeleccionDeUsuario.Visible = true;
                this.panelSeleccionDeUsuario.Enabled = true;

                Session["tipoUsuarioAModificar"] = seleccion;

                AlumnosDDL.DataBind();
            }

            else
            {
                //No selecciono nada
            }
        }

        private void hideDDLs()
        {
            this.panelDDL.Visible = false;
            this.panelDDL.Enabled = false;
        }


        protected void ingresarUsuarioLinkButton_Click(object sender, EventArgs e) 
        {
            this.hideAdminSelectionPage();
            this.hideDDLs();
            this.LoadGridMaterias();
        }

        protected void cancelarUsuarioLinkButton_Click(object sender, EventArgs e) 
        {
            this.showAdminSelectionPage();
            this.hideDDLs();
           
        }
    }
}
