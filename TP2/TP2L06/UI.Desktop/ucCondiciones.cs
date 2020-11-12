using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class ucCondiciones : UserControl
    {
        public ucCondiciones()
        {
            InitializeComponent();
        }

        public string cond;

        private void ucCondiciones_Load(object sender, EventArgs e)
        {
            cmbCondiciones.Items.Add("Inscripto");
            cmbCondiciones.Items.Add("Cursa");
            cmbCondiciones.Items.Add("Regular");
            cmbCondiciones.Items.Add("Aprobado");
            cmbCondiciones.Items.Add("Libre");
            try
            {
                cmbCondiciones.SelectedItem = cond;
            }
            catch
            {

            }
        }

        private void cmbCondiciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            cond = cmbCondiciones.SelectedItem.ToString();
        }
    }
}
