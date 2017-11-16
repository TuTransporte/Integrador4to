using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoTuTransporte.BO;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoTuTransporte.DAO
{
    public class UsuarioDAO:ConexionDAO
    {
        ConexionDAO conex = new ConexionDAO();
        //SqlCommand cmd = new SqlCommand();
        string sentSQL;



        SqlCommand cmd;

        public int Agregar(RegistroUsuarioBO objeus)
        {
            cmd = new SqlCommand("INSERT INTO Usuario (Correo_usuario, Contrasena, Nombres, ApellidoPaterno, ApellidoMaterno, Telefono, Tipo_usuario) values (@Correo_usuario, @Contrasena, @Nombres, @ApellidoPaterno, @ApellidoMaterno, @Telefono, @Tipo_usuario)");
            cmd.Parameters.Add("@Correo_usuario", SqlDbType.VarChar).Value = objeus.Correo;
            cmd.Parameters.Add("@Contrasena", SqlDbType.VarChar).Value = objeus.Contrasena;
            cmd.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = objeus.Nombre;
            cmd.Parameters.Add("@ApellidoPaterno", SqlDbType.VarChar).Value = objeus.ApellidoPaterno;
            cmd.Parameters.Add("@ApellidoMaterno", SqlDbType.VarChar).Value = objeus.ApellidoMaterno;
            cmd.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = objeus.Telefono;
            cmd.Parameters.Add("@Tipo_usuario", SqlDbType.VarChar).Value = 1;
           
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);
        }





        //public int AgregarUsuario(object ObjR)
        //{
        //    RegistroUsuarioBO dato = (RegistroUsuarioBO)ObjR;
        //    sentSQL = "INSERT INTO Usuario (Correo_usuario, Contrasena, Nombres, ApellidoPaterno, ApellidoMaterno, Telefono, Tipo_usuario) values ('"
        //     + dato.Correo + "', '" + dato.Contrasena
        //     + "', '" + dato.Nombre + "', '"
        //     + dato.ApellidoPaterno + "', '"
        //     + dato.ApellidoMaterno + "', '"
        //     + dato.Telefono + "', '1')";
        //    return conex.EjecutarSentencia(sentSQL);
        //    //comando.CommandText = sentSQL;
        //    //conex.AbrirConexion();
        //    //comando.ExecuteNonQuery();
        //    //conex.CerrarConexion();
        //    //return 1;
        //}

        //public int ModificarUsuario(object ObjR)
        //{
        //    return conex.EjecutarSentencia(sentSQL);
        //}

        //public int EliminarUsuario(object ObjR)
        //{
        //    return conex.EjecutarSentencia(sentSQL);
        //}

        //public int RegistroUsuarioSP(object ObjR)
        //{
        //    sentSQL = "Data Source=.;Initial Catalog=TuTransporte;Integrated Security=True";
        //    SqlConnection cnn = new SqlConnection(sentSQL);
        //    RegistroUsuarioBO dato = (RegistroUsuarioBO)ObjR;
        //    cmd = new SqlCommand("SPAgregarUsuario", cnn);
        //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //    cmd.Parameters.Add(new SqlParameter("@Correo", dato.Correo));
        //    cmd.Parameters.Add(new SqlParameter("@Nombre", dato.Nombre));
        //    cmd.Parameters.Add(new SqlParameter("@ApellidoPaterno", dato.ApellidoPaterno));
        //    cmd.Parameters.Add(new SqlParameter("@ApellidoMaterno", dato.ApellidoMaterno));
        //    cmd.Parameters.Add(new SqlParameter("@Telefono", dato.Telefono));
        //    cmd.Parameters.Add(new SqlParameter("@Contrasena", dato.Contrasena));
        //    conex.AbrirConexion();
        //    return conex.EjecutarSentencia(sentSQL);
        //}
    }
}