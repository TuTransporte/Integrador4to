using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoTuTransporte.BO;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace ProyectoTuTransporte.DAO
{
    public class GestionEmpleadosDAO
    {
        SqlCommand cmd;
        ConexionDAO conex = new ConexionDAO();

        public DataTable ListarEmpleados()
        {
            String cadena = string.Format("select Id, Nombre, ApellidoPaterno, ApellidoMaterno, Direccion from Choferes");
            //String cadena = string.Format("SELECT choferes.Id, Choferes.Nombre, Choferes.ApellidoPaterno, Choferes.ApellidoMaterno, Choferes.Direccion, Camiones.Serie, Horarios.Turno, Choferes.FK_Camion FROM ((Camiones INNER JOIN Choferes ON Camiones.Id = Choferes.FK_Camion) INNER JOIN Horarios ON Horarios.Id = Choferes.FK_Turno );");
            return conex.EjercutarSentenciaBusqueda(cadena);
        }

        public DataTable LlenarCamposBtnEmpleados(int IdEmpleados)
        {
            String cadena = "Select Id, Nombre, ApellidoPaterno, ApellidoMaterno, Direccion from Choferes where Id = '" + IdEmpleados + "';";
            return conex.EjercutarSentenciaBusqueda(cadena);
        }

        public int AgregarEmpleado(GestionEmpleadosBO oEmpleados)
        {
            cmd = new SqlCommand("INSERT INTO Choferes (Nombre, ApellidoPaterno, ApellidoMaterno, Direccion) Values ('" + oEmpleados.Nombre + "', '" + oEmpleados.ApellidoPaterno + "', '" + oEmpleados.ApellidoMaterno + "','" + oEmpleados.Direccion + "')");
            return conex.EjecutarComando(cmd);
        }

        public int ModificarEmpleado(GestionEmpleadosBO oEmpleados)
        {
            cmd = new SqlCommand("UPDATE Choferes SET Nombre='" + oEmpleados.Nombre + "', ApellidoPaterno='" + oEmpleados.ApellidoPaterno + "', ApellidoMaterno='" + oEmpleados.ApellidoMaterno + "', Direccion='" + oEmpleados.Direccion + "' WHERE Id='" + oEmpleados.Id + "'");
            //cmd = new SqlCommand("UPDATE Choferes SET Nombre='" + oEmpleados.Nombre + "', ApellidoPaterno='" + oEmpleados.ApellidoPaterno + "', ApellidoMaterno='" + oEmpleados.ApellidoMaterno + "', Direccion='" + oEmpleados.Direccion + "', FK_Camion='" + oEmpleados.FK_Camion + "', FK_Turno='" + oEmpleados.FK_Turno + "' WHERE Id='" + oEmpleados.Id + "'");
            return conex.EjecutarComando(cmd);
        }

        public int EliminarEmpleado(GestionEmpleadosBO oEmpleados)
        {
            cmd = new SqlCommand("DELETE FROM Choferes WHERE id='" + oEmpleados.Id + "'");
            return conex.EjecutarComando(cmd);
        }
    }
}