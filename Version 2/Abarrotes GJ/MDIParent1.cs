using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abarrotes_GJ
{
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;
        private string rolUsuario;

        public MDIParent1(string rol)
        {
            InitializeComponent();
            rolUsuario = rol;
            ConfigurarAccesos();
        }

        private void ConfigurarAccesos()
        {
            if (rolUsuario == "Cajero")
            {
                this.marcasToolStripMenuItem.Enabled = false;
                this.categoriasToolStripMenuItem.Enabled = false;
                this.productosToolStripMenuItem.Enabled = false;
                this.usuariosToolStripMenuItem.Enabled = false;
                this.puntoDeVentaToolStripMenuItem.Enabled = true;
            }
            else if (rolUsuario == "Administrador")
            {
                this.marcasToolStripMenuItem.Enabled = true;
                this.categoriasToolStripMenuItem.Enabled = true;
                this.productosToolStripMenuItem.Enabled = true;
                this.usuariosToolStripMenuItem.Enabled = true;
                this.puntoDeVentaToolStripMenuItem.Enabled = true;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin();
            login.Show();
            this.Close();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmrUsuarios forma = new FmrUsuarios();
            forma.MdiParent = this;
            forma.StartPosition = FormStartPosition.CenterScreen;
            forma.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}