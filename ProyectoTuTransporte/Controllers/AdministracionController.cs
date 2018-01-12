using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoTuTransporte.DAO;
using ProyectoTuTransporte.BO;
using ProyectoTuTransporte.Models;
using System.Collections;
using System.Data.SqlClient;
using ReportViewerForMvc;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using ProyectoTuTransporte.Reportes;


namespace ProyectoTuTransporte.Controllers
{
    public class AdministracionController : Controller
    {
        ConexionDAO conex = new ConexionDAO();
        GestionEmpleadosDAO EmpleadosDAO = new GestionEmpleadosDAO();
        GestionUnidadesDAO UnidadesDAO = new GestionUnidadesDAO();
        PuntosDAO PuntosDAO = new PuntosDAO();
        GestionNoticiasDAO NoticiasDAO = new GestionNoticiasDAO();
        ChatDAO ChatDAO = new ChatDAO();
        GestionPerfilDAO PerfilDAO = new GestionPerfilDAO();
        HorariosDAO HorariosDAO = new HorariosDAO();
        GestionDenunciasDAO DenunciasDAO = new GestionDenunciasDAO();
        ds_Reports1 ds = new ds_Reports1();

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

        public ActionResult VerChat()
        {
            string valor = "";
            bool log = Convert.ToBoolean(Session["LogOK"]);
            int tipo = Convert.ToInt32(Session["Tipo"]);
            if (log == true)
            {
                if (tipo == 4)
                {
                    string correo = Session["Correo"].ToString();
                    return View(ChatDAO.MostarUsuarios(correo));
                }
                else
                {
                    return Redirect("/FrontEnd/Inicio");
                }
            }
            else
            {
                valor = "/FrontEnd/Login";
                return Redirect(valor);
            }
        }

        public ActionResult Chat(string personaenvia)
        {
            string link = "";
            bool log = Convert.ToBoolean(Session["LogOK"]);
            if (log == true)
            {
                string valor = "";
                if (personaenvia == null)
                {
                    personaenvia = Session["personaenvia"].ToString();
                }
                else
                {
                    Session["personaenvia"] = personaenvia;
                }
                int tipo = Convert.ToInt32(Session["Tipo"]);
                if (tipo == 4)
                {
                    valor = Session["personaenvia"].ToString();
                }
                else
                {
                    valor = Session["Correo"].ToString();
                }
                return View(ChatDAO.AbrirMensaje(valor));
            }
            else
            {
                link = "/FrontEnd/Login";
                return Redirect(link);
            }
        }

        public ActionResult PublicarMensaje(ChatBO oChatBO)
        {
            oChatBO.Mensaje = Request.Form["txtMensaje"];
            int tipo = Convert.ToInt32(Session["Tipo"]);
            if (tipo == 4)
            {
                oChatBO.PersonaEnvia = "admin@hotmail.com";
            }
            else
            {
                oChatBO.PersonaEnvia = Session["Correo"].ToString();
            }
            oChatBO.PersonaRecibe = Session["personaenvia"].ToString();
            oChatBO.Correo = Session["Correo"].ToString();
            ChatDAO.AgregarMensaje(oChatBO);
            return Redirect("~/Administracion/Chat");
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
        public ActionResult PerfilUsuario(RegistroUsuarioBO objususario)
        {
            string valor = "";
            bool log = Convert.ToBoolean(Session["LogOK"]);
            if (log == true)
            {
                try
                {
                    LoginDAO LoginDAO = new LoginDAO();
                    objususario.Contrasena = Session["Contraseña"].ToString();
                    objususario.Correo = Session["Correo"].ToString();
                    ArrayList datos = LoginDAO.Login(objususario);
                    Session["LogOK"] = true;
                    Session["Id"] = datos[0].ToString();
                    Session["Correo"] = datos[1].ToString();
                    Session["Nombres"] = datos[2].ToString();
                    Session["ApellidoPat"] = datos[3].ToString();
                    Session["ApellidoMat"] = datos[4].ToString();
                    Session["Telefono"] = datos[5].ToString();
                    Session["Tipo"] = datos[6].ToString();
                    Session["Contraseña"] = datos[7].ToString();
                }
                catch (Exception)
                {

                }
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
                Session["Id"] = objem.Id;
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
            string cadena = "";
            //Conexion Ricardo
            cadena = "DESKTOP-L9DKEN0\\SQLEXPRESS";
            //Conexion Montalvo
            //cadena = ".";
            //Conexion Bryan
            //cadena = "LAPTOP-5B0LK3E0";
            //-----------------------------------------------//
            string markers = "[";
            string conex = "Data Source= " + cadena + ";Initial Catalog=ProyectoTuTransporte;Integrated Security=True";
            SqlCommand cmd = new SqlCommand("SELECT * FROM PuntoReferencia WHERE Tipo LIKE '%Punto%'");

            using (SqlConnection con = new SqlConnection(conex))
            {
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        markers += "{";
                        markers += string.Format("'title': '{0}',", sdr["Nombre"]);
                        markers += string.Format("'lat': '{0}',", sdr["Latitud"]);
                        markers += string.Format("'lng': '{0}',", sdr["Longitud"]);
                        markers += string.Format("'description': '{0}'", sdr["Descripcion"]);
                        markers += "},";
                    }
                }
                con.Close();
            }

            markers += "];";
            ViewBag.Markers = markers;
            return View();

            //Funcion usada con la opcion de dibujo
            //using (SqlConnection con = new SqlConnection(conex))
            //{
            //    cmd.Connection = con;
            //    con.Open();
            //    using (SqlDataReader sdr = cmd.ExecuteReader())
            //    {
            //        while (sdr.Read())
            //        {
            //            markers += "[";
            //            markers += string.Format("'{0}',", sdr["Nombre"]);
            //            markers += string.Format("{0},", sdr["Latitud"]);
            //            markers += string.Format("{0},", sdr["Longitud"]);
            //            markers += string.Format("{0}", sdr["Descripcion"]);
            //            markers += "],";
            //        }
            //    }
            //    con.Close();
            //}
            //markers = markers.Remove(markers.Length - 1);
            //markers += "];";
            //ViewBag.Markers = markers;
            //return View();
        }

        public ActionResult AgregarPunto(PuntosBO oPuntos)
        {
            oPuntos.Id = Convert.ToInt32(Request.Form["txtId"]);
            oPuntos.Nombre = Request.Form["Nombox"];
            oPuntos.Latitud = Convert.ToDouble(Request.Form["latbox"]);
            oPuntos.Longitud = Convert.ToDouble(Request.Form["lngbox"]);
            oPuntos.Descripcion = Request.Form["Desbox"];
            oPuntos.Tipo = Request.Form["Tipbox"];
            PuntosDAO.AgregarPunto(oPuntos);
            return View();
        }

        public ActionResult ModificarPuntos(PuntosBO oPuntos)
        {
            oPuntos.Id = Convert.ToInt32(Request.Form["txtId"]);
            oPuntos.Nombre = Request.Form["Nombox"];
            oPuntos.Latitud = Convert.ToDouble(Request.Form["latbox"]);
            oPuntos.Longitud = Convert.ToDouble(Request.Form["lngbox"]);
            oPuntos.Descripcion = Request.Form["Desbox"];
            oPuntos.Tipo = Request.Form["Tipbox"];
            PuntosDAO.ModificarPuntos(oPuntos);
            return Redirect("~/Administracion/MapaAdmin");
        }

        public ActionResult EliminarPunto(PuntosBO oPuntos)
        {
            oPuntos.Id = Convert.ToInt32(Request.Form["txtId"]);
            oPuntos.Nombre = Request.Form["Nombox"];
            oPuntos.Latitud = Convert.ToDouble(Request.Form["latbox"]);
            oPuntos.Longitud = Convert.ToDouble(Request.Form["lngbox"]);
            oPuntos.Descripcion = Request.Form["Desbox"];
            oPuntos.Tipo = Request.Form["Tipbox"];
            PuntosDAO.EliminarPunto(oPuntos);
            return Redirect("~/Administracion/MapaAdmin");
        }

        public ActionResult DibujaMapa()
        {
            //string cadena = "";
            ////Conexion Ricardo
            //cadena = "DESKTOP-L9DKEN0\\SQLEXPRESS";
            ////Conexion Montalvo
            ////cadena = ".";
            ////Conexion Bryan
            ////cadena = "LAPTOP-5B0LK3E0";
            ////-----------------------------------------------//
            //string markers = "";
            //string conex = "Data Source= " + cadena + ";Initial Catalog=ProyectoTuTransporte;Integrated Security=True";
            //SqlCommand cmd = new SqlCommand("SELECT * FROM PuntoReferencia WHERE Tipo LIKE'%Cmetro%'");

            //using (SqlConnection con = new SqlConnection(conex))
            //{
            //    cmd.Connection = con;
            //    con.Open();
            //    using (SqlDataReader sdr = cmd.ExecuteReader())
            //    {
            //        while (sdr.Read())
            //        {
            //            markers += "myTrip.push";
            //            markers += "(";
            //            markers += "new google.maps.LatLng";
            //            markers += "(";
            //            markers += string.Format("{0},", sdr["Latitud"]);
            //            markers += string.Format("{0},", sdr["Longitud"]);
            //            markers += ")";
            //            markers += ");";
            //        }
            //    }
            //    con.Close();
            //}

            //markers = markers.Remove(markers.Length - 1);
            //markers += ";";
            //ViewBag.Markers = markers;
            return View();
        }

        public ActionResult _GestionUnidades()
        {
            return View();
        }

        public ActionResult ActualizarInfoU(GestionPerfilBO PerfilBO)
        {
            PerfilBO.Id = Convert.ToInt32(Request.Form["txtId"]);
            PerfilBO.Nombre = Request.Form["txtNombres"];
            PerfilBO.ApellidoPaterno = Request.Form["txtApellidoP"];
            PerfilBO.ApellidoMaterno = Request.Form["txtApellidoM"];
            PerfilBO.Correo = Request.Form["txtCorreo"];
            PerfilBO.Telefono = Request.Form["txtTelefono"];
            PerfilBO.Contraseña = Request.Form["txtContraseña"];
            PerfilDAO.ModificarPerfil(PerfilBO);
            Session["Correo"] = Request.Form["txtCorreo"];
            Session["Contraseña"] = Request.Form["txtContraseña"];
            string contrasena = Session["Contraseña"].ToString();
            return Redirect("~/Administracion/PerfilUsuario");
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
            string valor = "";
            bool log = Convert.ToBoolean(Session["LogOK"]);
            if (log == true)
            {
                int idUn = oUnidades.Id;
                Session["Id"] = oUnidades.Id;
                return PartialView("DatosDeUnidades", UnidadesDAO.LlenarCamposBtnUnidades(idUn));
            }
            else
            {
                valor = "/FrontEnd/Login";
                return Redirect(valor);
            }
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

        public ActionResult Select_unidades()
        {
            Mod_Unidades UniBO = new Mod_Unidades();
            UniBO.Unidades = UnidadesDAO.ListUnid();
            return PartialView(UniBO);
        }

        public ActionResult Select_turnos()
        {
            Mod_Horarios Mod_Hor = new Mod_Horarios();
            Mod_Hor.Horarios = HorariosDAO.ListHor();
            return PartialView(Mod_Hor);
        }

        ////CONTROLADORES  DE GESTION DE EMPLEADOS/////
        public ActionResult AgregarEmpleado()
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

        //public ActionResult AgregarEmpleadoNVO(string nombre)
        //{
        //    //oEmpleados.ApellidoPaterno = Request.Form["txtPaterno"];
        //    //oEmpleados.ApellidoMaterno = Request.Form["txtMaterno"];
        //    //oEmpleados.Direccion = Request.Form["txtDireccion"];
        //    //EmpleadosDAO.AgregarEmpleado(oEmpleados);       
        //    GestionEmpleadosBO oEmpleados = new GestionEmpleadosBO();
        //    oEmpleados.Nombre = nombre;
        //    return Content(nombre);
        //}

        //MÉTODOS PARA EMPLEADOS | MONTALVO
        public ActionResult AgregarEmpleadoNVO(GestionEmpleadosBO oEmpleados)
        {
            oEmpleados.Nombre = Request.Form["txtNombres"];
            oEmpleados.ApellidoPaterno = Request.Form["txtPaterno"];
            oEmpleados.ApellidoMaterno = Request.Form["txtMaterno"];
            oEmpleados.Direccion = Request.Form["txtDireccion"];
            EmpleadosDAO.AgregarEmpleado(oEmpleados);
            return Redirect("~/Administracion/GestionEmpleados");
        }

        public ActionResult ModificarEmpleado(GestionEmpleadosBO oEmpleados)
        {
            oEmpleados.Id = Convert.ToInt32(Request.Form["txtId"]);
            oEmpleados.Nombre = Request.Form["txtNombres"];
            oEmpleados.ApellidoPaterno = Request.Form["txtPaterno"];
            oEmpleados.ApellidoMaterno = Request.Form["txtMaterno"];
            oEmpleados.Direccion = Request.Form["txtDireccion"];
            EmpleadosDAO.ModificarEmpleado(oEmpleados);
            return Redirect("~/Administracion/GestionEmpleados");
        }

        public ActionResult EliminarEmpleado(GestionEmpleadosBO oEmpleados)
        {
            oEmpleados.Id = Convert.ToInt32(Session["Id"]);
            EmpleadosDAO.EliminarEmpleado(oEmpleados);
            Session["Id"] = null;
            return Redirect("~/Administracion/GestionEmpleados");
        }

        public ActionResult EliminarNoticia(GestionNoticiasBO NoticiaBO)
        {
            NoticiasDAO.EliminarNoticia(NoticiaBO);
            return Redirect("~/Administracion/Index");
        }

        public ActionResult DatosDeNoticias(GestionNoticiasBO oUnidades)
        {
            string valor = "";
            bool log = Convert.ToBoolean(Session["LogOK"]);
            if (log == true)
            {
                int idUn = oUnidades.Id;
                Session["Id"] = oUnidades.Id;
                return View(NoticiasDAO.LlenarCamposBtnNoticias(idUn));
            }
            else
            {
                valor = "/FrontEnd/Login";
                return Redirect(valor);
            }
        }

        public ActionResult Modificarnoticia(GestionNoticiasBO NoticiaBO)
        {
            NoticiaBO.Id = Convert.ToInt32(Request.Form["txtId"]);
            NoticiaBO.Titulo = Request.Form["txtSerie"];
            NoticiaBO.Mensaje = Request.Form["txtMatricula"];
            NoticiasDAO.ModificarNoticias(NoticiaBO);
            return Redirect("~/Administracion/Index");
        }

        public ActionResult Aprobadas()
        {

            return View(DenunciasDAO.ListDenunciasApro());
        }

        public ActionResult AprobadasDatos(GestionDenunciasBO oDenuncias)
        {
            int idUn = oDenuncias.Id;
            Session["Id"] = oDenuncias.Id;
            return View(DenunciasDAO.LlenarCamposBtnDen(idUn));
        }

        public ActionResult Rechazadas()
        {
            return View(DenunciasDAO.ListDenunciasRech());
        }

        public ActionResult RechazadasDatos(GestionDenunciasBO oDenuncias)
        {
            int idUn = oDenuncias.Id;
            Session["Id"] = oDenuncias.Id;
            return View(DenunciasDAO.LlenarCamposBtnDen(idUn));
        }

        public ActionResult Pendientes()
        {
            return View(DenunciasDAO.ListDenunciasPend());
        }

        public ActionResult PendientesDatos(GestionDenunciasBO oDenuncias)
        {
            int idUn = oDenuncias.Id;
            Session["Id"] = oDenuncias.Id;
            return View(DenunciasDAO.LlenarCamposBtnDen(idUn));
        }

        public ActionResult ApDenuncia(GestionDenunciasBO oDenuncias)
        {
            oDenuncias.Id = Convert.ToInt32(Request.Form["txtId"]);
            oDenuncias.Estado = Convert.ToInt32(Request.Form["txtEst"]);
            DenunciasDAO.ModificarAprovado(oDenuncias);
            return Redirect("~/Administracion/Pendientes");
        }

        public ActionResult ApDenuncia2(GestionDenunciasBO oDenuncias)
        {
            oDenuncias.Id = Convert.ToInt32(Request.Form["txtId"]);
            oDenuncias.Estado = Convert.ToInt32(Request.Form["txtEst"]);
            DenunciasDAO.ModificarAprovado(oDenuncias);
            return Redirect("~/Administracion/Rechazadas");
        }

        public ActionResult RechDenuncia(GestionDenunciasBO oDenuncias)
        {
            oDenuncias.Id = Convert.ToInt32(Session["Id"]);
            DenunciasDAO.ModificarRechazado(oDenuncias);
            Session["Id"] = null;
            DenunciasDAO.ModificarRechazado(oDenuncias);
            return Redirect("~/Administracion/Pendientes");
        }

        public ActionResult RechDenuncia2(GestionDenunciasBO oDenuncias)
        {
            oDenuncias.Id = Convert.ToInt32(Session["Id"]);
            DenunciasDAO.ModificarRechazado(oDenuncias);
            Session["Id"] = null;
            DenunciasDAO.ModificarRechazado(oDenuncias);
            return Redirect("~/Administracion/Aprobadas");
        }

        public ActionResult ReporteEmpleados()
        {
            ReportViewer rp = new ReportViewer();
            rp.ProcessingMode = ProcessingMode.Local;
            rp.SizeToReportContent = true;
            string sql = "SELECT Id, Serie, Matricula, Comentarios FROM Camiones";
            SqlDataAdapter adp = new SqlDataAdapter(sql, conex.EstablecerConexion());
            adp.Fill(ds, "Unidades");
            rp.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reportes/Report1.rdlc";
            rp.LocalReport.DataSources.Add(new ReportDataSource("Unidades", ds.Tables[0]));
            ViewBag.ReportViewer = rp;
            return View();
        }

        public ActionResult ReportesEmp()
        {
            ReportViewer rp = new ReportViewer();
            rp.ProcessingMode = ProcessingMode.Local;
            rp.SizeToReportContent = true;
            string sql = "SELECT Id, Nombre, Direccion, ApellidoPaterno, ApellidoMaterno FROM  Choferes";
            SqlDataAdapter adp = new SqlDataAdapter(sql, conex.EstablecerConexion());
            adp.Fill(ds, "Empleado");
            rp.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reportes/ReporteEmpleados.rdlc";
            rp.LocalReport.DataSources.Add(new ReportDataSource("Empleado", ds.Tables[0]));
            ViewBag.ReportViewer = rp;
            return View();
        }
    }
}