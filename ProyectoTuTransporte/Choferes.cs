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
    
    public partial class Choferes
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public Nullable<int> FK_Camion { get; set; }
        public Nullable<int> FK_Turno { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
    
        public virtual Camiones Camiones { get; set; }
        public virtual Denuncias Denuncias { get; set; }
    }
}
