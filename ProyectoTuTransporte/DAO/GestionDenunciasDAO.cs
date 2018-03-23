using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using ProyectoTuTransporte.BO;

namespace ProyectoTuTransporte.DAO
{
    public class GestionDenunciasDAO
    {
        SqlCommand cmd;
        ConexionDAO conex = new ConexionDAO();

        public DataTable ListDenunciasPend()
        {
            String cadena = string.Format("SELECT * FROM Denuncias WHERE Estado = '0' Order By FechaHora Asc");
            return conex.EjercutarSentenciaBusqueda(cadena);
        }

        public DataTable ListDenunciasEnProceso()
        {
            String cadena = string.Format("SELECT * FROM Denuncias WHERE Estado = '1' Order By FechaHora Asc");
            return conex.EjercutarSentenciaBusqueda(cadena);
        }

        public DataTable ListDenunciasFinalizadas()
        {
            String cadena = string.Format("SELECT * FROM Denuncias WHERE Estado = '2' Order By FechaHora Asc");
            return conex.EjercutarSentenciaBusqueda(cadena);
        }

        public DataTable LlenarCamposBtnDen(int IdEmpleados)
        {
            String cadena = "SELECT * FROM Denuncias WHERE Id = '" + IdEmpleados + "';";
            return conex.EjercutarSentenciaBusqueda(cadena);
        }

        /*public int AgregarDenuncia(GestionDenunciasBO oDenuncias)
        {
            cmd = new SqlCommand("INSERT INTO Denuncias (Denuncia, FechaHora, FK_Ubicacion, FK_Usuario, FK_Chofer, FK_Camion, Estado) VALUES ('" + oDenuncias.Denuncia + "', GETDATE(), '" + oDenuncias.FK_Ubicacion + "', '" + oDenuncias.FK_Usuario + "', '" + oDenuncias.FK_Chofer + "', '" + oDenuncias.FK_Camion + "', '0')");
            return conex.EjecutarComando(cmd);
        }

        public int ModificarAprovado(GestionDenunciasBO oDenuncias)
        {
            cmd = new SqlCommand("UPDATE Denuncias SET Estado = 1 WHERE Id='" + oDenuncias.Id + "'");
            return conex.EjecutarComando(cmd);
        }*/

        public int ModificarEnProceso(GestionDenunciasBO oDenuncias)
        {
            cmd = new SqlCommand("UPDATE Denuncias SET Estado = 2, Dictamen = '" + oDenuncias.Dictamen + "'WHERE Id='" + oDenuncias.Id + "'");
            return conex.EjecutarComando(cmd);
        }

        public DataTable ListDenunciasPendConcesionaria(string Concesionaria)
        {
            String cadena = string.Format("SELECT * FROM Denuncias WHERE Estado = '0' Or Estado = 1 And Ruta = '" + Concesionaria + "' Order By FechaHora Asc");
            return conex.EjercutarSentenciaBusqueda(cadena);
        }

        public DataTable LlenarCamposBtnDenConcesionaria(int IdEmpleados)
        {
            String cadena = "SELECT * FROM Denuncias WHERE Id = '" + IdEmpleados + "';";
            return conex.EjercutarSentenciaBusqueda(cadena);
        }
    }
}