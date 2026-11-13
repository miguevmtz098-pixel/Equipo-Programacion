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
    public partial class FmrMarca : Form
    {
        public FmrMarca()
        {
            InitializeComponent();
        }

        private void FmrMarca_Load(object sender, EventArgs e)
        {
            this.listView1.Columns.Add("nombre", 200);

            this.listView1.View = View.Details;
            this.listView1.GridLines = true;
            this.listView1.FullRowSelect = true;
            this.listView1.CheckBoxes= true;
            leerarchivo();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            Marcas reg = new Marcas(this.textBox1.Text);
            reg.guardaInfo();

            this.textBox1.ResetText();
            this.textBox1.Focus();

            leerarchivo();

        }
        private void leerarchivo()
        {
            try
            {
                StreamReader archivo = new StreamReader("D:\\ARAGI\\PAJ2026\\Abarrotes GJ\\marcas.txt");
                string linea = archivo.ReadLine();
                this.listView1.Items.Clear();
                while(linea != null)
                {
                    string[] datos = new string[1];
                    datos[0]= linea;
                    
                    ListViewItem item = new ListViewItem(datos);
                    this.listView1.Items.Add(item);
                    linea = archivo.ReadLine();

                }
                archivo.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("ocurrio un detalle al leer el archivo: "+ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
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
            StreamWriter archivo = new StreamWriter("D:\\ARAGI\\PAJ2026\\Abarrotes GJ\\marcas.txt");
            int cantidad = this.listView1.Items.Count;

            for (int x = 0; x < cantidad; x++)
            {
                string nombre = this.listView1.Items[x].SubItems[0].Text;
               
                archivo.WriteLine(nombre);
            }
            archivo.Flush();
            archivo.Close();
        }
    }
}
