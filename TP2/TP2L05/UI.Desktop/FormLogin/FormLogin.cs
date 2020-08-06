using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class FormLogin : ApplicationForm
    {
    
        public FormLogin()
        {
            InitializeComponent();
        }

        private Usuario ValidarUsuario(string nombreUsu, string clave)

        //Valida que los datos proporcionados por el usuario se correspondan a un usuario en la DB
        //si lo encuentra devuelve el objeto usuario, sino devuelve null

        {
            Usuario usuAValidar = new Usuario();
            usuAValidar.NombreUsuario = nombreUsu;
            usuAValidar.Clave = clave;

            List<Usuario> usuariosObtenidos = new List<Usuario>();

            UsuarioLogic usu = new UsuarioLogic();

            usuariosObtenidos = usu.GetAll();   //Nos devuelve la lista de usuarios en la base de datos

            foreach (var usuario in usuariosObtenidos)
            {
                if (usuario.NombreUsuario == usuAValidar.NombreUsuario)
                {
                    if (usuario.Clave == usuAValidar.Clave)
                    {
                        return usuario;
                    }
                }
            }

            return null;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            string nombreUsu = this.txtUsuario.Text;
            string claveUsu = this.txtPass.Text;

            if (this.ValidarUsuario(nombreUsu, claveUsu) != null)
            {

                this.DialogResult = DialogResult.OK;

            }
            else
            {
                MessageBox.Show("El usuario o la contraseña son incorrectos, " +
                    "verifique haberlos ingresado correctamente", "Error de ingreso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void lnkOlvidaPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Es Ud. un usuario muy descuidado, haga memoria", "Olvidé mi contraseña",
            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}

