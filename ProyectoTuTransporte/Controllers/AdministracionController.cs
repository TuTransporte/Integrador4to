using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoTuTransporte.Controllers
{
    public class AdministracionController : Controller
    {
        // GET: Administracion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GestionEmpleados()
        {
            return PartialView("_GestionEmpleados");
        }



        public ActionResult _GestionEmpleados()
        {
            return View();
        }

        // Para poder visualizar la vista ControlDenuncias | Bryan
        public ActionResult ControlDenuncias()
        {
            return View();
        }
        // Para poder visualizar la vista PerfilUsuario | Bryan
        public ActionResult PerfilUsuario()
        {
            return View();
        }
        //Para poder visualizar la vista GestionEmpleados | Montalvo
       
    }
}