﻿using System;
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

        public ActionResult _GestionUnidades()
        {
            return View();
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
            int idUn = oUnidades.Id;
            Session["Id"] = oUnidades.Id;
            return PartialView("DatosDeUnidades", UnidadesDAO.LlenarCamposBtnUnidades(idUn));
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
            //oUnidades.Id = Convert.ToInt32(Request.Form["txtId"]);
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
    }
}