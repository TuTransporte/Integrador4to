using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoTuTransporte.BO;
using System.Data.SqlClient;
using System.Collections;

namespace ProyectoTuTransporte.DAO
{
    public class GestionEmpleadosDAO
    {
        cls_ConexionDAO clsConex = new cls_ConexionDAO();

        ConexionDAO conex = new ConexionDAO();

        public List<GestionEmpleadosBO> listar()
        {
            var alumnos = new List<GestionEmpleadosBO>();
            String strBuscar = string.Format("SELECT CH.Nombre, Ch.ApellidoPaterno, Ch.ApellidoMaterno, Ch.Turno  FROM Choferes Ch");
            //String strBuscar = string.Format("SELECT CH.Nombre, Ch.ApellidoPaterno, Ch.ApellidoMaterno, CH.FK_Camion, CH.FK_Turno  FROM Choferes CH, Camiones C, Horarios H WHERE CH.FK_Camion = C.Id and CH.FK_Turno = H.Id");
            return alumnos = clsConex.EjecutarSetencialist(strBuscar);

            //string strBuscar = string.Format("SELECT CH.Nombre, Ch.ApellidoPaterno, Ch.ApellidoMaterno, Ch.Turno  FROM Choferes Ch");
            //SqlCommand adapter = new SqlCommand(strBuscar, conex.establecerConexion());
            //conex.abrirConexion();
            //SqlDataReader lectura;

            //ArrayList tipous = new ArrayList();
            //lectura = adapter.ExecuteReader();
            //while (lectura.Read())
            //{
            //    tipous.Add(lectura["Nombre"].ToString());
            //    tipous.Add(lectura["ApellidoPaterno"].ToString());
            //    tipous.Add(lectura["ApellidoMaterno"].ToString());
            //    tipous.Add(lectura["Turno"].ToString());

            //}
            //conex.cerrarconexion();
            //return tipous;
        }
    }
}