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
    
    public partial class MateriaDesktop : ApplicationForm
    {
        private Materia _MateriaActual;
        public Materia MateriaActual { set; get; }

        public MateriaDesktop()
        {
            InitializeComponent();
        }
        public MateriaDesktop(ModoForm modo) : this()
        {
        }
        public MateriaDesktop(int ID, ModoForm modo) : this()    
        {
            MateriaLogic el = new MateriaLogic();
            this.Modo = modo;                               //Setea el valor en el que se encuentra el formulario (A/B/M/C)   
            this.MateriaActual = el.GetOne(ID);             //Obtiene el usuario que tenga el ID pasado por parametro desde la capa de datos
            this.MapearDeDatos();                           //Setea los valores correspondientes al estado del formulario en el form "UsuarioDesktop"
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.MateriaActual.IdMateria.ToString();
            this.txtDescripcion.Text = this.MateriaActual.Descripcion;
            this.txtHsSemanales.Text = this.MateriaActual.HsSemanales.ToString();
            this.txtHsTotales.Text = this.MateriaActual.HsTotales.ToString();
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
                        this.MateriaActual.IdMateria = int.Parse(this.txtID.Text);
                        MateriaActual.State = BusinessEntity.States.Modified;
                    }
                    catch (Exception Ex)
                    {
                        Notificar("Error de conversion de ID", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    Materia mat = new Materia();
                    MateriaActual = mat;
                    MateriaActual.State = BusinessEntity.States.New;
                    MateriaActual.Habilitado = true;
                }
                
                this.MateriaActual.Descripcion = this.txtDescripcion.Text;
                this.MateriaActual.HsSemanales = Convert.ToInt32(this.txtHsSemanales.Text);
                this.MateriaActual.HsTotales = Convert.ToInt32(this.txtHsTotales.Text);

                int fid;
                fid = Convert.ToInt32(cbPlanes.SelectedValue.GetHashCode());
                this.MateriaActual.IdPlan = fid;
            }
            else if (Modo == ModoForm.Baja)
            {
                MateriaActual.State = BusinessEntity.States.Deleted;
            }
            else if (Modo == ModoForm.CancelaBaja)
            {
                MateriaActual.State = BusinessEntity.States.Undeleted;
            }
            else if (Modo == ModoForm.Consulta)
            {
                MateriaActual.State = BusinessEntity.States.Unmodified;
            }
            
        }
        public override void GuardarCambios()
        {
            this.MapearADatos();
            MateriaLogic mat = new MateriaLogic();
            mat.Save(MateriaActual);
        }
        public override bool Validar()
        {
            bool correcto = true;
            if (String.IsNullOrEmpty(this.txtDescripcion.Text) || String.IsNullOrEmpty(this.txtHsSemanales.Text) || String.IsNullOrEmpty(this.txtHsTotales.Text))
                correcto = false;

            if (correcto == false)
                this.Notificar("Verifique que todos los campos estén completos.", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
                this.cbPlanes.DataSource = null;
                PlanLogic pl = new PlanLogic();
                this.cbPlanes.DataSource = pl.GetAll();
                this.cbPlanes.DisplayMember = "Descripcion";
                this.cbPlanes.ValueMember = "IdPlan";
            }
            catch
            {
                Notificar("Error de carga", "No se pudieron cargar las especialidades.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MateriaDesktop_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;

            CargarCombobox();

            if (this.Modo != ModoForm.Alta)//Si NO es una alta, cargo el nombre de la persona que estamos editando.
            {
                try
                {
                    PlanLogic pl = new PlanLogic();
                    string nomPla = pl.GetOne(MateriaActual.IdPlan).Descripcion;//Busco la descripción del plan de dicha materia.
                    this.cbPlanes.SelectedIndex = cbPlanes.FindStringExact(nomPla);//Esta funcion busca el indice que tiene asigando el plan dentro del combo
                }
                catch
                {
                    Notificar("Error de carga","No se ha podido recuperar el plan actual.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
