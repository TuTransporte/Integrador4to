using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using ProyectoTuTransporte.BO;

namespace ProyectoTuTransporte.DAO
{
    public class GestionConcesionariasDAO
    {
        SqlCommand cmd;
        ConexionDAO conex = new ConexionDAO();

        public DataTable ListarConcesionarias()
        {
            String cadena = string.Format("SELECT Id, Nombre, Dirección, Horarios, RFC FROM Usuario");
            return conex.EjercutarSentenciaBusqueda(cadena);
        }

        public DataTable LlenarCamposBtnConcesionarias(int IdConc)
        {
            String cadena = "SELECT Id, Nombre, Dirección, Horarios, RFC FROM Usuario where Id = '" + IdConc + "';";
            return conex.EjercutarSentenciaBusqueda(cadena);
        }

        public int AgregarConcesionaria(GestionEmpleadosBO oConcesionarias)
        {
            cmd = new SqlCommand("INSERT INTO Usuario (Correo, Contrasena, Nombre, Dirección, Horarios, RFC) Values ('" + oConcesionarias.Correo + "','" + oConcesionarias.Contrasena + "','" + oConcesionarias.Nombre + "', '" + oConcesionarias.Direccion + "', '" + oConcesionarias.Horarios + "','" + oConcesionarias.RFC + "')");
            return conex.EjecutarComando(cmd);
        }



    }
}