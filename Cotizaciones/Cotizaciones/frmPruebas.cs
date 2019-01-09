using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cotizaciones
{
    public partial class frmPruebas : Form
    {
        public frmPruebas()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            DataTable tabla = Conexion.LeerTabla("SELECT * FROM Usuario");
            if(tabla.Rows.Count > 0)
            {
                MessageBox.Show("Estamos al aire", "Estamos al aire", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("GG", "GG", MessageBoxButtons.OK);
            }
        }
    }
}
