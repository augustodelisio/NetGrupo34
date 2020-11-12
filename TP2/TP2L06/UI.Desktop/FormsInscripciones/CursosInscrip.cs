using Business.Entities;
using Business.Logic;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class CursosInscrip : ApplicationForm
    {
        public Materia Mate { set; get; }
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
                Mate = new MateriaLogic().GetOne(idMat);
                Usu = new UsuarioLogic().GetOne(idUsu);
            }
            catch (Exception Ex)
            {
                Notificar("Error de carga de materia y usuario", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        public void Listar()
        {
            try
            {
                CursoLogic cul = new CursoLogic();
                MateriaLogic mal = new MateriaLogic();
                ComisionLogic col = new ComisionLogic();

                var cursosDisp = (
                    from Cur in cul.GetAll()
                    join Mat in mal.GetAll()
                    on Cur.IdMateria equals Mat.IdMateria
                    join Com in col.GetAll()
                    on Cur.IdComision equals Com.IdComision
                    select new
                    {
                        IdCurso = Cur.IdCurso,
                        IdComision = Cur.IdComision,
                        IdMateria = Cur.IdMateria,
                        Habilitado = Cur.Habilitado,
                        Cupo = Cur.Cupo,
                        Anio = Cur.AnioCalendario,
                        NombreMat = Mat.Descripcion,
                        NumeroCom = Com.Descripcion
                    }).ToList();

                this.dgvCursosInscrip.DataSource = cursosDisp.Where(x => x.IdMateria == Mate.IdMateria && x.Habilitado == true).ToList();
                FormatoDGV.ActualizaColor(dgvCursosInscrip);
            }
            catch (Exception Ex)
            {
                Notificar("Error de conexión", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CursosInscrip_Load(object sender, EventArgs e)
        {
            this.Listar();
            lbMateria.Text = "Inscribirse a " + Mate.Descripcion;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInscribirme_Click(object sender, EventArgs e)
        {
            if (this.dgvCursosInscrip.SelectedRows.Count > 0)
            {
                int sri = dgvCursosInscrip.SelectedCells[0].RowIndex;
                DataGridViewRow sr = dgvCursosInscrip.Rows[sri];
                int idCur = Convert.ToInt32(sr.Cells["ID"].Value.ToString());
                int idCom = Convert.ToInt32(sr.Cells["IdComision"].Value.ToString());

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

                string msj = "¿Está seguro que desea inscribirse a " + Mate.Descripcion + " en la comisión " + nomCom + "?";
                DialogResult resultado = MessageBox.Show(msj, "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultado == DialogResult.Yes)
                {
                    CursoLogic cur = new CursoLogic();
                    int cupo = cur.GetOne(idCur).Cupo;

                    bool hayCupo = true;
                    if (Usu.IdTipoUsuario == 2)
                    {
                        AlumnoCurso alCur = new AlumnoCurso();
                        alCur.IdCurso = idCur;
                        alCur.IdUsuario = Usu.ID;
                        alCur.Condicion = "inscripto";
                        AlumnoCursoLogic acl = new AlumnoCursoLogic();
                        if (acl.getCantAlumnos(idCur) < cupo)
                        {
                            acl.Save(alCur);
                        }
                        else
                        {
                            hayCupo = false;
                        }

                    }
                    else if (Usu.IdTipoUsuario == 3)
                    {
                        DocenteCurso doCur = new DocenteCurso();
                        doCur.IdCurso = idCur;
                        doCur.IdUsuario = Usu.ID;
                        doCur.Cargos = 1;
                        DocenteCursoLogic dcl = new DocenteCursoLogic();
                        dcl.Save(doCur);
                    }


                    if (!hayCupo)
                    {
                        MessageBox.Show("El cupo está lleno, intente en otra comisión", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Inscripción realizada con éxito", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }

                    this.Listar();
                }
            }
        }
    }
}
