﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProyectoTuTransporte.BO
{
    public class GestionUnidadesBO
    {
        public int Id { get; set; }
        public string Serie { get; set; }
        public string Matricula { get; set; }
        public string Comentarios { get; set; }
        public int FK_Ruta { get; set; }
    }
}