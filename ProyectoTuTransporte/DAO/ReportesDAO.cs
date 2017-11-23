using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoTuTransporte.DAO
{
    public class ReportesDAO
    {
        cls_ConexionDAO conex1 = new cls_ConexionDAO(); //La buena
        ConexionDAO conex2 = new ConexionDAO();

        DataTable dt = new DataTable();

        public DataTable ReporteEmpleados()
        {
            try
            {
                conex1.abrirConexion();
                SqlCommand cmd = new SqlCommand("SELECT  Choferes.Nombre, Choferes.ApellidoPaterno, Choferes.ApellidoMaterno, Choferes.Direccion, Camiones.Serie, Horarios.Turno FROM ((Camiones INNER JOIN Choferes ON Camiones.Id = Choferes.FK_Camion) INNER JOIN Horarios ON Horarios.Id = Choferes.FK_Turno );");
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception x)
            {

            }


            return dt;
        }
    }
}