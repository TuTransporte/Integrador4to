using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoTuTransporte.DAO
{
    public class ConexionDAO
    {
        SqlConnection con;
        SqlCommand exec;

        public ConexionDAO()
        {
            con = new SqlConnection("Data Source=LAPTOP-5B0LK3E0;Initial Catalog=TuTransporte;Integrated Security=True");
            exec = new SqlCommand();
        }

        public void AbrirConexion()
        {
            con.Open();
        }

        public void CerrarConexion()
        {
            con.Close();
        }

        public int ejecutarSentencia(String strSql)
        {
            try
            {
                this.exec.CommandText = strSql;
                this.exec.Connection = this.con;
                this.AbrirConexion();
                this.exec.ExecuteNonQuery();
                this.CerrarConexion();
                return 1;
            }
            catch (SqlException)
            {
                return 0;
            }
            finally
            {
                this.CerrarConexion();
            }
        }

        public DataTable EjecutarSentenciaBus(string strSql)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(strSql, this.con);
            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            return tabla;
        }
    }
}