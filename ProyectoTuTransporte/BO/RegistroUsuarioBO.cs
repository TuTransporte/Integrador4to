using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ProyectoTuTransporte.BO
{
    public class RegistroUsuarioBO
    {
        //Registro
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Telefono { get; set; }
        public string Contrasena { get; set; }
        //Login
        public int id { get; set; }
        public string Correolog { get; set; }
        public string Contrasenalog { get; set; }



        //public string Encriptar(string sr)
        //{

        //    MD5 md5 = MD5CryptoServiceProvider.Create();
        //    ASCIIEncoding encoding = new ASCIIEncoding();
        //    byte[] stream = null;
        //    StringBuilder sb = new StringBuilder();
        //    stream = md5.ComputeHash(encoding.GetBytes(sr));
        //    for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
        //    return sb.ToString();




        //    //}

        //}

    }
}