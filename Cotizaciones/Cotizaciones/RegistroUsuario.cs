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
    public partial class RegistroUsuario : Form
    {
        public RegistroUsuario()
        {
            InitializeComponent();
            cargarDatosDefault();
            //Se toma direccion de la imagen de fondo llamado Login
            Bitmap Imagenes = new Bitmap(Application.StartupPath + @"/Imagenes/Register.jpg");
            //Se pide que la añada como imagen de fondo para esta forma.
            this.BackgroundImage = Imagenes;
        }

        private void RegistroUsuario_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();

            usuario.nombre = txtNombre.Text;
            usuario.apellido = txtApellidos.Text;
            usuario.usuario = txtUsuario.Text;
            usuario.contraseña = txtContraseña.Text;
            usuario.numeroEmpleado = Convert.ToInt32(txtNumeroEmpleado.Text);
            usuario.departamento = Convert.ToInt32(cmbDepartamento.ValueMember);
            usuario.tipoUsuario = Convert.ToInt32(cmbTipoUsuario.ValueMember);

            if (usuario.guardar()) MessageBox.Show("Registro guardado correctamente", "USUARIO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            else MessageBox.Show("Error al guardar registro, Verifique la informacion", "USUARIO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void cargarDatosDefault()
        {
          
            //CARGAMOS TIPO USUARIO
            cmbTipoUsuario.DisplayMember = "tusu_nombre";
            cmbTipoUsuario.ValueMember = "tusu_id";
            cmbTipoUsuario.DataSource = TipoDeUsuario.obtenerTipoUsuario();
            //CARGAMOS DEPARTAMENTOS
            cmbDepartamento.DisplayMember = "dpto_nombre";
            cmbDepartamento.ValueMember = "dpto_id";
            cmbDepartamento.DataSource = Departamento.obtenerDepartamentos();
        }
        private void RegistroUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
