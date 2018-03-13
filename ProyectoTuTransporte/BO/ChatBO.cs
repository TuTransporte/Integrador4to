using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTuTransporte.BO
{
    public class ChatBO
    {
        public string IdMensaje { get; set; }
        public string Mensaje { get; set; }
        public string PersonaEnvia { get; set; }
        public string PersonaRecibe { get; set; }
        public string Fecha { get; set; }
        public string Correo { get; set; }
        public int IdDenuncia { get; set; }
    }
}