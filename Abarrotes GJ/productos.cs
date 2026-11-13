using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abarrotes_GJ
{
    internal class productos
    {
        private string nombre, Categoria, marca, codigo;
        private double precio;
        private int cantidad;
        public productos(string n, string c, string m, string cod, double p, int cant)
        {
            nombre = n;
            Categoria = c;
            marca = m;
            codigo = cod;
            precio = p;
            cantidad = cant;
        }
        public void registraproductos()
        {
            StreamWriter archivo = new StreamWriter("D:\\ARAGI\\PAJ2026\\Abarrotes GJ\\productos.txt",true);
            archivo.WriteLine(codigo+"|"+nombre+"|"+Categoria+"|"+marca+"|"+cantidad.ToString()+"|"+precio.ToString());
            archivo.Flush();
            archivo.Close();
        }
    }
}
