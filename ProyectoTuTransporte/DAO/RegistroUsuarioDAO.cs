using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoTuTransporte.BO;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoTuTransporte.DAO
{
    public class UsuarioDAO : ConexionDAO
    {
        SqlCommand cmd;

        public int AgregarUsuarios(RegistroUsuarioBO objeusuario)
        {
            cmd = new SqlCommand("INSERT INTO Usuario (Correo_usuario, Contrasena, Nombres, ApellidoPaterno, ApellidoMaterno, Telefono, Tipo_usuario) values (@Correo_usuario, @Contrasena, @Nombres, @ApellidoPaterno, @ApellidoMaterno, @Telefono, @Tipo_usuario)");
            cmd.Parameters.Add("@Correo_usuario", SqlDbType.VarChar).Value = objeusuario.Correo;
            cmd.Parameters.Add("@Contrasena", SqlDbType.VarChar).Value = objeusuario.Contrasena;
            cmd.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = objeusuario.Nombre;
            cmd.Parameters.Add("@ApellidoPaterno", SqlDbType.VarChar).Value = objeusuario.ApellidoPaterno;
            cmd.Parameters.Add("@ApellidoMaterno", SqlDbType.VarChar).Value = objeusuario.ApellidoMaterno;
            cmd.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = objeusuario.Telefono;
            cmd.Parameters.Add("@Tipo_usuario", SqlDbType.VarChar).Value = 1;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);
        }
    }
}