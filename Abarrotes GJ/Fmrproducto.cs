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
    public partial class Fmrproducto : Form
    {
        public Fmrproducto()
        {
            InitializeComponent();
        }

        private void Fmrproducto_Load(object sender, EventArgs e)
        {
            this.listView1.Columns.Add("codigo");
            this.listView1.Columns.Add("nombre");
            this.listView1.Columns.Add("categoria");
            this.listView1.Columns.Add("marca");
            this.listView1.Columns.Add("cantidad");
            this.listView1.Columns.Add("precio");

            this.listView1.View = View.Details;
            this.listView1.GridLines = true;
            this.listView1.FullRowSelect = true;
            this.listView1.CheckBoxes = true;
            leerarchivo();
            cargacategoria();
            cargamarcas();
        }
        private void cargacategoria()
        {
            try
            {
                StreamReader archivo = new StreamReader("D:\\ARAGI\\PAJ2026\\Abarrotes GJ\\categorias.txt");
                string linea = archivo.ReadLine();
                while (linea != null)
                {
                    this.comboBox1.Items.Add(linea);
                    linea = archivo.ReadLine();
                }
                archivo.Close();
            }
            catch
            {
                MessageBox.Show("Error al cargar las categorias");
            }
        }
        private void cargamarcas()
        {
            try
            {
                StreamReader archivo = new StreamReader("D:\\ARAGI\\PAJ2026\\Abarrotes GJ\\marcas.txt");
                string linea = archivo.ReadLine();
                while (linea != null)
                {
                    this.comboBox2.Items.Add(linea);
                    linea = archivo.ReadLine();
                }
                archivo.Close();
            }
            catch
            {
                MessageBox.Show("Error al cargar las marcas");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Zen.Barcode.Code128BarcodeDraw mgenerador = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
            this.codigo.Image = mgenerador.Draw(this.txtCodigo.Text, 60);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefd = new SaveFileDialog();
            savefd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            savefd.FileName = this.txtCodigo.Text + "png";

            if (savefd.ShowDialog() != DialogResult.Cancel)
            {
                string codbarras = savefd.FileName;
                Bitmap bitmap = new Bitmap(codigo.Image);
                bitmap.Save(codbarras);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            productos reg = new productos(this.textBox1.Text, this.comboBox1.Text, this.comboBox2.Text, this.txtCodigo.Text, Convert.ToDouble(this.textBox3.Text), Convert.ToInt32(this.textBox2.Text));
            reg.registraproductos();
            leerarchivo();

        }
        private void leerarchivo()
        {
            try
            {
                StreamReader archivo = new StreamReader("D:\\ARAGI\\PAJ2026\\Abarrotes GJ\\productos.txt");
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

            }
            catch (Exception ex)
            {
                MessageBox.Show("ocurrio un detalle al leer el archivo: " + ex);
            }
        }

        private void button4_Click(object sender, EventArgs e)
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
             StreamWriter archivo = new StreamWriter("D:\\ARAGI\\PAJ2026\\Abarrotes GJ\\productos.txt");
             int cant = this.listView1.Items.Count;

             for (int x = 0; x < cant; x++)
             {
                string codigo= this.listView1.Items[x].SubItems[0].Text;
                string nombre = this.listView1.Items[x].SubItems[1].Text;
                string Categoria = this.listView1.Items[x].SubItems[2].Text;
                string marca = this.listView1.Items[x].SubItems[3].Text;
                string cantidad = this.listView1.Items[x].SubItems[4].Text;
                string precio = this.listView1.Items[x].SubItems[5].Text;
                
                archivo.WriteLine(codigo + "|" + nombre + "|" + Categoria + "|" + marca + "|" + cantidad + "|" + precio);

             }
             archivo.Flush();
             archivo.Close();
            }
    }
    
}
