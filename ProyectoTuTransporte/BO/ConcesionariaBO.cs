using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTuTransporte.BO
{
    public class ConcesionariaBO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Horarios { get; set; }
        public string RFC { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public string Telefono { get; set; }
    }
}