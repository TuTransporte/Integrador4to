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
        SqlConnection Con;
        SqlCommand exec;

        public SqlConnection EstablecerConexion()
        {
            string cs = "Data Source= DESKTOP-L9DKEN0\\SQLEXPRESS ;Initial Catalog=ProyectoChat;Integrated Security=True";
            Con = new SqlConnection(cs);
            return Con;
        }

        public void AbrirConexion()
        {
            Con.Open();
        }

        public void CerrarConexion()
        {
            Con.Close();
        }

        public int ejecutarSentencia(String strSql)
        {
            try
            {
                this.exec.CommandText = strSql;
                this.exec.Connection = this.Con;
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
            SqlDataAdapter adapter = new SqlDataAdapter(strSql, this.Con);
            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            return tabla;
        }
    }
}