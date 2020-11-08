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
    public partial class MateriasInscrip : ApplicationForm
    {
        public int IdUsu { set; get; }
        public MateriasInscrip(int idUsu)
        {
            InitializeComponent();
            dgvMateriasInscrip.AutoGenerateColumns = false;
            this.IdUsu = idUsu;
        }
        public void Listar()
        {
            try
            {
                MateriaLogic ul = new MateriaLogic();
                this.dgvMateriasInscrip.DataSource = ul.GetAll();
                FormatoDGV.ActualizaColor(dgvMateriasInscrip);
            }
            catch(Exception Ex)
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
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbInscribirme_Click(object sender, EventArgs e)
        {

            if (this.dgvMateriasInscrip.SelectedRows.Count > 0)
            {
                int ID = ((Materia)this.dgvMateriasInscrip.SelectedRows[0].DataBoundItem).IdMateria;
                CursosInscrip formCursosInscrip = new CursosInscrip(ID, IdUsu);
                formCursosInscrip.ShowDialog();
                this.Listar();
            }
        }
    }
}
