using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoTuTransporte.DAO;
using ProyectoTuTransporte.BO;
using System.Collections;


using System.Configuration;
using System.Data.SqlClient;

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
            string markers = "[";
            string conex = "Data Source= DESKTOP-L9DKEN0\\SQLEXPRESS;Initial Catalog=PruebaArrays;Integrated Security=True";
            SqlCommand cmd = new SqlCommand("SELECT * FROM Locations");

            using (SqlConnection con = new SqlConnection(conex))
            {
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        markers += "[";
                        markers += string.Format("'{0}',", sdr["Name"]);
                        markers += string.Format("{0},", sdr["Latitude"]);
                        markers += string.Format("{0},", sdr["Longitude"]);
                        markers += string.Format("{0}", sdr["Description"]);
                        markers += "],";
                    }
                }
                con.Close();
            }

            markers = markers.Remove(markers.Length - 1);
            markers += "];";
            ViewBag.Markers = markers;
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
        public ActionResult ModificarUnidades(GestionUnidadesBO oUnidades)
        {
            var r = oUnidades.Id > 0 ?
                   UnidadesDAO.ModificarUnidades(oUnidades) :
                   UnidadesDAO.AgregarUnidades(oUnidades);

            return Redirect("~/Administracion/GestionUnidades");
        }
    }
}