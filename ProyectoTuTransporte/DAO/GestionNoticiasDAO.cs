using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ProyectoTuTransporte.BO;

namespace ProyectoTuTransporte.DAO
{
    public class GestionNoticiasDAO
    {
        SqlCommand cmd;
        ConexionDAO obj = new ConexionDAO();
        ConexionDAO conex = new ConexionDAO();

        public DataTable MostarNoticias()
        {
            String cadena = string.Format("SELECT Id, Titulo, Mensaje, Fecha FROM Noticias Order By Fecha Desc;");
            return conex.EjercutarSentenciaBusqueda(cadena);
        }

        //public DataTable LlenarCamposBtnUnidades(int IdUnidades)
        //{
        //    String cadena = "SELECT Serie, Matricula, Comentarios FROM Camiones WHERE Id = '" + IdUnidades + "';";
        //    return conex.EjercutarSentenciaBusqueda(cadena);
        //}

        public int AgregarNoticia(GestionNoticiasBO oNoticias)
        {
            cmd = new SqlCommand("Insert Into Noticias (Titulo, Mensaje, Fecha) Values (@Titulo, @Mensaje, @Fecha)");
            cmd.Parameters.Add("@Titulo", SqlDbType.VarChar).Value = oNoticias.Titulo;
            cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar).Value = oNoticias.Mensaje;
            cmd.Parameters.Add("@Fecha", SqlDbType.VarChar).Value = Convert.ToString(DateTime.Now);
            cmd.CommandType = CommandType.Text;
            return obj.EjecutarComando(cmd);
        }
    }
}