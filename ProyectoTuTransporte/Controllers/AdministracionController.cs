using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoTuTransporte.DAO;
using ProyectoTuTransporte.BO;
using ProyectoTuTransporte.Models;
using System.Collections;
using System.Data.SqlClient;

namespace ProyectoTuTransporte.Controllers
{
    public class AdministracionController : Controller
    {
        GestionEmpleadosDAO EmpleadosDAO = new GestionEmpleadosDAO();
        GestionUnidadesDAO UnidadesDAO = new GestionUnidadesDAO();
        GestionNoticiasDAO NoticiasDAO = new GestionNoticiasDAO();
        ChatDAO ChatDAO = new ChatDAO();
        GestionPerfilDAO PerfilDAO = new GestionPerfilDAO();
        HorariosDAO HorariosDAO = new HorariosDAO();

        // GET: Administracion
        public ActionResult Index()
        {
            string valor = "";
            bool log = Convert.ToBoolean(Session["LogOK"]);
            if (log == true)
            {
                return View(NoticiasDAO.MostarNoticias());
            }
            else
            {
                valor = "/FrontEnd/Login";
                return Redirect(valor);
            }
        }

        public ActionResult VerChat()
        {
            string valor = "";
            bool log = Convert.ToBoolean(Session["LogOK"]);
            int tipo = Convert.ToInt32(Session["Tipo"]);
            if (log == true)
            {
                if (tipo == 4)
                {
                    string correo = Session["Correo"].ToString();
                    return View(ChatDAO.MostarUsuarios(correo));
                }
                else
                {
                    return Redirect("/FrontEnd/Inicio");
                }
            }
            else
            {
                valor = "/FrontEnd/Login";
                return Redirect(valor);
            }
        }

        public ActionResult Chat(string personaenvia)
        {
            if (personaenvia == null)
            {
                personaenvia = Session["personaenvia"].ToString();
            }
            else
            {
                Session["personaenvia"] = personaenvia;
            }
            return View(ChatDAO.AbrirMensaje(Session["Correo"].ToString(), Session["personaenvia"].ToString()));
        }

        public ActionResult PublicarMensaje(ChatBO oChatBO)
        {
            oChatBO.Mensaje = Request.Form["txtMensaje"];
            oChatBO.PersonaEnvia = Session["Correo"].ToString();
            oChatBO.PersonaRecibe = Session["personaenvia"].ToString();
            oChatBO.Correo = Session["Correo"].ToString();
            ChatDAO.AgregarMensaje(oChatBO);
            return Redirect("~/Administracion/Chat");
        }

        public ActionResult GestionEmpleados()
        {
            string valor = "";
            bool log = Convert.ToBoolean(Session["LogOK"]);
            if (log == true)
            {
                return PartialView("_GestionEmpleados", EmpleadosDAO.ListarEmpleados());
            }
            else
            {
                valor = "/FrontEnd/Login";
                return Redirect(valor);
            }
        }

        public ActionResult _GestionEmpleados()
        {
            return View();
        }

        // Para poder visualizar la vista ControlDenuncias | Bryan
        public ActionResult ControlDenuncias()
        {
            string valor = "";
            bool log = Convert.ToBoolean(Session["LogOK"]);
            if (log == true)
            {
                return View();
            }
            else
            {
                valor = "/FrontEnd/Login";
                return Redirect(valor);
            }
        }

        // Para poder visualizar la vista PerfilUsuario | Bryan
        public ActionResult PerfilUsuario()
        {
            string valor = "";
            bool log = Convert.ToBoolean(Session["LogOK"]);
            if (log == true)
            {
                return View();
            }
            else
            {
                valor = "/FrontEnd/Login";
                return Redirect(valor);
            }
        }

        //Para poder visualizar la vista GestionEmpleados | Montalvo
        public ActionResult DatosdelUsuario(GestionEmpleadosBO objem)
        {
            string valor = "";
            bool log = Convert.ToBoolean(Session["LogOK"]);
            if (log == true)
            {
                int idus = objem.Id;
                return PartialView("DatosdelUsuario", EmpleadosDAO.LlenarCamposBtnEmpleados(idus));
            }
            else
            {
                valor = "/FrontEnd/Login";
                return Redirect(valor);
            }
        }

        //Para poder visualizar la vista Mapas | Ricardo
        public ActionResult MapaAdmin()
        {
            string markers = "[";
            string conex = "Data Source= DESKTOP-L9DKEN0\\SQLEXPRESS;Initial Catalog=PruebaArrays;Integrated Security=True";
            SqlCommand cmd = new SqlCommand("SELECT * FROM Locations");

            using (SqlConnection con = new SqlConnection(conex))
            {
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        markers += "[";
                        markers += string.Format("'{0}',", sdr["Name"]);
                        markers += string.Format("{0},", sdr["Latitude"]);
                        markers += string.Format("{0},", sdr["Longitude"]);
                        markers += string.Format("{0}", sdr["Description"]);
                        markers += "],";
                    }
                }
                con.Close();
            }

            markers = markers.Remove(markers.Length - 1);
            markers += "];";
            ViewBag.Markers = markers;
            return View();
        }

        public ActionResult DibujaMapa()
        {
            return View();
        }

        public ActionResult _GestionUnidades()
        {
            return View();
        }

        public ActionResult ActualizarInfoU(GestionPerfilBO PerfilBO)
        {
            PerfilBO.Id = Convert.ToInt32(Request.Form["txtId"]);
            PerfilBO.Nombre = Request.Form["txtNombres"];
            PerfilBO.ApellidoPaterno = Request.Form["txtApellidoP"];
            PerfilBO.ApellidoMaterno = Request.Form["txtApellidoM"];
            PerfilBO.Correo = Request.Form["txtCorreo"];
            PerfilBO.Telefono = Request.Form["txtTelefono"];
            PerfilBO.Contraseña = Request.Form["txtContraseña"];
            PerfilDAO.ModificarPerfil(PerfilBO);
            Session["Correo"] = Request.Form["txtCorreo"];
            Session["Contraseña"] = Request.Form["txtContraseña"];
            string contrasena = Session["Contraseña"].ToString();
            return Redirect("~/Administracion/PerfilUsuario");
        }

        public ActionResult GestionUnidades()
        {
            string valor = "";
            bool log = Convert.ToBoolean(Session["LogOK"]);
            if (log == true)
            {
                return PartialView("_GestionUnidades", UnidadesDAO.ListarUnidades());
            }
            else
            {
                valor = "/FrontEnd/Login";
                return Redirect(valor);
            }
        }

        public ActionResult DatosDeUnidades(GestionUnidadesBO oUnidades)
        {
            string valor = "";
            bool log = Convert.ToBoolean(Session["LogOK"]);
            if (log == true)
            {
                int idUn = oUnidades.Id;
                Session["Id"] = oUnidades.Id;
                return PartialView("DatosDeUnidades", UnidadesDAO.LlenarCamposBtnUnidades(idUn));
            }
            else
            {
                valor = "/FrontEnd/Login";
                return Redirect(valor);
            }
        }

        public ActionResult AgregarUnidades()
        {
            string valor = "";
            bool log = Convert.ToBoolean(Session["LogOK"]);
            if (log == true)
            {
                return View();
            }
            else
            {
                valor = "/FrontEnd/Login";
                return Redirect(valor);
            }
        }

        public ActionResult AgregarUnidad(GestionUnidadesBO oUnidades)
        {
            oUnidades.Serie = Request.Form["txtSerie"];
            oUnidades.Matricula = Request.Form["txtMatricula"];
            oUnidades.Comentarios = Request.Form["txtComentarios"];
            UnidadesDAO.AgregarUnidades(oUnidades);
            return Redirect("~/Administracion/GestionUnidades");
        }

        //Método para modificar información de una Unidad | Montalvo
        public ActionResult ModificarUnidades(GestionUnidadesBO oUnidades)
        {
            oUnidades.Id = Convert.ToInt32(Request.Form["txtId"]);
            oUnidades.Serie = Request.Form["txtSerie"];
            oUnidades.Matricula = Request.Form["txtMatricula"];
            oUnidades.Comentarios = Request.Form["txtComentarios"];
            UnidadesDAO.ModificarUnidades(oUnidades);
            return Redirect("~/Administracion/GestionUnidades");
        }

        //Método para eliminar información de una Unidad | Montalvo
        public ActionResult EliminarUnidad(GestionUnidadesBO oUnidades)
        {
            oUnidades.Id = Convert.ToInt32(Session["Id"]);
            UnidadesDAO.EliminarUnidad(oUnidades);
            Session["Id"] = null;
            return Redirect("~/Administracion/GestionUnidades");
        }

        public ActionResult PublicarNoticia(GestionNoticiasBO NoticiaBO)
        {
            NoticiaBO.Titulo = Request.Form["recipient-name"];
            NoticiaBO.Mensaje = Request.Form["message-text"];
            NoticiasDAO.AgregarNoticia(NoticiaBO);
            return Redirect("~/Administracion/Index");
        }

        public ActionResult Select_unidades()
        {
            Mod_Unidades UniBO = new Mod_Unidades();
            UniBO.Unidades = UnidadesDAO.ListUnid();
            return PartialView(UniBO);
        }

        public ActionResult Select_turnos()
        {
            Mod_Horarios Mod_Hor = new Mod_Horarios();
            Mod_Hor.Horarios = HorariosDAO.ListHor();
            return PartialView(Mod_Hor);
        }

        ////CONTROLADORES  DE GESTION DE EMPLEADOS/////
        public ActionResult AgregarEmpleado()
        {
            string valor = "";
            bool log = Convert.ToBoolean(Session["LogOK"]);
            if (log == true)
            {
                return View();
            }
            else
            {
                valor = "/FrontEnd/Login";
                return Redirect(valor);
            }
        }

        public ActionResult AgregarEmpleadoNVO(string nombre)
        {
            GestionEmpleadosBO oEmpleados = new GestionEmpleadosBO();
            oEmpleados.Nombre = nombre;
            return Content(nombre);
        }
        //oEmpleados.ApellidoPaterno = Request.Form["txtPaterno"];
        //oEmpleados.ApellidoMaterno = Request.Form["txtMaterno"];
        //oEmpleados.Direccion = Request.Form["txtDireccion"];
        //EmpleadosDAO.AgregarEmpleado(oEmpleados);          
        public ActionResult EliminarNoticia(GestionNoticiasBO NoticiaBO)
        {
            NoticiasDAO.EliminarNoticia(NoticiaBO);
            return Redirect("~/Administracion/Index");
        }

        public ActionResult DatosDeNoticias(GestionNoticiasBO oUnidades)
        {
            string valor = "";
            bool log = Convert.ToBoolean(Session["LogOK"]);
            if (log == true)
            {
                int idUn = oUnidades.Id;
                Session["Id"] = oUnidades.Id;
                return View(NoticiasDAO.LlenarCamposBtnNoticias(idUn));
            }
            else
            {
                valor = "/FrontEnd/Login";
                return Redirect(valor);
            }
        }

        public ActionResult Modificarnoticia(GestionNoticiasBO NoticiaBO)
        {
            NoticiaBO.Id = Convert.ToInt32(Request.Form["txtId"]);
            NoticiaBO.Titulo = Request.Form["txtSerie"];
            NoticiaBO.Mensaje = Request.Form["txtMatricula"];
            NoticiasDAO.ModificarNoticias(NoticiaBO);
            return Redirect("~/Administracion/Index");
        }
    }
}