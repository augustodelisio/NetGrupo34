﻿using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string nombreUsu = this.txtUsuario.Text;
            string claveUsu = this.txtClave.Text;

            (Usuario usu, bool con) = this.ValidarUsuario(nombreUsu, claveUsu);

            if (con == true)//Si se estableció correctamente la conexión a BD
            {
                if (usu != null)//Y se validó el usuario
                {
                    Page.Response.Write("Usuario encontrado");
                    Session["usuario"] = nombreUsu;
                    Session["tipoUsu"] = usu.IdTipoUsuario;
                    Session["idUsuario"] = usu.ID;
                    Session["tipoUsuarioAModificar"] = "";
                    Response.Redirect("Home.aspx");
                }
                else//Si no se encontro dicho usuario en la BD o se ingreso mal la clave
                {
                    Page.Response.Write("Usuario y/o clave incorrectos");
                }
            }
        }

        private (Usuario, bool) ValidarUsuario(string nombreUsu, string clave)

        //Valida que los datos proporcionados por el usuario se correspondan a un usuario en la DB
        //si lo encuentra devuelve el objeto usuario, sino devuelve null

        {
            Usuario usuAValidar = new Usuario();
            usuAValidar.NombreUsuario = nombreUsu;
            usuAValidar.Clave = clave;

            List<Usuario> usuariosObtenidos = new List<Usuario>();

            UsuarioLogic usu = new UsuarioLogic();
            try
            {
                usuariosObtenidos = usu.GetAll();   //Nos devuelve la lista de usuarios en la base de datos

                foreach (var usuario in usuariosObtenidos)
                {
                    if (usuario.NombreUsuario == usuAValidar.NombreUsuario)
                    {
                        if (usuario.Clave == usuAValidar.Clave)
                        {
                            return (usuario, true);//El segundo parametro representa si se estableció conexión con la BD.
                        }
                    }
                }
                return (null, true);
            }
#pragma warning disable CS0168 // La variable 'Ex' se ha declarado pero nunca se usa
            catch (Exception Ex)
#pragma warning restore CS0168 // La variable 'Ex' se ha declarado pero nunca se usa
            {
                Page.Response.Write("Error de conexion con la BD.");
                return (null, false);
            }
        }

        protected void lnkRecordarClave_Click(object sender, EventArgs e)
        {
            //Redirecciono a otra pag. que debería existir y para mostrar el mensaje tener dicho elemento.
            Response.Redirect("~/Default.aspx?msj=Es ud. un usuario muy descuidado, haga memoria");
        }
    }
}