using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTuTransporte.BO
{
    public class GestionDenunciasBO
    {
        public int Id { get; set; }
        public string Denuncia { get; set; }
        public string FechaHora { get; set; }
        public int Estado { get; set; }
        public int FK_Ubicacion { get; set; }
        public int FK_Usuario { get; set; }
        public int FK_Chofer { get; set; }
        public int FK_Camion { get; set; }
        public string Dictamen { get; set; }
    }
}