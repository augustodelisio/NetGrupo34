using System;
using System.Drawing;
using System.Windows.Forms;

namespace UI.Desktop
{
    public static class FormatoDGV
    {
        public static void ActualizaColor(DataGridView dgv)
        {
            try
            {
                for (int i = 0; i < dgv.RowCount; i++)
                {
                    int hab = Convert.ToInt16(dgv.Rows[i].Cells["Habilitado"].Value);
                    if (hab != 1)
                    {
                        dgv.Rows[i].DefaultCellStyle.ForeColor = Color.DarkGray;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e, "Error", MessageBoxButtons.OK);
            }
        }
    }
}
