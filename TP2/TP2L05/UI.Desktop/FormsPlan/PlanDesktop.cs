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
    
    public partial class PlanDesktop : ApplicationForm
    {
        private Plan _PlanActual;
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
            this.Modo = modo;                               //Setea el valor en el que se encuentra el formulario (A/B/M/C)   
            this.PlanActual = el.GetOne(ID);             //Obtiene el usuario que tenga el ID pasado por parametro desde la capa de datos
            this.MapearDeDatos();                           //Setea los valores correspondientes al estado del formulario en el form "UsuarioDesktop"
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.PlanActual.ID.ToString();
            this.txtDescripcion.Text = this.PlanActual.Descripcion;
            this.txtIdEspecialidad.Text = this.PlanActual.IDEspecialidad.ToString();
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion) 
            {
                this.btnAceptar.Text = "Guardar";
            }
            else if (Modo == ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
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
                        this.PlanActual.ID = int.Parse(this.txtID.Text);
                        PlanActual.State = BusinessEntity.States.Modified;

                    }
                    catch(Exception Ex)
                    {
                        Console.WriteLine(Ex.Message); //Modificar esta excepcion para que tire un error mas especifico y haga un throw
                    }
                    

                }
                else
                {
                    Plan pl = new Plan();
                    PlanActual = pl;
                    PlanActual.State = BusinessEntity.States.New;
                }
                
                this.PlanActual.Descripcion = this.txtDescripcion.Text;
                this.PlanActual.IDEspecialidad = int.Parse(this.txtIdEspecialidad.Text);

            }
            else if (Modo == ModoForm.Baja)
            {
                PlanActual.State = BusinessEntity.States.Deleted;
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

            if (String.IsNullOrEmpty(this.txtIdEspecialidad.Text))
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
