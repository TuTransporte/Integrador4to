using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoTuTransporte.BO;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoTuTransporte.DAO
{
    public class GestionUnidadesDAO : ConexionDAO
    {
        SqlCommand cmd;
        ConexionDAO conex = new ConexionDAO();

        public DataTable ListarUnidades()
        {
            String cadena = string.Format("SELECT Id, Serie, Matricula, Comentarios FROM Camiones;");
            return conex.EjercutarSentenciaBusqueda(cadena);
        }

        public DataTable LlenarCamposBtnUnidades(int IdUnidades)
        {
            String cadena = "SELECT Serie, Matricula, Comentarios FROM Camiones WHERE Id = '" + IdUnidades + "';";
            return conex.EjercutarSentenciaBusqueda(cadena);
        }

        public int AgregarUnidades(GestionUnidadesBO oUnidades)
        {
            cmd = new SqlCommand("INSERT INTO Usuario Camiones (Serie, FK_Rutas) Values (@Serie, @FK_Rutas)");
            cmd.Parameters.Add("@Serie", SqlDbType.VarChar).Value = oUnidades.Serie;
            cmd.Parameters.Add("@FK_Rutas", SqlDbType.VarChar).Value = oUnidades.FK_Ruta;            
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);
        }

    }
}