using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoTuTransporte.Services
{
    /// <summary>
    /// Descripción breve de ServiceTuTransporte
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]


    public class ServiceTuTransporte : System.Web.Services.WebService
    {
        public SqlConnection EstablecerConexion()
        {
            SqlCommand exec;
            string cadena = "";
            //Conexion Ricardo
            //cadena = "DESKTOP-L9DKEN0\\SQLEXPRESS";
            //Conexion Montalvo
            //cadena = ".";
            //Conexion Bryan
            //cadena = "LAPTOP-5B0LK3E0";

            SqlConnection con = new SqlConnection("Data Source='" + cadena + "';Initial Catalog=ProyectoTuTransporte;Integrated Security=True");
            exec = new SqlCommand();
            return con;
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
        [WebMethod]
        public DataSet ListaEmpleados()
        {
            EstablecerConexion();
            SqlDataAdapter da = new SqlDataAdapter("select Id, Nombre, ApellidoPaterno, ApellidoMaterno, Direccion from Choferes", EstablecerConexion());
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

    }
}
