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

namespace UI.Desktop
{
    public partial class CursosInscrip : ApplicationForm
    {
        public Materia Mat { set; get; }
        public Usuario Usu { set; get; }
        public CursosInscrip()
        {
            InitializeComponent();
            dgvCursosInscrip.AutoGenerateColumns = false;
        }
        public CursosInscrip(int idMat, int idUsu)
        {
            InitializeComponent();
            dgvCursosInscrip.AutoGenerateColumns = false;
            try
            {
                Mat = new MateriaLogic().GetOne(idMat);
                Usu = new UsuarioLogic().GetOne(idUsu);
            }
            catch(Exception Ex)
            {
                Notificar("Error de carga de materia y usuario", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        public void Listar()
        {
            try
            {
                CursoLogic ul = new CursoLogic();
                this.dgvCursosInscrip.DataSource = ul.GetAll().Where( x => x.IdMateria == Mat.IdMateria).ToList();
                FormatoDGV.ActualizaColor(dgvCursosInscrip);
            }
            catch (Exception Ex)
            {
                Notificar("Error de carga de cursos", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CursosInscrip_Load(object sender, EventArgs e)
        {
            this.Listar();
            lbMateria.Text = "Inscribirse a " + Mat.Descripcion;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInscribirme_Click(object sender, EventArgs e)
        {
            if (this.dgvCursosInscrip.SelectedRows.Count > 0)
            {
                int idCur = ((Curso)this.dgvCursosInscrip.SelectedRows[0].DataBoundItem).IdCurso;
                int idCom = ((Curso)this.dgvCursosInscrip.SelectedRows[0].DataBoundItem).IdComision;
                string nomCom;
                try
                {
                    Comision com = new ComisionLogic().GetOne(idCom);
                    nomCom = com.Descripcion;
                }
                catch
                {
                    nomCom = "¿?";
                }

                string msj = "¿Está seguro que desea inscribirse a " + Mat.Descripcion + " en la comisión " + nomCom + "?";
                DialogResult resultado = MessageBox.Show(msj, "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultado == DialogResult.Yes)
                {
                    bool agregado;
                    if (Usu.IdTipoUsuario == 2)
                    {
                        AlumnoCurso alCur = new AlumnoCurso();
                        alCur.IdCurso = idCur;
                        alCur.IdUsuario = Usu.ID;
                        alCur.Condicion = "inscripto";
                        agregado = new AlumnoCursoLogic().Save(alCur);
                    }
                    else
                    {
                        DocenteCurso doCur = new DocenteCurso();
                        doCur.IdCurso = idCur;
                        doCur.IdUsuario = Usu.ID;
                        doCur.Cargos = 1;
                        agregado = new DocenteCursoLogic().Save(doCur);
                    }

                    if (!agregado)
                    {
                        MessageBox.Show("Ya se encuentra inscripto en este curso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Inscripción realizada con éxito", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    this.Listar();
                    this.Close();
                }
            }
        }
    }
}
