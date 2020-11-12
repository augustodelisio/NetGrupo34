using Business.Entities;
using Business.Logic;
using System;
using System.Windows.Forms;

namespace UI.Desktop.FormsCurso
{
    public partial class ModificarEstadoAlumno : ApplicationForm
    {
        public AlumnoCurso AluCur { set; get; }
        public ModificarEstadoAlumno(int idInsc, string alumno)
        {
            InitializeComponent();
            AluCur = new AlumnoCursoLogic().GetOne(idInsc);
            AluCur.State = BusinessEntity.States.Modified;
            this.MapearDatos(alumno);
        }

        private void MapearDatos(string alumno)
        {
            txtIdInscripcion.Text = AluCur.IdInscripcion.ToString();
            txtNota.Text = AluCur.Nota.ToString();
            ucCondiciones1.cond = AluCur.Condicion;
            txtAlumno.Text = alumno;
        }

        private int GuardarDatos()
        {
            AluCur.Condicion = ucCondiciones1.cond;
            AluCur.IdInscripcion = Convert.ToInt32(txtIdInscripcion.Text);
            try
            {
                AluCur.Nota = Convert.ToInt32(txtNota.Text);
                if (Util.Validaciones.validaNota(AluCur.Nota))
                    return 0;//Correcto
                else
                    return 2;//Numero invalido
            }
            catch
            {
                return 1;//Formato invalido
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            AlumnoCursoLogic acl = new AlumnoCursoLogic();
            int error = GuardarDatos();
            if (error == 0)
            {
                try
                {
                    acl.Save(AluCur);
                    Notificar("Modificado", "El alumno fue modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception Ex)
                {
                    Notificar("Error", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (error == 1)
            {
                Notificar("Error", "Formato de Nota inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (error == 2)
            {
                Notificar("Error", "Ingrese una valor de Nota de 0 a 10", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
