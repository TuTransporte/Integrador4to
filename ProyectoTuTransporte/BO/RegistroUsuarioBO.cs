using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTuTransporte.BO
{
    public class RegistroUsuarioBO
    {
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Telefono { get; set; }
        public string Contrasena { get; set; }

        public string Correolog { get; set; }
        public string Contrasenalog { get; set; }
    }
}