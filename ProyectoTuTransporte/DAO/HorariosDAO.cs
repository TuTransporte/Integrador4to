using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProyectoTuTransporte.DAO;

namespace ProyectoTuTransporte.DAO
{
    public class HorariosDAO
    {
        ConexionDAO conex = new ConexionDAO();

        public IEnumerable<SelectListItem> ListHor()
        {
            var Horario = new List<SelectListItem>();
            String strBuscar = string.Format("SELECT Id, Turno FROM Horarios");
            Horario = conex.EjecutarSetencialistHor(strBuscar);
            IEnumerable<SelectListItem> Horarios = Horario;

            return Horarios;
        }
    }
}