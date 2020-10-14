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
    
    public partial class CursoDesktop : ApplicationForm
    {
        private Curso _CursoActual;
        public Curso CursoActual { set; get; }

        public CursoDesktop()
        {
            InitializeComponent();
        }
        public CursoDesktop(ModoForm modo) : this()
        {
        }
        public CursoDesktop(int ID, ModoForm modo) : this()    
        {
            CursoLogic cl = new CursoLogic();
            this.Modo = modo;
            this.CursoActual = cl.GetOne(ID);
            this.MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.CursoActual.IdCurso.ToString();
            this.txtCupo.Text = this.CursoActual.Cupo.ToString();
            this.txtAnioCalendario.Text = this.CursoActual.AnioCalendario.ToString();
            this.txtDescripcion.Text = this.CursoActual.Descripcion;
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
                        this.CursoActual.IdCurso = int.Parse(this.txtID.Text);
                        CursoActual.State = BusinessEntity.States.Modified;

                    }
                    catch(Exception Ex)
                    {
                        Notificar("Error de conversion de ID", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    Curso usu = new Curso();
                    CursoActual = usu;
                    CursoActual.State = BusinessEntity.States.New;
                    CursoActual.Habilitado = true;
                }
                
                this.CursoActual.Cupo = Convert.ToInt32(this.txtCupo.Text);
                
                int fid;
                fid = Convert.ToInt32(cbComision.SelectedValue.GetHashCode());
                this.CursoActual.IdComision = fid;

                fid = Convert.ToInt32(cbMateria.SelectedValue.GetHashCode());
                this.CursoActual.IdMateria = fid;
                
                this.CursoActual.Descripcion = this.txtDescripcion.Text;
                this.CursoActual.AnioCalendario = Convert.ToInt32(this.txtAnioCalendario.Text);

            }
            else if (Modo == ModoForm.Baja)
            {
                CursoActual.State = BusinessEntity.States.Deleted;
            }
            else if (Modo == ModoForm.CancelaBaja)
            {
                CursoActual.State = BusinessEntity.States.Undeleted;
            }
            else if (Modo == ModoForm.Consulta)
            {
                CursoActual.State = BusinessEntity.States.Unmodified;
            }
            
        }
        public override void GuardarCambios()
        {
            this.MapearADatos();
            CursoLogic usu = new CursoLogic();
            usu.Save(CursoActual);
        }
        public override bool Validar()
        {
            bool correcto = true;
            if (String.IsNullOrEmpty(this.txtCupo.Text) || String.IsNullOrEmpty(this.txtDescripcion.Text) || String.IsNullOrEmpty(this.txtAnioCalendario.Text))
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

        private void CargarCombobox()
        {
            //Rellenar ComboBox Comisions
            this.cbComision.DataSource = null;
            ComisionLogic perLogic = new ComisionLogic();
            this.cbComision.DataSource = perLogic.GetAll();
            this.cbComision.DisplayMember = "Descripcion";
            this.cbComision.ValueMember = "IdComision";

            this.cbMateria.DataSource = null;
            MateriaLogic matLogic = new MateriaLogic();
            this.cbMateria.DataSource = matLogic.GetAll();
            this.cbMateria.DisplayMember = "Descripcion";
            this.cbMateria.ValueMember = "IdMateria";
        }

        private void CursoDesktop_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;

            CargarCombobox();

            if (this.Modo != ModoForm.Alta)//Si NO es una alta, cargo el nombre de la persona que estamos editando.
            {
                try
                {
                    ComisionLogic cl = new ComisionLogic();
                    string nomCom = cl.GetOne(CursoActual.IdComision).Descripcion;//Busco el nombre de la comision de dicho curso.
                    this.cbComision.SelectedIndex = cbComision.FindStringExact(nomCom);//Esta funcion busca el indice que tiene asiganda la comision dentro del combo
                }
                catch
                {
                    Notificar("Error de carga", "No se ha podido recuperar la persona actual.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try
                {
                    MateriaLogic matl = new MateriaLogic();
                    string descMat = matl.GetOne(CursoActual.IdMateria).Descripcion;
                    this.cbMateria.SelectedIndex = cbMateria.FindStringExact(descMat);
                }
                catch
                {
                    Notificar("Error de carga", "No se ha podido recuperar el tipo de curso actual.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCrearPersona_Click(object sender, EventArgs e)
        {
            ComisionDesktop edicionComisiones = new ComisionDesktop(ModoForm.Alta);
            edicionComisiones.ShowDialog();
            CargarCombobox();//Vuelve a cargar el combo por si se creo la persona.
        }
    }
    
}
