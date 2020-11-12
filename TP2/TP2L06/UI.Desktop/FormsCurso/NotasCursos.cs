using Business.Logic;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class NotasCursos : ApplicationForm
    {
        public int IdUsu { set; get; }
        public NotasCursos(int idUsu)
        {
            InitializeComponent();
            dgvCursosInscrip.AutoGenerateColumns = false;
            this.IdUsu = idUsu;
        }
        public void Listar()
        {
            try
            {
                CursoLogic cul = new CursoLogic();
                MateriaLogic ml = new MateriaLogic();
                ComisionLogic col = new ComisionLogic();
                DocenteCursoLogic dcl = new DocenteCursoLogic();
                var cursos = (
                from cur in cul.GetAll()

                join doC in dcl.GetAll()
                on cur.IdCurso equals doC.IdCurso
                join mat in ml.GetAll()
                on cur.IdMateria equals mat.IdMateria
                join com in col.GetAll()
                on cur.IdComision equals com.IdComision
                select new
                {
                    IdCurso = cur.IdCurso,
                    IdDocente = doC.IdUsuario,
                    Descripcion = cur.Descripcion,
                    Materia = mat.Descripcion,
                    Comision = com.Descripcion,
                    Anio = cur.AnioCalendario
                });
                var cursosAMostrar = cursos.Where(x => x.IdDocente == IdUsu).ToList();
                this.dgvCursosInscrip.DataSource = cursosAMostrar;
                //this.dgvCursosInscrip.DataSource = cursos;
            }
            catch (Exception Ex)
            {
                Notificar("Error de carga de cursos", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cursos_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvCursosInscrip.SelectedRows.Count > 0)
            {
                int sri = dgvCursosInscrip.SelectedCells[0].RowIndex;
                DataGridViewRow sr = dgvCursosInscrip.Rows[sri];
                int ID = Convert.ToInt32(sr.Cells["IdCurso"].Value.ToString());
                ModifCurso formCurso = new ModifCurso(ID);
                formCurso.ShowDialog();
                this.Listar();
            }
        }
    }
}
