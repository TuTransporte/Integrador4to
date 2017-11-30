using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTuTransporte.BO
{
    public class GestionNoticiasBO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Mensaje { get; set; }
        public string Fecha { get; set; }
    }
}