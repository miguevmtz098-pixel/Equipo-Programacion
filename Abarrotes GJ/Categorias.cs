using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abarrotes_GJ
{
    internal class Categorias
    {
        private string nombre;
        public Categorias(string m)
        {
            nombre = m;
        }
        public void guardaInfo()
        {
            StreamWriter archivo = new StreamWriter("D:\\ARAGI\\PAJ2026\\Abarrotes GJ\\categorias.txt", true);
            archivo.WriteLine(nombre);
            archivo.Flush();
            archivo.Close();
        }
    }
}
