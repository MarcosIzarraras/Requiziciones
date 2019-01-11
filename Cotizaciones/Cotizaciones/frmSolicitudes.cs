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
    public partial class frmSolicitudes : Form
    {
        public frmSolicitudes()
        {
            InitializeComponent();
            cargarDatosDefault();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Solicitud solicitud = new Solicitud();

            solicitud.cotizador = Convert.ToInt32(cmbComprador.ValueMember);
            solicitud.estatus = 1;
            solicitud.solicitante = Secion.id;
            solicitud.tipoPedido = Convert.ToInt32(cmbTipoPedido.ValueMember);

            if (solicitud.guardar()) MessageBox.Show("Solicitud guardada correctamente", "SOLICITUDES", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            else MessageBox.Show("Error al guardar solicitud, Verifique la informacion", "SOLICITUDES", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void cargarDatosDefault()
        {
            Departamento departamento = new Departamento(Secion.departamento);
            lblNumeroEmpleado.Text = Secion.numeroEmpleado.ToString();
            lblSolicitante.Text = Secion.nombre;
            lblDepartamento.Text = departamento.nombre;
        }

        private void frmSolicitudes_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
