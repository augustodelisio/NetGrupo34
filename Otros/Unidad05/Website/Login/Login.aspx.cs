using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if(txtUsuario.Text.ToLower() == "admin" && this.txtClave.Text == "admin")
            {
                Page.Response.Write("Ingreso OK");
            }
            else
            {
                Page.Response.Write("Usuario y/o clave incorrectos");
            }
        }

        protected void lnkRecordarClave_Click(object sender, EventArgs e)
        {
            //Redirecciono a otra pag. que debería existir y para mostrar el mensaje tener dicho elemento.
            Response.Redirect("~/Default.aspx?msj=Es ud. un usuario muy descuidado, haga memoria");
        }
    }
}