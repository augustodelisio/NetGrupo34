using Business.Entities;
using Business.Logic;
using System;
using System.Windows.Forms;

namespace UI.Desktop
{

    public partial class TipoUsuarioDesktop : ApplicationForm
    {
#pragma warning disable CS0169 // El campo 'TipoUsuarioDesktop._TipoUsuarioActual' nunca se usa
        private TipoUsuario _TipoUsuarioActual;
#pragma warning restore CS0169 // El campo 'TipoUsuarioDesktop._TipoUsuarioActual' nunca se usa
        public TipoUsuario TipoUsuarioActual { set; get; }

        public TipoUsuarioDesktop()
        {
            InitializeComponent();
        }
        public TipoUsuarioDesktop(ModoForm modo) : this()
        {
        }
        public TipoUsuarioDesktop(int ID, ModoForm modo) : this()
        {
            TipoUsuarioLogic tul = new TipoUsuarioLogic();
            this.Modo = modo;
            this.TipoUsuarioActual = tul.GetOne(ID);
            this.MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.TipoUsuarioActual.IdTipoUsuario.ToString();
            this.txtDescripcion.Text = this.TipoUsuarioActual.Descripcion.ToString();
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
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                if (Modo == ModoForm.Modificacion)
                {
                    try
                    {
                        this.TipoUsuarioActual.ID = int.Parse(this.txtID.Text);
                        TipoUsuarioActual.State = BusinessEntity.States.Modified;

                    }
                    catch (Exception Ex)
                    {
                        Console.WriteLine(Ex.Message); //Modificar esta excepcion para que tire un error mas especifico y haga un throw
                    }


                }
                else
                {
                    TipoUsuario usu = new TipoUsuario();
                    TipoUsuarioActual = usu;
                    TipoUsuarioActual.State = BusinessEntity.States.New;
                    TipoUsuarioActual.Habilitado = true;
                }

                this.TipoUsuarioActual.Descripcion = this.txtDescripcion.Text;

            }
            else if (Modo == ModoForm.Baja)
            {
                TipoUsuarioActual.State = BusinessEntity.States.Deleted;
            }
            else if (Modo == ModoForm.CancelaBaja)
            {
                TipoUsuarioActual.State = BusinessEntity.States.Undeleted;
            }
            else if (Modo == ModoForm.Consulta)
            {
                TipoUsuarioActual.State = BusinessEntity.States.Unmodified;
            }

        }
        public override void GuardarCambios()
        {
            this.MapearADatos();
            TipoUsuarioLogic tul = new TipoUsuarioLogic();
            tul.Save(TipoUsuarioActual);
        }
        public override bool Validar()
        {
            bool correcto = true;
            if (String.IsNullOrEmpty(this.txtDescripcion.Text))
                correcto = false;

            if (correcto == false)
                this.Notificar("Ingrese una Descripción del tipo de usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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



        private void TipoUsuarioDesktop_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
        }

    }

}
