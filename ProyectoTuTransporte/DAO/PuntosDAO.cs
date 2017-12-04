using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoTuTransporte.BO;
using System.Data.SqlClient;

namespace ProyectoTuTransporte.DAO
{
    public class PuntosDAO
    {
        SqlCommand cmd;
        ConexionDAO conex = new ConexionDAO();

        public int AgregarPunto(PuntosBO oPunto)
        {
            cmd = new SqlCommand("INSERT INTO PuntoReferencia (Nombre, Latitud, Longitud, Descripcion, Tipo) Values ('" + oPunto.Nombre + "', '" + oPunto.Latitud+ "', '" + oPunto.Longitud + "','" + oPunto.Descripcion + "', '"+ oPunto .Tipo+ "')");
            return conex.EjecutarComando(cmd);
        }

        public int ModificarPuntos(PuntosBO oPuntos)
        {
            cmd = new SqlCommand("UPDATE PuntoReferencia SET Latitud='" + oPuntos.Latitud+ "', Longitud='" + oPuntos.Longitud + "', Descripcion='" + oPuntos.Descripcion + "', Tipo='"+ oPuntos.Tipo+"' WHERE Nombre='" + oPuntos.Nombre+ "'");
            //cmd = new SqlCommand("UPDATE Choferes SET Nombre='" + oEmpleados.Nombre + "', ApellidoPaterno='" + oEmpleados.ApellidoPaterno + "', ApellidoMaterno='" + oEmpleados.ApellidoMaterno + "', Direccion='" + oEmpleados.Direccion + "', FK_Camion='" + oEmpleados.FK_Camion + "', FK_Turno='" + oEmpleados.FK_Turno + "' WHERE Id='" + oEmpleados.Id + "'");
            return conex.EjecutarComando(cmd);
        }

        public int EliminarPunto(PuntosBO oPuntos)
        {
            cmd = new SqlCommand("DELETE FROM PuntoReferencia WHERE Nombre='" + oPuntos.Nombre + "'");
            return conex.EjecutarComando(cmd);
        }
    }
}