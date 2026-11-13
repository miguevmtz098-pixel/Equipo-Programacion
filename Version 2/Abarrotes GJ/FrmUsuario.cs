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
    public partial class FmrUsuarios : Form
    {
        public FmrUsuarios()
        {
            InitializeComponent();
        }

        private void FmrUsuarios_Load(object sender, EventArgs e)
        {
            this.listView1.Columns.Add("usuario", 150);
            this.listView1.Columns.Add("password", 150);
            this.listView1.Columns.Add("rol", 150);

            this.listView1.View = View.Details;
            this.listView1.GridLines = true;
            this.listView1.FullRowSelect = true;
            this.listView1.CheckBoxes = true;
            leerarchivo();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            Usuarios reg = new Usuarios(this.txtUsuario.Text, this.txtPassword.Text, this.cmbRol.Text);
            reg.guardaInfo();

            this.txtUsuario.ResetText();
            this.txtPassword.ResetText();
            this.cmbRol.ResetText();
            this.txtUsuario.Focus();

            leerarchivo();
        }

        private void leerarchivo()
        {
            try
            {
                StreamReader archivo = new StreamReader("D:\\ARAGI\\PAJ2026\\Abarrotes GJ\\usuarios.txt");
                string linea = archivo.ReadLine();
                this.listView1.Items.Clear();
                while (linea != null)
                {
                    string[] datos = linea.Split('|');
                    ListViewItem item = new ListViewItem(datos);
                    this.listView1.Items.Add(item);
                    linea = archivo.ReadLine();
                }
                archivo.Close();

                // CONTADOR DE USUARIOS
                //this.lblContador.Text = this.listView1.Items.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ocurrio un detalle al leer el archivo: " + ex);
            }
        }

        private void button2_Click(object sender, EventArgs e) // Botón Eliminar
        {
            if (this.listView1.CheckedIndices.Count > 0)
            {
                DialogResult respuesta = MessageBox.Show("Deseas eliminar los datos?", "PRREGUNTA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    for (int i = this.listView1.CheckedIndices.Count - 1; i >= 0; i--)
                    {
                        this.listView1.Items.RemoveAt(this.listView1.CheckedIndices[i]);
                    }
                    reguardandoCurso();
                    leerarchivo();
                }
            }
            else
            {
                MessageBox.Show("No hay elementos eliminados");
            }
        }

        private void reguardandoCurso()
        {
            StreamWriter archivo = new StreamWriter("D:\\ARAGI\\PAJ2026\\Abarrotes GJ\\usuarios.txt");
            int cantidad = this.listView1.Items.Count;

            for (int x = 0; x < cantidad; x++)
            {
                string usuario = this.listView1.Items[x].SubItems[0].Text;
                string password = this.listView1.Items[x].SubItems[1].Text;
                string rol = this.listView1.Items[x].SubItems[2].Text;

                archivo.WriteLine(usuario + "|" + password + "|" + rol);
            }
            archivo.Flush();
            archivo.Close();
        }
    }
}