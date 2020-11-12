using Business.Entities;
using Business.Logic;
using System;
using System.Windows.Forms;
using Util;

namespace UI.Desktop
{

    public partial class PersonaDesktop : ApplicationForm
    {
#pragma warning disable CS0169 // El campo 'PersonaDesktop._PersonaActual' nunca se usa
        private Persona _PersonaActual;
#pragma warning restore CS0169 // El campo 'PersonaDesktop._PersonaActual' nunca se usa
        public Persona PersonaActual { set; get; }

        public PersonaDesktop()
        {
            InitializeComponent();
        }
        public PersonaDesktop(ModoForm modo) : this()
        {
        }
        public PersonaDesktop(int ID, ModoForm modo) : this()
        {
            PersonaLogic pl = new PersonaLogic();
            this.Modo = modo;
            this.PersonaActual = pl.GetOne(ID);
            this.MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.PersonaActual.IdPersona.ToString();
            this.txtTelefono.Text = this.PersonaActual.Telefono;
            this.txtEmail.Text = this.PersonaActual.Email;
            this.txtNombre.Text = this.PersonaActual.Nombre;
            this.txtApellido.Text = this.PersonaActual.Apellido;
            this.txtDireccion.Text = this.PersonaActual.Direccion;
            this.txtFechaNac.Text = this.PersonaActual.FechaNacimiento.ToString();
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
                        this.PersonaActual.IdPersona = int.Parse(this.txtID.Text);
                        PersonaActual.State = BusinessEntity.States.Modified;

                    }
                    catch (Exception Ex)
                    {
                        Console.WriteLine(Ex.Message); //Modificar esta excepcion para que tire un error mas especifico y haga un throw
                    }


                }
                else
                {
                    Persona per = new Persona();
                    PersonaActual = per;
                    PersonaActual.State = BusinessEntity.States.New;
                    PersonaActual.Habilitado = true;

                }

                this.PersonaActual.Telefono = this.txtTelefono.Text;
                this.PersonaActual.Email = this.txtEmail.Text;
                this.PersonaActual.Nombre = this.txtNombre.Text;
                this.PersonaActual.Apellido = this.txtApellido.Text;
                this.PersonaActual.Direccion = this.txtDireccion.Text;
                this.PersonaActual.FechaNacimiento = Convert.ToDateTime(this.txtFechaNac.Text);
            }
            else if (Modo == ModoForm.Baja)
            {
                PersonaActual.State = BusinessEntity.States.Deleted;
            }
            else if (Modo == ModoForm.CancelaBaja)
            {
                PersonaActual.State = BusinessEntity.States.Undeleted;
            }
            else if (Modo == ModoForm.Consulta)
            {
                PersonaActual.State = BusinessEntity.States.Unmodified;
            }

        }
        public override void GuardarCambios()
        {
            this.MapearADatos();
            PersonaLogic usu = new PersonaLogic();
            usu.Save(PersonaActual);
        }
        public override bool Validar()
        {
            bool correcto = true;
            if (String.IsNullOrEmpty(this.txtEmail.Text) || String.IsNullOrEmpty(this.txtNombre.Text) || String.IsNullOrEmpty(this.txtApellido.Text) || String.IsNullOrEmpty(this.txtDireccion.Text) || String.IsNullOrEmpty(this.txtTelefono.Text) || String.IsNullOrEmpty(this.txtFechaNac.Text))
                correcto = false;
            if (Validaciones.EsMailCorrecto(this.txtEmail.Text) == false)
                correcto = false;

            if (correcto == false)
                this.Notificar("Error, campos incompletos o mail erroneo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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

        private void PersonaDesktop_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
        }
    }

}
