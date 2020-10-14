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
using System.Windows.Forms.VisualStyles;

namespace UI.Desktop
{
    
    public partial class ComisionDesktop : ApplicationForm
    {
        private Comision _ComisionActual;
        public Comision ComisionActual { set; get; }

        public ComisionDesktop()
        {
            InitializeComponent();
        }
        public ComisionDesktop(ModoForm modo) : this()
        {
        }
        public ComisionDesktop(int ID, ModoForm modo) : this()    
        {
            ComisionLogic cl = new ComisionLogic();
            this.Modo = modo;
            this.ComisionActual = cl.GetOne(ID);
            this.MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            this.txtIdComision.Text = this.ComisionActual.IdComision.ToString();
            this.txtDescripcion.Text = this.ComisionActual.Descripcion.ToString();
            this.txtAnioEsp.Text = this.ComisionActual.AnioEspecialidad.ToString();


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
                        this.ComisionActual.IdComision = int.Parse(this.txtIdComision.Text);
                        ComisionActual.State = BusinessEntity.States.Modified;

                    }
                    catch(Exception Ex)
                    {
                        Notificar("Error de conversion de ID", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    Comision com = new Comision();
                    ComisionActual = com;
                    ComisionActual.State = BusinessEntity.States.New;
                    ComisionActual.Habilitado = true;
                }
                
                this.ComisionActual.Descripcion = this.txtDescripcion.Text;
                this.ComisionActual.AnioEspecialidad = Convert.ToInt32(this.txtAnioEsp.Text);

            }
            else if (Modo == ModoForm.Baja)
            {
                ComisionActual.State = BusinessEntity.States.Deleted;
            }
            else if (Modo == ModoForm.CancelaBaja)
            {
                ComisionActual.State = BusinessEntity.States.Undeleted;
            }
            else if (Modo == ModoForm.Consulta)
            {
                ComisionActual.State = BusinessEntity.States.Unmodified;
            }           
        }
        public override void GuardarCambios()
        {
            this.MapearADatos();
            ComisionLogic com = new ComisionLogic();
            com.Save(ComisionActual);
        }
        public override bool Validar()
        {
            bool correcto = true;
            if (String.IsNullOrEmpty(this.txtAnioEsp.Text) || String.IsNullOrEmpty(this.txtDescripcion.Text))
                correcto = false;

            if (correcto == false)
                this.Notificar("Error, campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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

        private void ComisionDesktop_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
        }
    }
}
