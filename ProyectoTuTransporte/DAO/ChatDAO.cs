using ProyectoTuTransporte.BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoTuTransporte.DAO
{
    public class ChatDAO
    {
        SqlCommand cmd;
        ConexionDAO obj = new ConexionDAO();
        ConexionDAO conex = new ConexionDAO();

        public DataTable MostarUsuarios(string correolog)
        {
            String cadena = string.Format("Select * From Usuario where Correo_usuario != '" + correolog + "' And Tipo_usuario != 4 Order By ApellidoPaterno");
            return conex.EjercutarSentenciaBusqueda(cadena);
        }

        public DataTable AbrirMensaje(string PersonaEnvia)
        {
            String cadena = "SELECT * From Chats WHERE (PersonaEnvia='" + PersonaEnvia + "' And PersonaRecibe='admin@hotmail.com') Or (PersonaRecibe='" + PersonaEnvia + "' And PersonaEnvia='admin@hotmail.com')";
            return conex.EjercutarSentenciaBusqueda(cadena);
        }

        public int AgregarMensaje(ChatBO oChat)
        {
            cmd = new SqlCommand("Insert Chats (Correo,Mensaje,PersonaEnvia,PersonaRecibe,Fecha) Values (@Correo, @Mensaje, @PersonaEnvia, @PersonaRecibe,@Fecha)");
            cmd.Parameters.Add("@Correo", SqlDbType.VarChar).Value = oChat.Correo;
            cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar).Value = oChat.Mensaje;
            cmd.Parameters.Add("@PersonaEnvia", SqlDbType.VarChar).Value = oChat.PersonaEnvia;
            cmd.Parameters.Add("@PersonaRecibe", SqlDbType.VarChar).Value = oChat.PersonaRecibe;
            cmd.Parameters.Add("@Fecha", SqlDbType.VarChar).Value = Convert.ToString(DateTime.Now);
            cmd.CommandType = CommandType.Text;
            return obj.EjecutarComando(cmd);
        }
    }
}