//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoTuTransporte
{
    using System;
    using System.Collections.Generic;
    
    public partial class Denuncias
    {
        public int Id { get; set; }
        public string Denuncia { get; set; }
        public string FechaHora { get; set; }
        public int FK_Ubicacion { get; set; }
        public int FK_Usuario { get; set; }
        public int FK_Chofer { get; set; }
        public int FK_Camion { get; set; }
    
        public virtual Camiones Camiones { get; set; }
        public virtual Choferes Choferes { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
