using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Cotizaciones
{
    public partial class frmActivacionUsuario : Form
    {
        public frmActivacionUsuario()
        {
            InitializeComponent();     
            
        }
      /*  private void cargarUsuario()
        {
            DataTable usuario = Usuario.cargarUsuario();
            foreach (DataRow fila in usuario.Rows)
            {
                DataGridView nuevoElemnto = new DataGridView();
                nuevoElemnto.Text = fila[0].ToString() + "-" + fila[1].ToString();
                nuevoElemnto.Click += new EventHandler(dgvDetalles);
                nuevoElemnto.Tag = fila[0].ToString();

                toolUsuario.DropDownItems.Add(nuevoElemnto);
                in index 
            }
            toolUsuario.Text = "Usuario (" + usuario.Rows.Count + ")";
        }*/
       
        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
          
        }

        private void frmActivacionUsuario_Load(object sender, EventArgs e)
        {
            DataTable dgvDetalles = Conexion.LeerTabla("SELECT tusu_id, tusu_nombre FROM usuario");
        }
    }
}
