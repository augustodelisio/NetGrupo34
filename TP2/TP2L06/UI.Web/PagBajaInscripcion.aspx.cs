using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;
using System.Web.Configuration;

namespace UI.Web
{
    public partial class PagBajaInscripcion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private AlumnoCurso alumnoCursoActual;

        public AlumnoCurso AlumnoCursoActual { get => alumnoCursoActual; set => alumnoCursoActual = value; }
        public DocenteCurso DocenteCursoActual { get => docenteCursoActual; set => docenteCursoActual = value; }

        private DocenteCurso docenteCursoActual;

        private void ListarInscripciones()
        {
            if (Session["tipoUsu"].ToString() == "1")
            {
               
            }
            else if(Session["tipoUsu"].ToString() == "2")
            {

            }
            else if(Session["tipoUsu"].ToString() == "3")
            {

            }
            else
            {
                this.Dispose();
                Response.Redirect("Login.aspx");
            }
        }

        //Session["tipoUsu"] = usu.IdTipoUsuario;
        //        Session["idUsuario"] = usu.ID;
        //        Session["tipoUsuarioAModificar"] = "";
    }
}