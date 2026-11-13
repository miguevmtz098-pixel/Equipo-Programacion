using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abarrotes_GJ
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            bool encontrado = false;
            string rol = "";

            try
            {
                StreamReader archivo = new StreamReader("D:\\ARAGI\\PAJ2026\\Abarrotes GJ\\usuarios.txt");
                string linea = archivo.ReadLine();
                while (linea != null)
                {
                    string[] datos = linea.Split('|');

                    if (this.txtUsuario.Text == datos[0] && this.txtPassword.Text == datos[1])
                    {
                        encontrado = true;
                        rol = datos[2];
                        break;
                    }
                    linea = archivo.ReadLine();
                }
                archivo.Close();

                if (encontrado == true)
                {
                    MDIParent1 principal = new MDIParent1(rol);
                    principal.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer el archivo: " + ex);
            }
        }
    }
}