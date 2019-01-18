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
    public partial class frmPantallaPrincipal : Form
    {
        public frmPantallaPrincipal()
        {
            InitializeComponent();
            cargarDatosDefault();
        }

        private void chaGrafica_Click(object sender, EventArgs e)
        {

        }

        private void crearSoicitudToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSolicitudes solicitud = new frmSolicitudes();
            solicitud.Visible = true;
            this.Close();
        }

        private void cargarDatosDefault()
        {
            lblBienvenido.Text = "Bienvenido: " + Secion.nombre;

            DataTable solicitudes = Secion.cargarSolicitudes();

            foreach (DataRow fila in solicitudes.Rows)
            {
                ToolStripMenuItem nuevoElemento = new ToolStripMenuItem();
                nuevoElemento.Text = fila[0].ToString() + " - " + fila[1].ToString();
                nuevoElemento.Click += new EventHandler(abrirSolicitud);
                nuevoElemento.Tag = fila[0].ToString();

                toolSolicitudes.DropDownItems.Add(nuevoElemento);
            }
            toolSolicitudes.Text = "Solicitudes ( " + solicitudes.Rows.Count + " )";
        }
        private void abrirSolicitud(object sender, EventArgs e)
        {
            ToolStripMenuItem objeto = (ToolStripMenuItem)sender;

            frmRequisicion requisicion = new frmRequisicion();
            requisicion.solicitud_id = Convert.ToInt32(objeto.Tag);
            requisicion.Show();

            this.Close();
        }

        private void frmPantallaPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
