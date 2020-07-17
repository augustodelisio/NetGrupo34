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
    
    public partial class EspecialidadDesktop : ApplicationForm
    {
        private Especialidad _EspecialidadActual;
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
            this.Modo = modo;                               //Setea el valor en el que se encuentra el formulario (A/B/M/C)   
            this.EspecialidadActual = el.GetOne(ID);             //Obtiene el usuario que tenga el ID pasado por parametro desde la capa de datos
            this.MapearDeDatos();                           //Setea los valores correspondientes al estado del formulario en el form "UsuarioDesktop"
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.EspecialidadActual.ID.ToString();
            this.txtDescripcion.Text = this.EspecialidadActual.Descripcion;
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
                        this.EspecialidadActual.ID = int.Parse(this.txtID.Text);
                        EspecialidadActual.State = BusinessEntity.States.Modified;

                    }
                    catch(Exception Ex)
                    {
                        Console.WriteLine(Ex.Message); //Modificar esta excepcion para que tire un error mas especifico y haga un throw
                    }
                    

                }
                else
                {
                    Especialidad esp = new Especialidad();
                    EspecialidadActual = esp;
                    EspecialidadActual.State = BusinessEntity.States.New;
                }
                
                this.EspecialidadActual.Descripcion = this.txtDescripcion.Text;
            }
            else if (Modo == ModoForm.Baja)
            {
                EspecialidadActual.State = BusinessEntity.States.Deleted;
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
