using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoTuTransporte.DAO;
using ProyectoTuTransporte.BO;
using System.Collections;

namespace ProyectoTuTransporte.Controllers
{
    public class FrontEndController : Controller
    {
        UsuarioDAO UsuarioDAO = new UsuarioDAO();
        LoginDAO LoginDAO = new LoginDAO();
        GestionPerfilDAO PerfilDAO = new GestionPerfilDAO();
        GestionNoticiasDAO NotiDAO = new GestionNoticiasDAO();
        GestionDenunciasDAO DenunciasDAO = new GestionDenunciasDAO();

        // GET: FrontEnd        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Inicio()
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

        public ActionResult PanelUsuario(RegistroUsuarioBO objususario)
        {
            Session["personaenvia"] = "admin@hotmail.com";
            string valor = "";
            bool log = Convert.ToBoolean(Session["LogOK"]);
            if (log == true)
            {
                try
                {
                    objususario.Contrasena = Session["Contraseña"].ToString();
                    objususario.Correo = Session["Correo"].ToString();
                    ArrayList datos = LoginDAO.Login(objususario);
                    Session["LogOK"] = true;
                    Session["Id"] = datos[0].ToString();
                    Session["Correo"] = datos[1].ToString();
                    Session["Nombres"] = datos[2].ToString();
                    Session["ApellidoPat"] = datos[3].ToString();
                    Session["ApellidoMat"] = datos[4].ToString();
                    Session["Telefono"] = datos[5].ToString();
                    Session["Tipo"] = datos[6].ToString();
                    Session["Contraseña"] = datos[7].ToString();
                    Session["Direccion"] = datos[8].ToString();
                    Session["RFC"] = datos[9].ToString();
                    Session["Horario"] = datos[10].ToString();
                    Session["Razon"] = datos[11].ToString();
                    Session["Imagen"] = datos[12].ToString();
                }
                catch (Exception)
                {
                }
                return View();
            }
            else
            {
                valor = "/FrontEnd/Login";
                return Redirect(valor);
            }
        }

        // Para poder visualizar la vista Login | Bryan
        public ActionResult IniciarSesion(RegistroUsuarioBO objususario)
        {
            string link = "Login";
            objususario.Correo = Request.Form["txtCorreo"];
            objususario.Contrasena = Request.Form["txtContra"];
            ArrayList datos = LoginDAO.Login(objususario);
            if (datos.Count > 0)
            {
                if (datos[6].ToString() == "4")
                {
                    link = "~/Administracion/Index";
                }
                else
                {
                    if (datos[6].ToString() == "2")
                    {
                        link = "~/FrontEnd/PanelUsuario";
                    }
                    else
                    {
                        link = "Login";
                    }
                }
            }
            try
            {
                Session["LogOK"] = true;
                Session["Id"] = datos[0].ToString();
                Session["Correo"] = datos[1].ToString();
                Session["Nombres"] = datos[2].ToString();
                Session["ApellidoPat"] = datos[3].ToString();
                Session["ApellidoMat"] = datos[4].ToString();
                Session["Telefono"] = datos[5].ToString();
                Session["Tipo"] = datos[6].ToString();
                Session["Contraseña"] = datos[7].ToString();
                Session["Direccion"] = datos[8].ToString();
                Session["Horario"] = datos[9].ToString();
                Session["RFC"] = datos[10].ToString();
                Session["Razon"] = datos[11].ToString();
            }
            catch (Exception)
            {

            }
            return Redirect(link);
        }

        public ActionResult Cerrarsesion()
        {
            Session["LogOK"] = false;
            Session["Id"] = "";
            Session["Correo"] = "";
            Session["Nombres"] = "";
            Session["ApellidoPat"] = "";
            Session["ApellidoMat"] = "";
            Session["Telefono"] = "";
            Session["Tipo"] = "";
            Session["Contraseña"] = "";
            return Redirect("~/FrontEnd/Login");
        }

        //Ejecuta el registro de usuario
        public ActionResult RegistroUsuario(RegistroUsuarioBO UsuarioBO)
        {
            UsuarioBO.Nombre = Request.Form["txtNombre"];
            UsuarioBO.ApellidoPaterno = Request.Form["txtApellidop"];
            UsuarioBO.ApellidoMaterno = Request.Form["txtApellidom"];
            UsuarioBO.Correo = Request.Form["txtCorreo"];
            UsuarioBO.Contrasena = Request.Form["txtContra"];
            UsuarioBO.Telefono = Request.Form["txttelefono"];
            string contra2 = Request.Form["txtContrase"];
            if (UsuarioBO.Contrasena == contra2)
            {
                UsuarioDAO.AgregarUsuarios(UsuarioBO);
                return Redirect("Index");
            }
            else
            {
                return Redirect("~/FrontEnd/Login");
            }
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
            PerfilBO.Direccion = Request.Form["txtDireccion"];
            PerfilBO.RFC = Request.Form["txtRFC"];
            PerfilBO.Horario = Request.Form["txtHorario"];
            PerfilBO.RazonSocial = Request.Form["txtRazon"];
            PerfilBO.Imagen = Request.Form["b64"];
            PerfilDAO.ModificarPerfilConcesionaria(PerfilBO);
            Session["Correo"] = Request.Form["txtCorreo"];
            Session["Contraseña"] = Request.Form["txtContraseña"];
            string contrasena = Session["Contraseña"].ToString();
            return Redirect("~/FrontEnd/PanelUsuario");
        }

        public ActionResult Noticias(GestionNoticiasBO NoticiaBO)
        {
            string valor = "";
            bool log = Convert.ToBoolean(Session["LogOK"]);
            if (log == true)
            {
                return View(NotiDAO.MostarNoticias());
            }
            else
            {
                valor = "/FrontEnd/Login";
                return Redirect(valor);
            }
        }

        public ActionResult Pendientes()
        {
            string valor = "";
            bool log = Convert.ToBoolean(Session["LogOK"]);
            if (log == true)
            {
                return View(DenunciasDAO.ListDenunciasPendConcesionaria(Session["Nombres"].ToString()));
            }
            else
            {
                valor = "/FrontEnd/Login";
                return Redirect(valor);
            }
        }

        public ActionResult PendientesDatos(GestionDenunciasBO oDenuncias)
        {
            int idUn = oDenuncias.Id;
            Session["Id"] = oDenuncias.Id;
            string valor = "";
            bool log = Convert.ToBoolean(Session["LogOK"]);
            int tipo = Convert.ToInt32(Session["Tipo"]);
            if (log == true)
            {
                //string correo = Session["Correo"].ToString();
                return View(DenunciasDAO.LlenarCamposBtnDenConcesionaria(idUn));
            }
            else
            {
                valor = "/FrontEnd/Login";
                return Redirect(valor);
            }
        }
    }
}
