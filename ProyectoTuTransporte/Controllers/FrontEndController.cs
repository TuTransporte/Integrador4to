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
        // GET: FrontEnd        
        public ActionResult Index()
        {
            return View();
        }

        public  ActionResult Login()
        {
            return View();
        }

        // Para poder visualizar la vista Login | Bryan
        public ActionResult Iniciarsesion(RegistroUsuarioBO objeus)
        {
            objeus.Correo = Request.Form["txtCorreo"];
            objeus.Contrasena = Request.Form["txtContra"];
            ArrayList datos = LoginDAO.Login(objeus);
            if (datos.Count > 0)
            {
                Session["ID"] = datos[0].ToString();
                Session["idtipo"] = datos[2].ToString();


                return Redirect("~/FrontEnd/LogOK");

            }
            else
            {
                return Redirect("Index");
            }

            
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
                UsuarioDAO.Agregar(UsuarioBO);
                return Redirect("Index");
            }
            else
            {
                return View();
            }
    
        }

       public ActionResult LogOK()
        {
            return View();
        }

        
    }
}