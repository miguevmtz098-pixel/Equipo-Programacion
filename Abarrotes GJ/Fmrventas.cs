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
    public partial class Fmrventas : Form
    {
        public Fmrventas()
        {
            InitializeComponent();
        }

        private void btnenter_Click(object sender, EventArgs e)
        {
            buscarproductos();
            this.txtcodigo.ResetText();
            this.txtcodigo.Focus();
        }
        private void buscarproductos()
        {
            try
            {
                StreamReader archivo = new StreamReader("D:\\ARAGI\\PAJ2026\\Abarrotes GJ\\productos.txt");

                string linea = archivo.ReadLine();

                while (linea != null)
                {

                    string[] datos = linea.Split('|');

                    if (this.txtcodigo.Text == datos[0])
                    {
                        ListViewItem item = new ListViewItem(datos);
                        this.lstwlistado.Items.Add(item);
                    }
                    linea = archivo.ReadLine();

                }
                archivo.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("ocurrio un detalle al leer el archivo: " + ex);
            }
        }

        private void Fmrventas_Load(object sender, EventArgs e)
        {
            this.lstwlistado.Columns.Add("codigo");
            this.lstwlistado.Columns.Add("nombre");
            this.lstwlistado.Columns.Add("categoria");
            this.lstwlistado.Columns.Add("marca");
            this.lstwlistado.Columns.Add("cantidad");
            this.lstwlistado.Columns.Add("precio");

            this.lstwlistado.View = View.Details;
            this.lstwlistado.GridLines = true;
            this.lstwlistado.FullRowSelect = true;
            this.lstwlistado.CheckBoxes = true;
        }

        private void txtcodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscarproductos();
                this.txtcodigo.ResetText();
                this.txtcodigo.Focus();
            }
        }
    }
}
