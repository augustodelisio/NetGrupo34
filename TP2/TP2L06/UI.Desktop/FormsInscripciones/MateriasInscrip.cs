using Business.Entities;
using Business.Logic;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class MateriasInscrip : ApplicationForm
    {
        public int IdUsu { set; get; }
        public int Tipo { get; set; }
        public MateriasInscrip(int idUsu, int tipoUsu)
        {
            InitializeComponent();
            dgvMateriasInscrip.AutoGenerateColumns = false;
            dgvCursosInscrip.AutoGenerateColumns = false;
            this.IdUsu = idUsu;
            this.Tipo = tipoUsu;
        }
        public void Listar()
        {
            try
            {
                CursoLogic cul = new CursoLogic();
                MateriaLogic ml = new MateriaLogic();
                ComisionLogic col = new ComisionLogic();
                if (Tipo == 2)//SI ES UN ALUMNO
                {
                    AlumnoCursoLogic acl = new AlumnoCursoLogic();
                    var cursos = (
                    from alC in acl.GetAll()

                    join cur in cul.GetAll()
                    on alC.IdCurso equals cur.IdCurso
                    join mat in ml.GetAll()
                    on cur.IdMateria equals mat.IdMateria
                    join com in col.GetAll()
                    on cur.IdComision equals com.IdComision
                    select new
                    {
                        IdInscripcion = alC.IdInscripcion,
                        IdCurso = alC.IdCurso,
                        Condicion = alC.Condicion,
                        IdUsuario = alC.IdUsuario,
                        Nota = alC.Nota,
                        Descripcion = cur.Descripcion,
                        Materia = mat.Descripcion,
                        Comision = com.Descripcion,
                        Anio = cur.AnioCalendario
                    }).ToList();
                    var cursosAMostrar = cursos.Where(x => x.IdUsuario == IdUsu).ToList();
                    this.dgvCursosInscrip.DataSource = cursosAMostrar;
                }
                else if (Tipo == 3)//SI ES UN ALUMNO
                {
                    dgvCursosInscrip.Columns["Condicion"].HeaderText = "Cargo";
                    dgvCursosInscrip.Columns["Nota"].Visible = false;
                    DocenteCursoLogic dcl = new DocenteCursoLogic();
                    var cursos = (
                    from doC in dcl.GetAll()

                    join cur in cul.GetAll()
                    on doC.IdCurso equals cur.IdCurso
                    join mat in ml.GetAll()
                    on cur.IdMateria equals mat.IdMateria
                    join com in col.GetAll()
                    on cur.IdComision equals com.IdComision
                    select new
                    {
                        IdInscripcion = doC.IdCurso,
                        IdCurso = doC.IdCurso,
                        Condicion = doC.Cargos,
                        IdUsuario = doC.IdUsuario,
                        Descripcion = cur.Descripcion,
                        Materia = mat.Descripcion,
                        Comision = com.Descripcion,
                        Anio = cur.AnioCalendario
                    }).ToList();
                    var cursosAMostrar = cursos.Where(x => x.IdUsuario == IdUsu).ToList();
                    this.dgvCursosInscrip.DataSource = cursosAMostrar;
                }

                MateriaLogic ul = new MateriaLogic();
                this.dgvMateriasInscrip.DataSource = ul.GetAll();
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
            if (this.dgvMateriasInscrip.SelectedRows.Count > 0)
            {
                CursoLogic cul = new CursoLogic();
                MateriaLogic ml = new MateriaLogic();
                ComisionLogic col = new ComisionLogic();

                if (Tipo == 2)//SI ES UN ALUMNO
                {
                    AlumnoCursoLogic acl = new AlumnoCursoLogic();
                    var inscripciones = (
                        from alC in acl.GetAll()

                        join cur in cul.GetAll()
                        on alC.IdCurso equals cur.IdCurso
                        join mat in ml.GetAll()
                        on cur.IdMateria equals mat.IdMateria
                        select new
                        {
                            IdUsuario = alC.IdUsuario,
                            IdMat = mat.IdMateria,
                            NombreMat = mat.Descripcion
                        }).ToList().Where(x => x.IdUsuario == IdUsu).ToList();
                    int ID = ((Materia)this.dgvMateriasInscrip.SelectedRows[0].DataBoundItem).IdMateria;
                    var inscrip = inscripciones.FirstOrDefault(x => x.IdMat == ID);
                    if (inscrip == null)
                    {
                        CursosInscrip formCursosInscrip = new CursosInscrip(ID, IdUsu);
                        this.Visible = false;
                        formCursosInscrip.ShowDialog();
                        this.Visible = true;
                        this.Listar();
                    }
                    else
                    {
                        Notificar("Aviso", "Ya se encuentra inscripto a " + inscrip.NombreMat, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                else if (Tipo == 3) //SI ES UN DOCENTE
                {
                    DocenteCursoLogic dcl = new DocenteCursoLogic();
                    var inscripciones = (
                        from doC in dcl.GetAll()

                        join cur in cul.GetAll()
                        on doC.IdCurso equals cur.IdCurso
                        join mat in ml.GetAll()
                        on cur.IdMateria equals mat.IdMateria
                        select new
                        {
                            IdUsuario = doC.IdUsuario,
                            IdMat = mat.IdMateria,
                            NombreMat = mat.Descripcion
                        }).ToList().Where(x => x.IdUsuario == IdUsu).ToList();
                    int ID = ((Materia)this.dgvMateriasInscrip.SelectedRows[0].DataBoundItem).IdMateria;
                    var inscrip = inscripciones.FirstOrDefault(x => x.IdMat == ID);
                    if (inscrip == null)
                    {
                        CursosInscrip formCursosInscrip = new CursosInscrip(ID, IdUsu);
                        this.Visible = false;
                        formCursosInscrip.ShowDialog();
                        this.Visible = true;
                        this.Listar();
                    }
                    else
                    {
                        Notificar("Aviso", "Ya se encuentra inscripto a " + inscrip.NombreMat, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCursosInscrip_SelectionChanged(object sender, EventArgs e)
        {
            dgvCursosInscrip.CurrentCell = null;
        }
    }
}
