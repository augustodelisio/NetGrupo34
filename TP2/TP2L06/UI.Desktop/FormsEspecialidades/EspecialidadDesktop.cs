using Business.Entities;
using Business.Logic;
using System;
using System.Windows.Forms;

namespace UI.Desktop
{

    public partial class EspecialidadDesktop : ApplicationForm
    {
#pragma warning disable CS0169 // El campo 'EspecialidadDesktop._EspecialidadActual' nunca se usa
        private Especialidad _EspecialidadActual;
#pragma warning restore CS0169 // El campo 'EspecialidadDesktop._EspecialidadActual' nunca se usa
        public Especialidad EspecialidadActual { set; get; }

        public EspecialidadDesktop()
        {
            InitializeComponent();
        }
        public EspecialidadDesktop(ModoForm modo) : this()
        {
        }
        public EspecialidadDesktop(int ID, ModoForm modo) : this()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            this.Modo = modo;
            this.EspecialidadActual = el.GetOne(ID);
            this.MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.EspecialidadActual.IdEspecialidad.ToString();
            this.txtDescripcion.Text = this.EspecialidadActual.Descripcion;
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
                        this.EspecialidadActual.IdEspecialidad = int.Parse(this.txtID.Text);
                        EspecialidadActual.State = BusinessEntity.States.Modified;
                    }
                    catch (Exception Ex)
                    {
                        Console.WriteLine(Ex.Message); //Modificar esta excepcion para que tire un error mas especifico y haga un throw
                    }
                }
                else
                {
                    Especialidad esp = new Especialidad();
                    EspecialidadActual = esp;
                    EspecialidadActual.State = BusinessEntity.States.New;
                    EspecialidadActual.Habilitado = true;
                }

                this.EspecialidadActual.Descripcion = this.txtDescripcion.Text;
            }
            else if (Modo == ModoForm.Baja)
            {
                EspecialidadActual.State = BusinessEntity.States.Deleted;
            }
            else if (Modo == ModoForm.CancelaBaja)
            {
                EspecialidadActual.State = BusinessEntity.States.Undeleted;
            }
            else if (Modo == ModoForm.Consulta)
            {
                EspecialidadActual.State = BusinessEntity.States.Unmodified;
            }

        }
        public override void GuardarCambios()
        {
            this.MapearADatos();
            EspecialidadLogic esp = new EspecialidadLogic();
            esp.Save(EspecialidadActual);
        }
        public override bool Validar()
        {
            bool correcto = true;
            if (String.IsNullOrEmpty(this.txtDescripcion.Text))
                correcto = false;

            if (correcto == false)
                this.Notificar("Error, campo incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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

        private void EspecialidadDesktop_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
        }
    }

}
