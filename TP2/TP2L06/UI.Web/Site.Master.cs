using System;

namespace UI.Web
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                navbarDropdownMenuLink3.Text = (Session["usuario"]).ToString();

                if (Session["tipoUsu"].ToString() == "1") //Si es un alumno
                {
                    linkAlDocCursos.Enabled = false;
                    linkAlDocCursos.Visible = false;
                }
                else if (Session["tipoUsu"].ToString() == "2") //Si es un alumno
                {
                    noAdmin();
                }
                else if (Session["tipoUsu"].ToString() == "3") //Si es un docente
                {
                    noAdmin();
                }

            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void noAdmin()
        {
            linkPersonas.Enabled = false;
            linkPersonas.Visible = false;
            linkUsuarios.Enabled = false;
            linkUsuarios.Visible = false;
            linkEspecialidades.Enabled = false;
            linkEspecialidades.Visible = false;
            linkCursos.Enabled = false;
            linkCursos.Visible = false;
            linkReportes.Enabled = false;
            linkReportes.Visible = false;
            linkCursos.Enabled = false;
            linkCursos.Visible = false;
            linkInscribir.Enabled = false;
            linkInscribir.Visible = false;
        }

        protected void cerrarCesionLB_Click1(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
        }
    }
}