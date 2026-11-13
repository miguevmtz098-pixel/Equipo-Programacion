using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abarrotes_GJ
{
    internal class Usuarios
    {
        private string nombreUsuario;
        private string password;
        private string rol;

        public Usuarios(string n, string p, string r)
        {
            nombreUsuario = n;
            password = p;
            rol = r;
        }

        public void guardaInfo()
        {
            StreamWriter archivo = new StreamWriter("D:\\ARAGI\\PAJ2026\\Abarrotes GJ\\usuarios.txt", true);
            archivo.WriteLine(nombreUsuario + "|" + password + "|" + rol);
            archivo.Flush();
            archivo.Close();
        }
    }
}