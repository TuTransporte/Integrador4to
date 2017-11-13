using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoTuTransporte.BO;
using System.Data.SqlClient;

namespace ProyectoTuTransporte.DAO
{
    public class RegistroUsuarioDAO
    {

        SqlCommand comando = new SqlCommand();
        ConexionDAO con = new ConexionDAO();
        string sql;

        ConexionDAO conex = new ConexionDAO();
        SqlCommand cmd;
        string sentSQL;


        public int RegistroUsuario(object ObjR)
        {
            RegistroUsuarioBO dato = (RegistroUsuarioBO)ObjR;
            sentSQL = "INSERT INTO Usuario (Correo_usuario, Contrasena, Nombres, ApellidoPaterno, ApellidoMaterno, Telefono, Tipo_usuario) values ('" 
                + dato.Correo + "', '" + dato.Contrasena 
                + "', '" + dato.Nombre + "', '" 
                + dato.ApellidoPaterno + "', '" 
                + dato.ApellidoMaterno + "', '" 
                + dato.Telefono + "', '1')";
            return conex.ejecutarSentencia(sentSQL);
            
        }

        public int RegistroUsuarioSP(object ObjR)
        {
            sentSQL = "Data Source=.;Initial Catalog=TuTransporte;Integrated Security=True";

            SqlConnection cnn = new SqlConnection(sentSQL);

            RegistroUsuarioBO dato = (RegistroUsuarioBO)ObjR;
            cmd = new SqlCommand("SPAgregarUsuario", cnn);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Correo", dato.Correo));
            cmd.Parameters.Add(new SqlParameter("@Nombre", dato.Nombre));
            cmd.Parameters.Add(new SqlParameter("@ApellidoPaterno", dato.ApellidoPaterno));
            cmd.Parameters.Add(new SqlParameter("@ApellidoMaterno", dato.ApellidoMaterno));
            cmd.Parameters.Add(new SqlParameter("@Telefono", dato.Telefono));
            cmd.Parameters.Add(new SqlParameter("@Contrasena", dato.Contrasena));

            conex.AbrirConexion();  
            return conex.ejecutarSentencia(sentSQL);
        }

        public bool VerificarUsuario()
        {
            RegistroUsuarioBO datos = new RegistroUsuarioBO();
            comando.Connection = con.EstablecerConexion();
            con.AbrirConexion();
            sql = "Select Count(Correo_usuario) From Usuario Where Correo_usuario='" + datos.Correolog + "' And Contrasena='" + datos.Contrasenalog + "'";
            comando.CommandText = sql;
            var Resultado = (Int32)comando.ExecuteScalar();
            con.CerrarConexion();
            return (Resultado == 1) ? true : false;
        }
    }
}