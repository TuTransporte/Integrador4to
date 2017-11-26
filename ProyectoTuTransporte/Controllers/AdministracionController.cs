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
        GestionUnidadesDAO UnidadesDAO = new GestionUnidadesDAO();
        GestionNoticiasDAO NoticiasDAO = new GestionNoticiasDAO();
        // GET: Administracion
        public ActionResult Index()
        {
            return View(NoticiasDAO.MostarNoticias());
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
        public ActionResult _GestionUnidades()
        {
            return View();
        }
        public ActionResult GestionUnidades()
        {
            return PartialView("_GestionUnidades", UnidadesDAO.ListarUnidades());
        }
        public ActionResult DatosDeUnidades(GestionUnidadesBO oUnidades)
        {
            int idUn = oUnidades.Id;
            return PartialView("DatosDeUnidades", UnidadesDAO.LlenarCamposBtnUnidades(idUn));
        }
    }
}