using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                navbarDropdownMenuLink3.Text = (Session["usuario"]).ToString();
            }
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