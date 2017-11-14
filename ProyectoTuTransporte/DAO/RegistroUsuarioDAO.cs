using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoTuTransporte.BO;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoTuTransporte.DAO
{
    public class UsuarioDAO
    {
        ConexionDAO miConexion;

        public UsuarioDAO()
        {
            miConexion = new ConexionDAO();
        }

        public int AgregarCliente(RegistroUsuarioBO oUsuario)
        {
            string sqlExec = string.Format("Insert Into Usuario(Correo_usuario,Contrasena,Nombres,ApellidoMaterno,AplelidoPaterno,Telefono,Tipo_usuario) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", oUsuario.Correo, oUsuario.Contrasena, oUsuario.Nombre, oUsuario.ApellidoPaterno, oUsuario.ApellidoMaterno, 1);
            return miConexion.EjecutarSentencia(sqlExec);
        }

        public int ModificarCliente(RegistroUsuarioBO oUsuario)
        {
            string sqlExec = string.Format("");
            return miConexion.EjecutarSentencia(sqlExec);
        }

        public int EliminarCliente(RegistroUsuarioBO oUsuario)
        {
            string sqlExec = string.Format("");
            return miConexion.EjecutarSentencia(sqlExec);
        }
    }
}