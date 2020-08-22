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
using System.Text.RegularExpressions;
using Util;

namespace UI.Desktop
{
    
    public partial class UsuarioDesktop : ApplicationForm
    {
        private Usuario _UsuarioActual;
        public Usuario UsuarioActual { set; get; }

        public UsuarioDesktop()
        {
            InitializeComponent();
        }
        public UsuarioDesktop(ModoForm modo) : this()
        {
        }
        public UsuarioDesktop(int ID, ModoForm modo) : this()    
        {
            UsuarioLogic ul = new UsuarioLogic();
            this.Modo = modo;                               //Setea el valor en el que se encuentra el formulario (A/B/M/C)   
            this.UsuarioActual = ul.GetOne(ID);             //Obtiene el usuario que tenga el ID pasado por parametro desde la capa de datos
            this.MapearDeDatos();                           //Setea los valores correspondientes al estado del formulario en el form "UsuarioDesktop"
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.txtLegajo.Text = this.UsuarioActual.Legajo.ToString();          
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            this.txtClave.Text = this.UsuarioActual.Clave;
            this.txtConfirmarClave.Text = this.UsuarioActual.Clave;
            //El combobox persona se rellena despues, en el load del formulario
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion) 
            {
                this.btnAceptar.Text = "Guardar";
            }
            else if (Modo == ModoForm.Baja)
            {
                this.btnAceptar.Text = "Deshabilitar";
            }
            else if (Modo == ModoForm.CancelaBaja)
            {
                this.btnAceptar.Text = "Habilitar";
            }
            else if (Modo == ModoForm.Consulta)
            {
                this.btnAceptar.Text = "Aceptar";
            }
        }

        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)         //Aca deberia entrar en ModoForm.Modificacion pero no lo hace
            {
                if (Modo == ModoForm.Modificacion)
                {
                    try 
                    { 
                        this.UsuarioActual.ID = int.Parse(this.txtID.Text);
                        UsuarioActual.State = BusinessEntity.States.Modified;

                    }
                    catch(Exception Ex)
                    {
                        Console.WriteLine(Ex.Message); //Modificar esta excepcion para que tire un error mas especifico y haga un throw
                    }
                    

                }
                else
                {
                    Usuario usu = new Usuario();
                    UsuarioActual = usu;
                    UsuarioActual.State = BusinessEntity.States.New;
                    UsuarioActual.Habilitado = true;
                }
                
                this.UsuarioActual.Legajo = Convert.ToInt32(this.txtLegajo.Text);
                
                int fid;
                fid = Convert.ToInt32(cbPersonas.SelectedValue.GetHashCode());
                this.UsuarioActual.IdPersona = fid;

                fid = Convert.ToInt32(cbTipoUsuario.SelectedValue.GetHashCode());
                this.UsuarioActual.IdTipoUsuario = fid;
                
                this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                this.UsuarioActual.Clave = this.txtClave.Text;

            }
            else if (Modo == ModoForm.Baja)
            {
                UsuarioActual.State = BusinessEntity.States.Deleted;
            }
            else if (Modo == ModoForm.CancelaBaja)
            {
                UsuarioActual.State = BusinessEntity.States.Undeleted;
            }
            else if (Modo == ModoForm.Consulta)
            {
                UsuarioActual.State = BusinessEntity.States.Unmodified;
            }
            
        }
        public override void GuardarCambios()
        {
            this.MapearADatos();
            UsuarioLogic usu = new UsuarioLogic();
            usu.Save(UsuarioActual);
        }
        public override bool Validar()
        {
            bool correcto = true;
            if (String.IsNullOrEmpty(this.txtLegajo.Text) || this.txtClave.Text.Length <8 || String.IsNullOrEmpty(this.txtUsuario.Text))
                correcto = false;
            if (this.txtClave.Text != this.txtConfirmarClave.Text)
                correcto = false;
            //if (Validaciones.EsMailCorrecto(this.txtIdTipoUsuario.Text) == false)
            //    correcto = false;

            if (correcto == false)
                this.Notificar("Error, campos incompletos / clave<8 o mal repetida", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return correcto;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool res = this.Validar();
            if (res)
            {
                this.GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarCombobox()
        {
            //Rellenar ComboBox Personas
            this.cbPersonas.DataSource = null;
            PersonaLogic perLogic = new PersonaLogic();
            this.cbPersonas.DataSource = perLogic.GetAll();
            this.cbPersonas.DisplayMember = "NombreYApellido";
            this.cbPersonas.ValueMember = "IdPersona";

            this.cbTipoUsuario.DataSource = null;
            TipoUsuarioLogic tipoUsuLogic = new TipoUsuarioLogic();
            this.cbTipoUsuario.DataSource = tipoUsuLogic.GetAll();
            this.cbTipoUsuario.DisplayMember = "Descripcion";
            this.cbTipoUsuario.ValueMember = "IdTipoUsuario";
        }

        private void UsuarioDesktop_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;

            CargarCombobox();

            if (this.Modo != ModoForm.Alta)//Si NO es una alta, cargo el nombre de la persona que estamos editando.
            {
                PersonaLogic pl = new PersonaLogic();
                string nomPer = pl.GetOne(UsuarioActual.IdPersona).NombreYApellido;//Busco el nombre de la persona de dicho usuario.
                this.cbPersonas.SelectedIndex = cbPersonas.FindStringExact(nomPer);//Esta funcion busca el indice que tiene asiganda la persona dentro del combo

                TipoUsuarioLogic tul = new TipoUsuarioLogic();
                string descTipo = tul.GetOne(UsuarioActual.IdTipoUsuario).Descripcion;
                this.cbTipoUsuario.SelectedIndex = cbTipoUsuario.FindStringExact(descTipo);
            }

            
        }

        private void btnCrearPersona_Click(object sender, EventArgs e)
        {
            PersonaDesktop edicionPersonas = new PersonaDesktop(ModoForm.Alta);
            edicionPersonas.ShowDialog();
            CargarCombobox();//Vuelve a cargar el combo por si se creo la persona.
        }
    }
    
}
