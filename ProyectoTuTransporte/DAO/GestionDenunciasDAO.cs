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
            String cadena = string.Format("SELECT Id, Denuncia, FechaHora FROM Denuncias WHERE Estado = '0'");
            return conex.EjercutarSentenciaBusqueda(cadena);
        }

        public DataTable ListDenunciasApro()
        {
            String cadena = string.Format("SELECT Id, Denuncia, FechaHora FROM Denuncias WHERE Estado = '1'");
            return conex.EjercutarSentenciaBusqueda(cadena);
        }

        public DataTable ListDenunciasRech()
        {
            String cadena = string.Format("SELECT Id, Denuncia, FechaHora FROM Denuncias WHERE Estado = '2'");
            return conex.EjercutarSentenciaBusqueda(cadena);
        }

        public DataTable LlenarCamposBtnDen(int IdEmpleados)
        {
            String cadena = "SELECT Id, Denuncia, FechaHora FROM Denuncias WHERE Id = '" + IdEmpleados + "';";
            return conex.EjercutarSentenciaBusqueda(cadena);
        }

        public int AgregarDenuncia(GestionDenunciasBO oDenuncias)
        {
            cmd = new SqlCommand("INSERT INTO Denuncias (Denuncia, FechaHora, FK_Ubicacion, FK_Usuario, FK_Chofer, FK_Camion, Estado) VALUES ('" + oDenuncias.Denuncia + "', GETDATE(), '" + oDenuncias.FK_Ubicacion + "', '" + oDenuncias.FK_Usuario + "', '" + oDenuncias.FK_Chofer + "', '" + oDenuncias.FK_Camion + "', '0')");
            return conex.EjecutarComando(cmd);
        }

        public int ModificarAprovado(GestionDenunciasBO oDenuncias)
        {
            cmd = new SqlCommand("UPDATE Denuncias SET Estado = 1 WHERE Id='" + oDenuncias.Id + "'");
            return conex.EjecutarComando(cmd);
        }

        public int ModificarRechazado(GestionDenunciasBO oDenuncias)
        {
            cmd = new SqlCommand("UPDATE Denuncias SET Estado = 2 WHERE Id='" + oDenuncias.Id + "'");
            return conex.EjecutarComando(cmd);
        }
    }
}