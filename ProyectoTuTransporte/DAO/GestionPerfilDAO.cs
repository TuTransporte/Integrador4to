using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoTuTransporte.BO;
using System.Data.SqlClient;

namespace ProyectoTuTransporte.DAO
{
    public class GestionPerfilDAO
    {
        SqlCommand cmd;
        GestionPerfilBO PerfilBO = new GestionPerfilBO();
        ConexionDAO conex = new ConexionDAO();

        public int ModificarPerfil(GestionPerfilBO oPerfil)
        {
            cmd = new SqlCommand("UPDATE Usuario SET Correo_usuario = '" + oPerfil.Correo + "', Nombres = '" + oPerfil.Nombre + "', ApellidoPaterno = '" + oPerfil.ApellidoPaterno + "', ApellidoMaterno = '" + oPerfil.ApellidoMaterno + "', Telefono = '" + oPerfil.Telefono + "', Contrasena = '" + oPerfil.Contraseña + "' WHERE Id = '" + oPerfil.Id + "'");
            return conex.EjecutarComando(cmd);
        }

        public int ModificarPerfilConcesionaria(GestionPerfilBO oPerfil)
        {
            cmd = new SqlCommand("UPDATE Usuario SET Correo_usuario = '" + oPerfil.Correo + "', Nombres = '" + oPerfil.Nombre + "', Direccion = '" + oPerfil.Direccion + "', RFC = '" + oPerfil.RFC + "', Telefono = '" + oPerfil.Telefono + "', Contrasena = '" + oPerfil.Contraseña + "', Horario = '" + oPerfil.Horario + "', RazonSocial = '" + oPerfil.RazonSocial + "' WHERE Id = '" + oPerfil.Id + "'");
            return conex.EjecutarComando(cmd);
        }
    }
}