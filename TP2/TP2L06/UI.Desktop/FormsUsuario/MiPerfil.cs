using Business.Entities;
using Business.Logic;
using System;
using System.Windows.Forms;

namespace UI.Desktop
{

    public partial class MiPerfil : ApplicationForm
    {
#pragma warning disable CS0169 // El campo 'MiPerfil._UsuarioActual' nunca se usa
        private Usuario _UsuarioActual;
#pragma warning restore CS0169 // El campo 'MiPerfil._UsuarioActual' nunca se usa
        public Usuario UsuarioActual { set; get; }

        public MiPerfil()
        {
            InitializeComponent();
        }
        public MiPerfil(int ID, ModoForm modo) : this()
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
        }

        public override void MapearADatos()
        {
            if (Modo == ModoForm.Modificacion)
            {
                try
                {
                    this.UsuarioActual.ID = int.Parse(this.txtID.Text);
                    UsuarioActual.State = BusinessEntity.States.Modified;

                }
                catch (Exception Ex)
                {
                    Notificar("Error de conversion de ID", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (String.IsNullOrEmpty(this.txtLegajo.Text) || this.txtClave.Text.Length < 8 || String.IsNullOrEmpty(this.txtUsuario.Text))
                correcto = false;
            if (this.txtClave.Text != this.txtConfirmarClave.Text)
                correcto = false;

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
                try
                {
                    PersonaLogic pl = new PersonaLogic();
                    string nomPer = pl.GetOne(UsuarioActual.IdPersona).NombreYApellido;//Busco el nombre de la persona de dicho usuario.
                    this.cbPersonas.SelectedIndex = cbPersonas.FindStringExact(nomPer);//Esta funcion busca el indice que tiene asiganda la persona dentro del combo
                }
                catch
                {
                    Notificar("Error de carga", "No se ha podido recuperar la persona actual.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try
                {
                    TipoUsuarioLogic tul = new TipoUsuarioLogic();
                    string descTipo = tul.GetOne(UsuarioActual.IdTipoUsuario).Descripcion;
                    this.cbTipoUsuario.SelectedIndex = cbTipoUsuario.FindStringExact(descTipo);
                }
                catch
                {
                    Notificar("Error de carga", "No se ha podido recuperar el tipo de usuario actual.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
