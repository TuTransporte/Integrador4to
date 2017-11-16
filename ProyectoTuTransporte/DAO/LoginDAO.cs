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
    public class LoginDAO: ConexionDAO
    {


        public ArrayList Login(RegistroUsuarioBO obelogin)
        {
            string comando = string.Format("SELECT Usuario.Id, Usuario.Nombres, Usuario.Tipo_usuario, Usuario.Correo_usuario, Usuario.Contrasena FROM Usuario WHERE Correo_usuario = '{0}' and Contrasena = '{1}'", obelogin.Correo, obelogin.Contrasena);
            SqlCommand adapter = new SqlCommand(comando, establecerConexion());
            abrirConexion();
            SqlDataReader lectura;
            ArrayList tipous = new ArrayList();
            lectura = adapter.ExecuteReader();
            while (lectura.Read())
            {
                tipous.Add(lectura["Id"].ToString());
                tipous.Add(lectura["Nombres"].ToString());
                tipous.Add(lectura["Tipo_usuario"].ToString());
                tipous.Add(lectura["Correo_usuario"].ToString());
                tipous.Add(lectura["Contrasena"].ToString());

            }
            cerrarconexion();
            return tipous;

        }

        //public ArrayList Login(RegistroUsuarioBO obelogin)
        //{
        //    string comando = string.Format("Select Count(Correo_usuario) From Usuario WHERE Correo_usuario='" + obelogin.Correo + "' AND Contraseña='" + obelogin.Contrasena + "'");
        //    SqlCommand adapter = new SqlCommand(comando, establecerConexion());
        //    abrirConexion();
        //    SqlDataReader lectura;
        //    ArrayList tipous = new ArrayList();
        //    lectura = adapter.ExecuteReader();
        //    while (lectura.Read())
        //    {
        //        tipous.Add(lectura["Correo_usuario"].ToString());
        //        tipous.Add(lectura["Contrasena"].ToString());


        //    }
        //    cerrarconexion();
        //    return tipous;

        //}

        




        //ConexionDAO conex = new ConexionDAO();
        //SqlConnection con;


        //SqlCommand comando = new SqlCommand();
        ////Conexion con = new Conexion();
        //string sql;



        //public RegistroUsuarioBO IniciarSesion(string Usuario, string Contrasena)
        //{
        //    con = new SqlConnection("Data Source=LAPTOP-VMV67UNM;Initial Catalog=ProyectoTuTransporte;Integrated Security=True");
        //    string NewPass;
        //    conex.AbrirConexion();

        //    SqlCommand cmd = new SqlCommand("Select Count(Correo_usuario) From Usuario WHERE Correo_usuario=@Correo_usuario AND Contrasena=@Contrasena");
        //    cmd.Parameters.Add("@Correo_usuario", SqlDbType.VarChar).Value = Usuario;
        //    cmd.Parameters.Add("@Contrasena", SqlDbType.VarChar).Value = Contrasena;
        //    cmd.Connection = con;
        //    SqlDataReader Reader;
        //    con.Open();
        //    var Resultado = (Int32)comando.ExecuteScalar();
        //    //RegistroUsuarioBO objBO = new RegistroUsuarioBO();
        //    //if (Reader.Read())
        //    //{
        //    //    objBO.Correolog = Reader[0].ToString();
        //    //    objBO.Contrasenalog = Reader[1].ToString();
        //    //}
        //    conex.CerrarConexion();
        //    con.Close();
        //    return (Resultado == 1) ? true : false;
        //}

        //public bool Iniciar(object obj)
        //{
        //    con = new SqlConnection("Data Source=LAPTOP-VMV67UNM;Initial Catalog=ProyectoTuTransporte;Integrated Security=True");
        //    RegistroUsuarioBO datos = (RegistroUsuarioBO)obj;
        //    comando.Connection = con;
        //    conex.AbrirConexion();
        //    con.Open();
        //    sql = "Select Count(Correo_usuario) From Usuario WHERE Correo_usuario='" + datos.Correo + "' AND Contraseña='" + datos.Contrasena + "'";
        //    comando.CommandText = sql;
        //    var Resultado = (Int32)comando.ExecuteScalar();
        //    conex.CerrarConexion();
        //    con.Close();
        //    return (Resultado == 1) ? true : false;
        //}
    }
}