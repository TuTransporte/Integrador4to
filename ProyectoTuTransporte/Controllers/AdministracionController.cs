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
using System.Data;
using ReportViewerForMvc;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using ProyectoTuTransporte.Reportes;


namespace ProyectoTuTransporte.Controllers
{
    public class AdministracionController : Controller
    {
        ConexionDAO conex = new ConexionDAO();
        GestionConcesionarias ConcesionariasDAO = new GestionConcesionarias();
        GestionUnidadesDAO UnidadesDAO = new GestionUnidadesDAO();
        PuntosDAO PuntosDAO = new PuntosDAO();
        GestionNoticiasDAO NoticiasDAO = new GestionNoticiasDAO();
        ChatDAO ChatDAO = new ChatDAO();
        GestionPerfilDAO PerfilDAO = new GestionPerfilDAO();
        HorariosDAO HorariosDAO = new HorariosDAO();
        GestionDenunciasDAO DenunciasDAO = new GestionDenunciasDAO();
        ds_Reports1 ds = new ds_Reports1();
        EstadisticasDAO EstadisticasDAO = new EstadisticasDAO();

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

        public ActionResult PublicarMensaje(ChatBO oChatBO)
        {
            string valor = "";
            bool log = Convert.ToBoolean(Session["LogOK"]);
            if (log == true)
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

        public ActionResult PublicarMensajeDenuncia(ChatBO oChatBO)
        {
            string valor = "";
            bool log = Convert.ToBoolean(Session["LogOK"]);
            if (log == true)
            {
                oChatBO.Mensaje = Request.Form["txtMensaje"];
                int tipo = Convert.ToInt32(Session["Tipo"]);
                int IdDenuncia = Convert.ToInt32(Request.QueryString["Id"]);
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
                oChatBO.IdDenuncia = Convert.ToInt32(Request.QueryString["Id"]);
                ChatDAO.AgregarMensajeDenuncia(oChatBO);
                return Redirect("~/Administracion/ChatDenuncia");
            }
            else
            {
                valor = "/FrontEnd/Login";
                return Redirect(valor);
            }
        }

        public ActionResult ChatDenuncia(string Ruta, int Id)
        {
            string link = "";
            bool log = Convert.ToBoolean(Session["LogOK"]);
            if (log == true)
            {
                string valor = "";
                if (Ruta == null)
                {
                    Ruta = Session["personaenvia"].ToString();
                }
                else
                {
                    Session["personaenvia"] = Ruta;
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
                return View(ChatDAO.AbrirMensajeDenuncia(valor, Convert.ToInt32(Request.QueryString["Id"])));
            }
            else
            {
                link = "/FrontEnd/Login";
                return Redirect(link);
            }
        }

        public ActionResult GestionEmpleados()
        {
            string valor = "";
            bool log = Convert.ToBoolean(Session["LogOK"]);
            if (log == true)
            {
                return PartialView("_GestionEmpleados", ConcesionariasDAO.ListarConcesionarias());
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
                return PartialView("DatosdelUsuario", ConcesionariasDAO.LlenarCamposBtnConcesionarias(idus));
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
            //cadena = "DESKTOP-L9DKEN0\\SQLEXPRESS";
            //Conexion Montalvo
            cadena = ".";
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
        public ActionResult AgregarConcesionariaNVO(RegistroUsuarioBO oConcesionarias)
        {
            oConcesionarias.Nombre = Request.Form["txtNombres"];
            oConcesionarias.Horario = Request.Form["txtHorario"];
            oConcesionarias.Telefono = Request.Form["txtTelefono"];
            oConcesionarias.Direccion = Request.Form["txtDireccion"];
            oConcesionarias.RazonSocial = Request.Form["txtRazon"];
            oConcesionarias.RFC = Request.Form["txtRFC"];
            oConcesionarias.Correo = Request.Form["txtCorreo"];
            oConcesionarias.Contrasena = Request.Form["txtContrasena"];
            ConcesionariasDAO.AgregarConcesionarias(oConcesionarias);
            return Redirect("~/Administracion/GestionEmpleados");
        }

        public ActionResult ModificarEmpleado(RegistroUsuarioBO oConcesionarias)
        {
            oConcesionarias.Id = Convert.ToInt32(Request.Form["txtId"]);
            oConcesionarias.Nombre = Request.Form["txtNombres"];
            oConcesionarias.Horario = Request.Form["txtHorario"];
            oConcesionarias.Telefono = Request.Form["txtTelefono"];
            oConcesionarias.Direccion = Request.Form["txtDireccion"];
            oConcesionarias.RazonSocial = Request.Form["txtRazon"];
            oConcesionarias.RFC = Request.Form["txtRFC"];
            oConcesionarias.Correo = Request.Form["txtCorreo"];
            oConcesionarias.Contrasena = Request.Form["txtContrasena"];
            ConcesionariasDAO.ModificarConcesionaria(oConcesionarias);
            return Redirect("~/Administracion/GestionEmpleados");
        }

        public ActionResult EliminarEmpleado(RegistroUsuarioBO oConcesionarias)
        {
            oConcesionarias.Id = Convert.ToInt32(Session["Id"]);
            ConcesionariasDAO.EliminarConcesionaria(oConcesionarias);
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
            string valor = "";
            bool log = Convert.ToBoolean(Session["LogOK"]);
            int tipo = Convert.ToInt32(Session["Tipo"]);
            if (log == true)
            {
                if (tipo == 4)
                {
                    return View(DenunciasDAO.ListDenunciasPend());
                }
                else
                {
                    return Redirect("/FrontEnd/Pendientes");
                }
            }
            else
            {
                valor = "/FrontEnd/Login";
                return Redirect(valor);
            }
        }

        public ActionResult PendientesDatos(GestionDenunciasBO oDenuncias)
        {
            int idUn = oDenuncias.Id;
            Session["Id"] = oDenuncias.Id;
            string valor = "";
            bool log = Convert.ToBoolean(Session["LogOK"]);
            int tipo = Convert.ToInt32(Session["Tipo"]);
            if (log == true)
            {
                return View(DenunciasDAO.LlenarCamposBtnDen(idUn));
                //string correo = Session["Correo"].ToString();                
            }
            else
            {
                valor = "/FrontEnd/Login";
                return Redirect(valor);
            }
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
            string sql = "SELECT Id, Correo_usuario, Nombres, Telefono, Direccion, RFC, Horario, RazonSocial FROM  Usuario Where Tipo_usuario = 1";
            SqlDataAdapter adp = new SqlDataAdapter(sql, conex.EstablecerConexion());
            adp.Fill(ds, "Concesionarias");
            rp.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reportes/ReporteEmpleados.rdlc";
            rp.LocalReport.DataSources.Add(new ReportDataSource("Concesionarias", ds.Tables[0]));
            ViewBag.ReporteEmps = rp;
            return View();
        }


        public ActionResult EstadisticasCharts()
        {
            obtenerDatosDenuncias();
            obtenerDatosMotivos();
            return View();
        }

        public string obtenerDatosDenuncias()
        {
            SqlConnection conex = new SqlConnection("Data Source = SQL5035.site4now.net; Initial Catalog = DB_A3402F_TuTransporte; User Id = DB_A3402F_TuTransporte_admin; Password = baba131998.13;");

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DenunciaChart";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conex;
            conex.Open();

            DataTable Datos = new DataTable();
            Datos.Load(cmd.ExecuteReader());
            conex.Close();

            string strDatos;
            strDatos= "[['Rutas', 'Denuncias Relacionadas'],";
            foreach (DataRow dr in Datos.Rows)
            {
                strDatos = strDatos + "[";
                strDatos = strDatos + "'" + dr[1] + "'" + "," + dr[0];
                strDatos = strDatos + "],";
            }

            strDatos = strDatos + "]";
            ViewBag.Markers = strDatos;

            return strDatos;

            //-----------------------------------------------//

            //string markers = "[['Rutas', 'Denuncias Relacionadas'],";
            //string conex = "Data Source=SQL5035.site4now.net;Initial Catalog=DB_A3402F_TuTransporte;User Id=DB_A3402F_TuTransporte_admin;Password=baba131998.13;";

            //SqlCommand cmd = new SqlCommand("DenunciaChart");

            //using (SqlConnection con = new SqlConnection(conex))
            //{
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Connection = con;
            //    con.Open();
            //    using (SqlDataReader sdr = cmd.ExecuteReader())
            //    {
            //        while (sdr.Read())
            //        {
            //            markers += "[";
            //            markers += string.Format("'{0}',", sdr["Ruta"]);
            //            markers += string.Format("{0},", sdr["Denuncias"]);
            //            markers += "],";
            //        }
            //    }
            //    con.Close();
            //}
            //markers = markers.TrimEnd(',');
            //markers += "]";
            //ViewBag.Markers = markers;


            //return markers;
        }

        public string obtenerDatosMotivos()
        {
            SqlConnection conex = new SqlConnection("Data Source = SQL5035.site4now.net; Initial Catalog = DB_A3402F_TuTransporte; User Id = DB_A3402F_TuTransporte_admin; Password = baba131998.13;");

            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "MotivoChart"; //Se selecciona el stored procedure a ejecutar
            cmd.CommandType = CommandType.StoredProcedure;//En caso de trabajar con una sentenci se cambia a CommandType.Text;
            cmd.Connection = conex;
            conex.Open();

            DataTable Datos = new DataTable();
            Datos.Load(cmd.ExecuteReader());
            conex.Close();

            string strDatos;
            strDatos = "[['Motivos', 'Denuncias Relacionadas'],"; //Títulos a Trabajar en la Gráfica
            foreach (DataRow dr in Datos.Rows)
            {
                strDatos = strDatos + "[";
                strDatos = strDatos + "'" + dr[1] + "'" + "," + dr[0];
                strDatos = strDatos + "],";
            }

            strDatos = strDatos + "]";
            ViewBag.Markers2 = strDatos;

            return strDatos;
        }

 }
}
