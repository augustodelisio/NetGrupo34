using Business.Entities;
using Business.Logic;
using System;
using System.Windows.Forms;

namespace UI.Desktop
{

    public partial class PlanDesktop : ApplicationForm
    {
#pragma warning disable CS0169 // El campo 'PlanDesktop._PlanActual' nunca se usa
        private Plan _PlanActual;
#pragma warning restore CS0169 // El campo 'PlanDesktop._PlanActual' nunca se usa
        public Plan PlanActual { set; get; }

        public PlanDesktop()
        {
            InitializeComponent();
        }
        public PlanDesktop(ModoForm modo) : this()
        {
        }
        public PlanDesktop(int ID, ModoForm modo) : this()
        {
            PlanLogic el = new PlanLogic();
            this.Modo = modo;
            this.PlanActual = el.GetOne(ID);
            this.MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.PlanActual.IdPlan.ToString();
            this.txtDescripcion.Text = this.PlanActual.Descripcion;
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
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                if (Modo == ModoForm.Modificacion)
                {
                    try
                    {
                        this.PlanActual.ID = int.Parse(this.txtID.Text);
                        PlanActual.State = BusinessEntity.States.Modified;

                    }
                    catch (Exception Ex)
                    {
                        Notificar("Error de conversion de ID", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    Plan pl = new Plan();
                    PlanActual = pl;
                    PlanActual.State = BusinessEntity.States.New;
                    PlanActual.Habilitado = true;
                }

                this.PlanActual.Descripcion = this.txtDescripcion.Text;

                int fid;
                fid = Convert.ToInt32(cbEspecialidades.SelectedValue.GetHashCode());
                this.PlanActual.IdEspecialidad = fid;
            }
            else if (Modo == ModoForm.Baja)
            {
                PlanActual.State = BusinessEntity.States.Deleted;
            }
            else if (Modo == ModoForm.CancelaBaja)
            {
                PlanActual.State = BusinessEntity.States.Undeleted;
            }
            else if (Modo == ModoForm.Consulta)
            {
                PlanActual.State = BusinessEntity.States.Unmodified;
            }

        }
        public override void GuardarCambios()
        {
            this.MapearADatos();
            PlanLogic pl = new PlanLogic();
            pl.Save(PlanActual);
        }
        public override bool Validar()
        {
            bool correcto = true;
            if (String.IsNullOrEmpty(this.txtDescripcion.Text))
                correcto = false;

            if (correcto == false)
                this.Notificar("Error, campo incompleto.", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
            try
            {
                //Rellenar ComboBox Personas
                this.cbEspecialidades.DataSource = null;
                EspecialidadLogic el = new EspecialidadLogic();
                this.cbEspecialidades.DataSource = el.GetAll();
                this.cbEspecialidades.DisplayMember = "Descripcion";
                this.cbEspecialidades.ValueMember = "IdEspecialidad";
            }
            catch
            {
                Notificar("Error de carga", "No se pudieron cargar las especialidades.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EspecialidadDesktop_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;

            CargarCombobox();

            if (this.Modo != ModoForm.Alta)//Si NO es una alta, cargo la descripción de la especialidad que estamos editando.
            {
                try
                {
                    EspecialidadLogic pl = new EspecialidadLogic();
                    string nomEsp = pl.GetOne(PlanActual.IdEspecialidad).Descripcion;//Busco el nombre de la especialidad de dicho plan.
                    this.cbEspecialidades.SelectedIndex = cbEspecialidades.FindStringExact(nomEsp);//Esta funcion busca el indice que tiene asiganda la especialidad dentro del combo
                }
                catch
                {
                    Notificar("Error de carga", "No se ha podido recuperar la especialidad actual.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
