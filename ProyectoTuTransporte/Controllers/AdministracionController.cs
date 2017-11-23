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
        GestionEmpleadosDAO empleadosDAO = new GestionEmpleadosDAO();
        // GET: Administracion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GestionEmpleados()
        {

            //oBO.Nombre = Request.QueryString["txtNombre"];
            //oBO.ApellidoPaterno = Request.QueryString["txtApellidop"];
            //oBO.ApellidoMaterno = Request.QueryString["txtApellidom"];
            //oBO.Turno = Request.QueryString["txtTurno"];

            //ArrayList datosEmp = empleadosDAO.Listar(oBO);

            //return PartialView("_GestionEmpleados");
            return PartialView("_GestionEmpleados", empleadosDAO.Listar());
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
            return PartialView("DatosdelUsuario", empleadosDAO.LlenarCampos(idus));
        }

        public ActionResult MapaAdmin()
        {
            return View();
        }

    }

        
    
}