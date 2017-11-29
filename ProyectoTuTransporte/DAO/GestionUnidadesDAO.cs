using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
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
            String cadena = "SELECT Id, Serie, Matricula, Comentarios FROM Camiones WHERE Id = '" + IdUnidades + "';";
            return conex.EjercutarSentenciaBusqueda(cadena);
        }

        public int AgregarUnidades(GestionUnidadesBO oUnidades)
        {
            cmd = new SqlCommand("INSERT INTO Camiones (Serie, Matricula, Comentarios) Values (@Serie, @Matricula, @Comentarios)");
            cmd.Parameters.Add("@Serie", SqlDbType.VarChar).Value = oUnidades.Serie;
            cmd.Parameters.Add("@Matricula", SqlDbType.VarChar).Value = oUnidades.Matricula;
            cmd.Parameters.Add("@Comentarios", SqlDbType.VarChar).Value = oUnidades.Comentarios;
            //cmd.Parameters.Add("@FK_Rutas", SqlDbType.VarChar).Value = 1;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);
        }

        public int ModificarUnidades(GestionUnidadesBO oUnidades)
        {
            cmd = new SqlCommand("UPDATE Camiones SET Serie='" + oUnidades.Serie + "', Matricula='" + oUnidades.Matricula + "', Comentarios='" + oUnidades.Comentarios + "' WHERE Id='" + oUnidades.Id + "'");
            return conex.EjecutarComando(cmd);
        }

        public int EliminarUnidad(GestionUnidadesBO oUnidades)
        {
            cmd = new SqlCommand("DELETE FROM Camiones WHERE id='" + oUnidades.Id + "'");
            return conex.EjecutarComando(cmd);
        }

        public GestionUnidadesBO Obtener(int id)
        {
            var Unidades = new GestionUnidadesBO();
            String strBuscar = string.Format("SELECT Id,Serie,Matricula,Comentarios,FK_Ruta FROM Camiones where Id=" + id);
            DataTable datos = conex.EjercutarSentenciaBusqueda(strBuscar);
            DataRow row = datos.Rows[0];
            Unidades.Id = Convert.ToInt32(row["Id"]);
            Unidades.Serie = row["Serie"].ToString();
            Unidades.Matricula = row["Matricula"].ToString();
            Unidades.Comentarios = row["Comentarios"].ToString();
            Unidades.FK_Ruta = Convert.ToInt32(row["FK_Ruta"].ToString());
            return Unidades;
        }

        public IEnumerable<SelectListItem> ListUnid()
        {
            var Unidad = new List<SelectListItem>();
            String strBuscar = string.Format("SELECT Id, Serie FROM Camiones");
            Unidad = conex.EjecutarSetencialistUni(strBuscar);
            IEnumerable<SelectListItem> Unidades = Unidad;

            return Unidades;
        }
    }
}