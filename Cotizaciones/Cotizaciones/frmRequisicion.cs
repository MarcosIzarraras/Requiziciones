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
    public partial class frmRequisicion : Form
    {
        public int solicitud_id { get; set; }
        public frmRequisicion()
        {
            InitializeComponent();
        }
        private void temporal()
        {
            DataTable usuarios = Secion.cargarSolicitudes();
            foreach(DataRow fila in usuarios.Rows)
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells["NOMBRE-DE-LA-COLUMNA-1"].Value = fila[0].ToString();
                dataGridView1.Rows[index].Cells["NOMBRE-DE-LA-COLUMNA-2"].Value = fila[1].ToString();
            }
        }
    }
}
