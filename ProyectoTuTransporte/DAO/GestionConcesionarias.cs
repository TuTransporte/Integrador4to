using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ProyectoTuTransporte.BO;

namespace ProyectoTuTransporte.DAO
{
    public class GestionConcesionarias
    {
        SqlCommand cmd;
        ConexionDAO conex = new ConexionDAO();

        public DataTable ListarConcesionarias()
        {
            String cadena = string.Format("Select * From Usuario where Tipo_usuario = 1");
            //String cadena = string.Format("SELECT choferes.Id, Choferes.Nombre, Choferes.ApellidoPaterno, Choferes.ApellidoMaterno, Choferes.Direccion, Camiones.Serie, Horarios.Turno, Choferes.FK_Camion FROM ((Camiones INNER JOIN Choferes ON Camiones.Id = Choferes.FK_Camion) INNER JOIN Horarios ON Horarios.Id = Choferes.FK_Turno );");
            return conex.EjercutarSentenciaBusqueda(cadena);
        }

        public DataTable LlenarCamposBtnConcesionarias(int IdConcesionarias)
        {
            String cadena = "Select * From Usuario where Id = '" + IdConcesionarias + "';";
            return conex.EjercutarSentenciaBusqueda(cadena);
        }

        public int AgregarConcesionarias(RegistroUsuarioBO oConcesionarias)
        {
            //1 Concesionarias --- 0 Mortal --- 4 Admin
            cmd = new SqlCommand("INSERT INTO Usuario (Nombres, Telefono, Direccion, RFC, Horario, RazonSocial, Correo_usuario, Contrasena, Tipo_usuario) Values ('" + oConcesionarias.Nombre + "', '" + oConcesionarias.Telefono + "', '" + oConcesionarias.Direccion + "','" + oConcesionarias.RFC + "', '" + oConcesionarias.Horario + "', '" + oConcesionarias.RazonSocial + "', '" + oConcesionarias.Correo + "', '" + oConcesionarias.Contrasena + "', 2)");
            return conex.EjecutarComando(cmd);
        }

        public int ModificarConcesionaria(RegistroUsuarioBO oConcesionarias)
        {
            cmd = new SqlCommand("UPDATE Usuario SET Nombres='" + oConcesionarias.Nombre + "', Telefono='" + oConcesionarias.Telefono + "', Direccion='" + oConcesionarias.Direccion + "', RFC='" + oConcesionarias.RFC + "', Horario='" + oConcesionarias.Horario + "', RazonSocial='" + oConcesionarias.RazonSocial + "', Contrasena='" + oConcesionarias.Contrasena + "' WHERE Id='" + oConcesionarias.Id + "'");
            //cmd = new SqlCommand("UPDATE Choferes SET Nombre='" + oEmpleados.Nombre + "', ApellidoPaterno='" + oEmpleados.ApellidoPaterno + "', ApellidoMaterno='" + oEmpleados.ApellidoMaterno + "', Direccion='" + oEmpleados.Direccion + "', FK_Camion='" + oEmpleados.FK_Camion + "', FK_Turno='" + oEmpleados.FK_Turno + "' WHERE Id='" + oEmpleados.Id + "'");        
            return conex.EjecutarComando(cmd);
        }

        public int EliminarConcesionaria(RegistroUsuarioBO oConcesionarias)
        {
            cmd = new SqlCommand("DELETE FROM Usuario WHERE id='" + oConcesionarias.Id + "'");
            return conex.EjecutarComando(cmd);
        }
    }
}