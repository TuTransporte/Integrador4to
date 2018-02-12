using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTuTransporte.BO
{
    public class GestionPerfilBO
    {
        public int Id { get; set; }
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Telefono { get; set; }
        public string Contraseña { get; set; }
        public string Direccion { get; set; }
        public string RFC { get; set; }
        public string Horario { get; set; }
        public string RazonSocial { get; set; }
    }
}