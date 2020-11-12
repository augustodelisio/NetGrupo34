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

namespace UI.Desktop.FormsInscripciones
{
    public partial class AdminInscribe : ApplicationForm
    {
        public int TipoUsu { set; get; }
        public AdminInscribe()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            TipoUsu = 2;
        }

        private void Listar()
        {
            try
            {
                UsuarioLogic usl = new UsuarioLogic();
                PersonaLogic pel = new PersonaLogic();

                var usuarios = (
                    from Usu in usl.GetAll()

                    join Per in pel.GetAll()
                    on Usu.IdPersona equals Per.IdPersona
                    select new
                    {
                        IdUsuario = Usu.ID,
                        Nombre = Per.NombreYApellido,
                        Usuario = Usu.NombreUsuario,
                        IdTipoUsuario = Usu.IdTipoUsuario,
                        Habilitado = Usu.Habilitado
                    }).Where(x => x.IdTipoUsuario == TipoUsu).ToList();

                dataGridView1.DataSource = usuarios;
            }
            catch (Exception Ex)
            {
                Notificar("Error de conexión", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdminInscribe_Load(object sender, EventArgs e)
        {
            cmbTipoUsuario.Items.Add("Alumnos");
            cmbTipoUsuario.Items.Add("Docentes");
            cmbTipoUsuario.SelectedItem = "Alumnos";
        }

        private void cmbTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoUsuario.SelectedItem.ToString() == "Alumnos")
            {
                TipoUsu = 2;
            }
            else
            {
                TipoUsu = 3;
            }
            this.Listar();
        }

        private void btnInscribirme_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                int sri = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow sr = dataGridView1.Rows[sri];
                int idUsu = Convert.ToInt32(sr.Cells["ID"].Value.ToString());
                MateriasInscrip ABMInscrip = new MateriasInscrip(idUsu, TipoUsu);
                ABMInscrip.ShowDialog();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
