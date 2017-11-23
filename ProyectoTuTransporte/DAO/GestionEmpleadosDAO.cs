using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoTuTransporte.BO;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace ProyectoTuTransporte.DAO
{
    public class GestionEmpleadosDAO
    {
        cls_ConexionDAO clsConex = new cls_ConexionDAO();

        ConexionDAO conex = new ConexionDAO();


        public DataTable Listar()
        {
            String cadena = string.Format("SELECT choferes.Id, Choferes.Nombre, Choferes.ApellidoPaterno, Choferes.ApellidoMaterno, Choferes.Direccion, Camiones.Serie, Horarios.Turno FROM ((Camiones INNER JOIN Choferes ON Camiones.Id = Choferes.FK_Camion) INNER JOIN Horarios ON Horarios.Id = Choferes.FK_Turno );");

            return conex.EjercutarSentenciaBusqueda(cadena);
        }


        public DataTable LlenarCampos(int i)
        {
            String cadena = "Select Nombre, ApellidoPaterno, ApellidoMaterno, Direccion from Choferes where Id = '" + i + "';";
            return conex.EjercutarSentenciaBusqueda(cadena);
        }

        //public List<GestionEmpleadosBO> listar()
        //{
        //    var alumnos = new List<GestionEmpleadosBO>();
        //    String strBuscar = string.Format("SELECT  Choferes.Nombre, Choferes.ApellidoPaterno, Choferes.ApellidoMaterno, Choferes.Direccion, Camiones.Serie, Horarios.Turno FROM ((Camiones INNER JOIN Choferes ON Camiones.Id = Choferes.FK_Camion) INNER JOIN Horarios ON Horarios.Id = Choferes.FK_Turno );");
        //    return alumnos = clsConex.EjecutarSetencialist(strBuscar);
        //}
    }
}