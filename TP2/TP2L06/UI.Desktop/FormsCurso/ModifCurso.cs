using Business.Logic;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using UI.Desktop.FormsCurso;

namespace UI.Desktop
{
    public partial class ModifCurso : ApplicationForm
    {
        public int IdCur { set; get; }
        public ModifCurso(int idCur)
        {
            InitializeComponent();
            dgvCursosInscrip.AutoGenerateColumns = false;
            this.IdCur = idCur;
            int idMat = new CursoLogic().GetOne(idCur).IdMateria;
            string nomMat = new MateriaLogic().GetOne(idMat).Descripcion;
            this.lbCurso.Text = nomMat;
        }
        public void Listar()
        {
            try
            {
                CursoLogic cul = new CursoLogic();
                MateriaLogic ml = new MateriaLogic();
                ComisionLogic col = new ComisionLogic();
                AlumnoCursoLogic acl = new AlumnoCursoLogic();
                UsuarioLogic usl = new UsuarioLogic();
                PersonaLogic pel = new PersonaLogic();
                var cursos = (
                from alC in acl.GetAll()

                join cur in cul.GetAll()
                on alC.IdCurso equals cur.IdCurso
                join mat in ml.GetAll()
                on cur.IdMateria equals mat.IdMateria
                join com in col.GetAll()
                on cur.IdComision equals com.IdComision
                join usu in usl.GetAll()
                on alC.IdUsuario equals usu.ID
                join per in pel.GetAll()
                on usu.IdPersona equals per.IdPersona

                select new
                {
                    IdInscripcion = alC.IdInscripcion,
                    IdCurso = alC.IdCurso,
                    Condicion = alC.Condicion,
                    IdUsuario = alC.IdUsuario,
                    Nota = alC.Nota,
                    Descripcion = cur.Descripcion,
                    Comision = com.Descripcion,
                    Anio = cur.AnioCalendario,
                    NomApel = per.NombreYApellido
                });
                var cursosAMostrar = cursos.Where(x => x.IdCurso == IdCur).ToList();
                this.dgvCursosInscrip.DataSource = cursosAMostrar;

            }
            catch (Exception Ex)
            {
                Notificar("Error de carga de materias", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MateriasInscrip_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (this.dgvCursosInscrip.SelectedRows.Count > 0)
            {
                this.Listar();
            }
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
                int ID = Convert.ToInt32(sr.Cells["IdInscripcion"].Value.ToString());
                string nomAlum = sr.Cells["Alumno"].Value.ToString();
                ModificarEstadoAlumno formCurso = new ModificarEstadoAlumno(ID, nomAlum);
                formCurso.ShowDialog();
                this.Listar();
            }
        }
    }
}
