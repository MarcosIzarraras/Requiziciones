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
        }

        private void frmInicioSecion_Load(object sender, EventArgs e)
        {

        }
    }
}
