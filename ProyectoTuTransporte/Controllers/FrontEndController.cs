using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoTuTransporte.Controllers
{
    public class FrontEndController : Controller
    {
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
    }
}