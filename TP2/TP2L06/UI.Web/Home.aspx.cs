using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if(Session["tipoUsu"].ToString() == "1") //Admin
                {
                    
                }

                else if (Session["tipoUsu"].ToString() == "2") //Alumno
                {
                    
                }

                else if (Session["tipoUsu"].ToString() == "3") //Docente
                {

                }
            }
        }
    }
}