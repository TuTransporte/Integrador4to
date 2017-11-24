using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTuTransporte.BO
{
    public class GestionUnidadesBO
    {
        public int Id { get; set; }
        public string Serie { get; set; }
        public int FK_Ruta { get; set; }
    }
}