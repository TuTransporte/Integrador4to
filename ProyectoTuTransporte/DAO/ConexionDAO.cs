using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using ProyectoTuTransporte.BO;
namespace ProyectoTuTransporte.DAO
{
    public class ConexionDAO
    {
        SqlCommand ComandoSQL;
        SqlDataAdapter adaptador;
        DataSet DataSetAdaptador;
        SqlConnection con;
        SqlCommand exec;
        string cadena = "";

        public void Conexiones()
        {
            //Conexion Ricardo
            //cadena = "DESKTOP-L9DKEN0\\SQLEXPRESS";
            //Conexion Montalvo
            cadena = ".";
            //Conexion Bryan
            //cadena = "LAPTOP-5B0LK3E0";
        }

        public SqlConnection EstablecerConexion()
        {
            Conexiones();
            con = new SqlConnection("workstation id=TuTransporte.mssql.somee.com;packet size=4096;user id=BryanBasulto_SQLLogin_1;pwd=yogpxy36gt;data source=TuTransporte.mssql.somee.com;persist security info=False;initial catalog=TuTransporte");
            //con = new SqlConnection("Data Source=SQL5035.site4now.net;Initial Catalog=DB_A3402F_TuTransporte;User Id=DB_A3402F_TuTransporte_admin;Password=baba131998.13;");
            //con = new SqlConnection("Data Source='" + cadena + "';Initial Catalog=ProyectoTuTransporte;Integrated Security=True");
            exec = new SqlCommand();
            return con;
        }

        public void AbrirConexion()
        {
            con.Open();
        }

        public void CerrarConexion()
        {
            con.Close();
        }

        public int EjecutarComando(SqlCommand sqlcomando)
        {
            // INSERT, DELETE, UPDATE
            adaptador = new SqlDataAdapter();
            ComandoSQL = new SqlCommand();
            ComandoSQL = sqlcomando;
            ComandoSQL.Connection = this.EstablecerConexion();
            this.AbrirConexion();
            int id = 0;
            id = Convert.ToInt32(ComandoSQL.ExecuteScalar());
            return (id != 0) ? id : 0; ;
        }

        public ConexionDAO()
        {
            Conexiones();
            con = new SqlConnection("workstation id=TuTransporte.mssql.somee.com;packet size=4096;user id=BryanBasulto_SQLLogin_1;pwd=yogpxy36gt;data source=TuTransporte.mssql.somee.com;persist security info=False;initial catalog=TuTransporte");
            //con = new SqlConnection("Data Source='" + cadena + "';Initial Catalog=ProyectoTuTransporte;Integrated Security=True");
            exec = new SqlCommand();
        }

        public DataTable EjercutarSentenciaBusqueda(string sql) //SELECT
        {
            SqlDataAdapter adapter = new SqlDataAdapter(sql, this.con);
            DataTable tabla = new DataTable();
            //Rellenar un objeto DataSet con los resultados del elemento SelectCommand
            adapter.Fill(tabla);
            return tabla;
        }

        public List<SelectListItem> EjecutarSetencialistUni(String strSql)
        {
            var Unidades = new List<SelectListItem>();
            this.AbrirConexion();
            var query = new SqlCommand(strSql, this.con);
            using (var dr = query.ExecuteReader())
            {
                while (dr.Read())
                {
                    var Unidad = new SelectListItem
                    {
                        Text = dr["Serie"].ToString(),
                        Value = dr["Id"].ToString()
                    };
                    Unidades.Add(Unidad);
                }
            }
            this.CerrarConexion();
            return Unidades;
        }

        public List<SelectListItem> EjecutarSetencialistHor(String strSql)
        {
            var Unidades = new List<SelectListItem>();
            this.AbrirConexion();
            var query = new SqlCommand(strSql, this.con);
            using (var dr = query.ExecuteReader())
            {
                while (dr.Read())
                {
                    var Unidad = new SelectListItem
                    {
                        Text = dr["Turno"].ToString(),
                        Value = dr["Id"].ToString()
                    };
                    Unidades.Add(Unidad);
                }
            }
            this.CerrarConexion();
            return Unidades;
        }
    }
}
