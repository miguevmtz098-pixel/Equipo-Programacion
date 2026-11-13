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
    public partial class FmrCategorias : Form
    {
        public FmrCategorias()
        {
            InitializeComponent();
        }

       
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            Categorias reg = new Categorias(this.textBox1.Text);
            reg.guardaInfo();

            this.textBox1.ResetText();
            this.textBox1.Focus();

            leerarchivo();
        }
        private void leerarchivo()
        {
            try
            {
                StreamReader archivo = new StreamReader("D:\\ARAGI\\PAJ2026\\Abarrotes GJ\\categorias.txt");
                string linea = archivo.ReadLine();
                this.listView1.Items.Clear();
                while (linea != null)
                {
                    string[] datos = new string[1];
                    datos[0] = linea;

                    ListViewItem item = new ListViewItem(datos);
                    this.listView1.Items.Add(item);
                    linea = archivo.ReadLine();

                }
                archivo.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("ocurrio un detalle al leer el archivo: " + ex);
            }
        }

        private void FmrCategorias_Load(object sender, EventArgs e)
        {
            this.listView1.Columns.Add("nombre", 200);

            this.listView1.View = View.Details;
            this.listView1.GridLines = true;
            this.listView1.FullRowSelect = true;
            this.listView1.CheckBoxes = true;
            leerarchivo();
        }
    }
}
