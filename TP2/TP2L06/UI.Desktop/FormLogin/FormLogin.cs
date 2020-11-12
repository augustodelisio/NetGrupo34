using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class FormLogin : ApplicationForm
    {
        public int IdUsu { get; set; }
        public int Tipo { get; set; }
        public FormLogin()
        {
            InitializeComponent();
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
            catch (Exception Ex)
            {
                Notificar(Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (null, false);
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string nombreUsu = this.txtUsuario.Text;
            string claveUsu = this.txtPass.Text;

            (Usuario usu, bool con) = this.ValidarUsuario(nombreUsu, claveUsu);

            if (con == true)//Si se estableció correctamente la conexión a BD
            {
                if (usu != null)//Y se validó el usuario
                {
                    this.IdUsu = usu.ID;
                    this.Tipo = usu.IdTipoUsuario;
                    this.DialogResult = DialogResult.OK;
                }
                else//Si no se encontro dicho usuario en la BD o se ingreso mal la clave
                {
                    Notificar("Error de ingreso", "El usuario o la contraseña son incorrectos, " +
                        "vuelva a ingresarlos.",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void lnkOlvidaPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Notificar("Olvidé mi contraseña", "Es Ud. un usuario muy descuidado, haga memoria.",
            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}

