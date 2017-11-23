using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
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


        public ConexionDAO()
        {
            con = new SqlConnection("Data Source=DESKTOP-L9DKEN0\\SQLEXPRESS;Initial Catalog=ProyectoTuTransporte;Integrated Security=True");
            exec = new SqlCommand();
        }

        public SqlConnection establecerConexion()
        {
            //Conexion Montalvo

            con = new SqlConnection("Data Source=DESKTOP-L9DKEN0\\SQLEXPRESS;Initial Catalog=ProyectoTuTransporte;Integrated Security=True");
            exec = new SqlCommand();
            return con;
        }

        public SqlConnection establecerConexion(string conesiaohd)
        {
            string cs = conesiaohd;
            con = new SqlConnection(cs);
            return con;
        }

        public void abrirConexion()
        {
            con.Open();
        }

        public void cerrarconexion()
        {
            con.Close();
        }
        public int EjecutarComando(SqlCommand sqlcomando)
        {

            // INSERT, DELETE, UPDATE


            adaptador = new SqlDataAdapter();
            ComandoSQL = new SqlCommand();
            ComandoSQL = sqlcomando;
            ComandoSQL.Connection = this.establecerConexion();
            this.abrirConexion();

            int id = 0;
            id = Convert.ToInt32(ComandoSQL.ExecuteScalar());

            return (id != 0) ? id : 0; ;

        }

        public DataSet EjecutarSentencia(SqlCommand sqlcomando)
        {
            // SELECT
            ComandoSQL = new SqlCommand();
            adaptador = new SqlDataAdapter();

            DataSetAdaptador = new DataSet();
            ComandoSQL = sqlcomando;

            ComandoSQL.Connection = this.establecerConexion();
            this.abrirConexion();

            adaptador.SelectCommand = ComandoSQL;
            adaptador.Fill(DataSetAdaptador);
            this.cerrarconexion();
            return DataSetAdaptador;


        }


        public DataTable EjercutarSentenciaBusqueda(string sql) //SELECT
        {
            SqlDataAdapter adapter = new SqlDataAdapter(sql, this.con);
            DataTable tabla = new DataTable();
            //rellenar un objeto DataSet con los resultados del elemento SelectCommand
            adapter.Fill(tabla);
            return tabla;
        }








        //public void AbrirConexion()
        //{
        //    con.Open();
        //}

        //public void CerrarConexion()
        //{
        //    con.Close();
        //}

        //public int EjecutarSentencia(String strSql)
        //{
        //    try
        //    {
        //        this.exec.CommandText = strSql;
        //        this.exec.Connection = this.con;
        //        this.AbrirConexion();
        //        this.exec.ExecuteNonQuery();
        //        this.CerrarConexion();
        //        return 1;
        //    }
        //    catch (SqlException)
        //    {
        //        return 0;
        //    }
        //    finally
        //    {
        //        this.CerrarConexion();
        //    }
        //}

        //public DataTable EjecutarSentenciaBus(string strSql)
        //{
        //    SqlDataAdapter adapter = new SqlDataAdapter(strSql, this.con);
        //    DataTable tabla = new DataTable();
        //    adapter.Fill(tabla);
        //    return tabla;
        //}
    }
}
