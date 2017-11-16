using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoTuTransporte.DAO;
using ProyectoTuTransporte.BO;

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
        // Para poder visualizar la vista Login | Bryan
        public ActionResult Login(RegistroUsuarioBO UsuarioBO)
        {
            return View();
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
                return Redirect("Login");
            }
            else
            {
                return View();
            }
    
        }
        //public ActionResult IniciarSesion(object UsuarioBO)
        //{
        //    //string Modulo = "";
        //    //var r = LoginDAO.Iniciar(UsuarioBO);
        //    //if (r != null)
        //    //{
        //    //    Session["log"] = true;
        //    //    return  Redirect("Index");
        //    //}
        //    //else
        //    //{
        //    //    Session["log"] = true;
        //    //    return Redirect("~/Administracion/Index");
        //    //}
        //    //if (LoginDAO.IniciarSesion(r))
        //    //{
        //    //    return Redirect("Index");
        //    //}
        //    //else
        //    //{
        //    //    return Redirect("Login");
        //    //}            

        //    //return Redirect("~/FrontEnd/Index");
        //}

        public ActionResult AgregarU(RegistroUsuarioBO objeus)
        {

            UsuarioDAO.Agregar(objeus);
            return View("~/Inicio/Inicial");
        }


        //public ActionResult Iniciarsesion()
        //{

        //}
    }
}