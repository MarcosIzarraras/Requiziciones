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
    public partial class frmInicioSecion : Form
    {
        public frmInicioSecion()
        {
            InitializeComponent();
            //Se toma direccion de la imagen de fondo llamado Login
            Bitmap Imagenes = new Bitmap(Application.StartupPath + @"/Imagenes/Login.jpeg");
            //Se pide que la añada como imagen de fondo para esta forma.
            this.BackgroundImage = Imagenes;
            //Agregamos eventos de focus a los textbox
            txtContraseña.LostFocus += new EventHandler(SinFocus);
            txtContraseña.GotFocus += new EventHandler(Focus);
            txtUsuario.LostFocus += new EventHandler(SinFocus);
            txtUsuario.GotFocus += new EventHandler(Focus);
        }

        private void frmInicioSecion_Load(object sender, EventArgs e)
        {

        }
            
        private void llblRegistro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();

            RegistroUsuario frm = new RegistroUsuario();

            frm.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Secion.iniciarSecion(txtUsuario.Text, txtContraseña.Text))
            {
                this.Hide();
                frmPantallaPrincipal principal = new frmPantallaPrincipal();
                principal.Show();
            }
            else
            {
                MessageBox.Show( "CONTRASEÑA/USUARIO INCORRECTO", "LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Focus(object sender, EventArgs e)
        {
            TextBox cajaActual = (TextBox)sender;
            //Comprobamos si el texto es el default, y si lo es lo borramos
            if (cajaActual.Text.Contains(cajaActual.Tag.ToString()))
                cajaActual.Text = "";
        }
        private void SinFocus(object sender, EventArgs e)
        {
            TextBox cajaActual = (TextBox)sender;
            //En caso de que no haya texto, añadimos el texto por defecto y ponemos el color en gris
            if (String.IsNullOrWhiteSpace(cajaActual.Text))
            {
                cajaActual.Text = cajaActual.Tag.ToString();
            }
        }

    }
}
