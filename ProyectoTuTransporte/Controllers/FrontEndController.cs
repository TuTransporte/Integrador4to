﻿using System;
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
        public ActionResult Login(RegistroUsuarioBO UsuarioBO)
        {
             //UsuarioDAO.RegistroUsuario(UsuarioBO);  
            return PartialView("_Registro");
        }

        //public ActionResult _Registro(RegistroUsuarioBO UsuarioBO)
        //{
        //    UsuarioDAO.RegistroUsuario(UsuarioBO);            
        //    return View();
        //}

        //public ActionResult RegistroUsuario(RegistroUsuarioBO UsuarioBO)
        //{
        //    UsuarioDAO.RegistroUsuario(UsuarioBO);
        //    return RedirectToAction("Login");
        //}
        public ActionResult Iniciarsesion()
        {
            if (UsuarioDAO.VerificarUsuario() == true)
            {                            
                return Redirect("Index");
            }
            else
            {
                return Redirect("Login");
            }
        }
    }
}