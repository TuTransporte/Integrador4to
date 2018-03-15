using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


namespace ProyectoTuTransporte.DAO
{
    public class EstadisticasDAO
    {
        public string obtenerDatos()
        {
            //-----------------------------------------------//

            //string markers = "[['Rutas', 'Denuncias Relacionadas'],";
            //string conex = "Data Source=SQL5035.site4now.net;Initial Catalog=DB_A3402F_TuTransporte;User Id=DB_A3402F_TuTransporte_admin;Password=baba131998.13;";

            //SqlCommand cmd = new SqlCommand("SELECT COUNT(*) as 'Denuncias', Denuncias.Ruta FROM Denuncias GROUP By Ruta");

            //using (SqlConnection con = new SqlConnection(conex))
            //{
            //    cmd.Connection = con;
            //    con.Open();
            //    using (SqlDataReader sdr = cmd.ExecuteReader())
            //    {
            //        while (sdr.Read())
            //        {
            //            markers += "[";
            //            markers += string.Format("'{0}',", sdr["Denuncias"]);
            //            markers += string.Format("{0},", sdr["Ruta"]);
            //            markers += "],";
            //        }
            //    }
            //    con.Close();
            //}
            //markers = markers.TrimEnd(',');
            //markers += "]";
            ////ViewBag.Markers = markers;


            //return markers;
            return "";
        }
    }
}