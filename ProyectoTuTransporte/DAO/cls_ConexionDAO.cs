using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoTuTransporte.BO;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoTuTransporte.DAO
{
    public class cls_ConexionDAO
    {
        SqlConnection con;
        SqlCommand exec;
        public cls_ConexionDAO()
        {
            con = new SqlConnection("Data Source=.;Initial Catalog=ProyectoTuTransporte;Integrated Security=True");
            //sirve para establecer las consultas e instrucciones SQL que se ejecutarán en el servidor
            exec = new SqlCommand();
        }
        public void abrirConexion()
        {
            con.Open();
        }

        public void cerrarconexion()
        {
            con.Close();
        }

        public List<GestionEmpleadosBO> EjecutarSetencialist(String strSql)
        {
            var alumnos = new List<GestionEmpleadosBO>();
            this.con.Open();
            var query = new SqlCommand(strSql, this.con);
            using (var dr = query.ExecuteReader())
            {
                while (dr.Read())
                {
                    // Usuario
                    var usuario = new GestionEmpleadosBO
                    {
                        Nombre = dr["Nombre"].ToString(),
                        ApellidoPaterno = dr["ApellidoPaterno"].ToString(),
                        ApellidoMaterno = dr["ApellidoMaterno"].ToString(),
                        Turno = dr["Turno"].ToString(),
                    };

                    // Agregamos el usuario a la lista genérica
                    alumnos.Add(usuario);
                }
            }
            this.cerrarconexion();
            return alumnos;
        }

    }
}