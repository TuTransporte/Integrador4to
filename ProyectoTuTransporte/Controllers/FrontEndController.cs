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
        RegistroUsuarioDAO UsuarioDAO = new RegistroUsuarioDAO();
        // GET: FrontEnd        
        public ActionResult Index()
        {
            return View();
        }
        // Para poder visualizar la vista Login | Bryan
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult RegistroUsuario(RegistroUsuarioBO UsuarioBO)
        {
            UsuarioDAO.RegistroUsuario(UsuarioBO);
            return Redirect("~/FrontEnd/Login");
        }
    }
}