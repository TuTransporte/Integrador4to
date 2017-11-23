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
    public class AdministracionController : Controller
    {
        GestionEmpleadosDAO EmpleadosDAO = new GestionEmpleadosDAO();
        // GET: Administracion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GestionEmpleados()
        {
            return PartialView("_GestionEmpleados", EmpleadosDAO.ListarEmpleados());
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
        public ActionResult DatosdelUsuario(GestionEmpleadosBO objem)
        {
            int idus = objem.Id;
            return PartialView("DatosdelUsuario", EmpleadosDAO.LlenarCamposBtnEmpleados(idus));
        }

        //Para poder visualizar la vista Mapas | Ricardo
        public ActionResult MapaAdmin()
        {
            return View();
        }
    }
}