using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoTuTransporte.BO;
using System.Data.SqlClient;//Método para usar MD5
using System.Security.Cryptography;
using System.Data;
using System.Collections;

namespace ProyectoTuTransporte.DAO
{
    public class LoginDAO : ConexionDAO
    {

        public ArrayList Login(RegistroUsuarioBO obelogin)
        {
            string comando = string.Format("Select Id,Correo_usuario,Nombres,ApellidoPaterno,ApellidoMaterno,Telefono,Tipo_usuario FROM Usuario WHERE Correo_usuario = '{0}' and Contrasena = '{1}'", obelogin.Correo, obelogin.Contrasena);
            SqlCommand adapter = new SqlCommand(comando, EstablecerConexion());
            AbrirConexion();
            SqlDataReader lectura;
            ArrayList tipous = new ArrayList();
            lectura = adapter.ExecuteReader();
            while (lectura.Read())
            {
                tipous.Add(lectura["Id"].ToString());
                tipous.Add(lectura["Correo_usuario"].ToString());
                tipous.Add(lectura["Nombres"].ToString());
                tipous.Add(lectura["ApellidoPaterno"].ToString());
                tipous.Add(lectura["ApellidoMaterno"].ToString());
                tipous.Add(lectura["Telefono"].ToString());
                tipous.Add(lectura["Tipo_usuario"].ToString());
            }
            CerrarConexion();
            return tipous;
        }
    }
}