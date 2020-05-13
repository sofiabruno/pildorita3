using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio;
using Repositorios;
using WebMVC.ViewModels;
using UtilidadesArchivos;

namespace WebMVC.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        // Login Usuario
        public ActionResult Login(string mensaje)
        {
            ViewBag.Mensaje = mensaje;

            return View();
        }

        // Validar Login Usuario
        [HttpPost]
        public ActionResult Validar(int ci, string password)
        {
            Usuario u = FachadaPortLog.BuscarUsuarioPorId(ci);

            if (u != null)
            {
                if (u.Password == password)
                {
                    Session["rol"] = u.Rol;
                    Session["usuario"] = u;

                    return Redirect("/Home/Index");
                }
                else
                {
                    return RedirectToAction("Login", new { mensaje = "La contraseña no es correcta" });
                }
            }
            else
            {
                return RedirectToAction("Login", new { mensaje = "El usuario no está ingresado en el sistema" });
            }
        }


        // Cerrar Sesión Usuario
        public ActionResult Salir()
        {
            Session["rol"] = null;
            Session["usuario"] = null;

            return Redirect("/Home/Index");
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int ci)
        {
            if (Session["rol"] == null)
                return Redirect("/Home/Index");

            if (Session["rol"].ToString() != "admin")
                return Redirect("/Home/Index");

            Usuario usuario = FachadaPortLog.BuscarUsuarioPorId(ci);

            return View(usuario);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            if (Session["rol"] == null)
                return Redirect("/Home/Index");

            if (Session["rol"].ToString() != "admin")
                return Redirect("/Home/Index");

            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(ViewModelUsuario usuario)
        {
            try
            {
                bool ret = FachadaPortLog.AltaUsuario(usuario.Ci, usuario.Password, usuario.Rol.ToString());

                if (ret)
                {
                    return Redirect("/Usuario/List");
                }
                else
                {
                    ViewBag.Mensaje = "Ha ocurrido un error al ingresar el usuario";

                    return View(usuario);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int ci)
        {
            if (Session["rol"] == null)
                return Redirect("/Home/Index");

            if (Session["rol"].ToString() != "admin")
                return Redirect("/Home/Index");

            Usuario usuario = FachadaPortLog.BuscarUsuarioPorId(ci);

            return View(usuario);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(int ci, Usuario usuario)
        {
            try
            {
                FachadaPortLog.ModificacionUsuario(usuario.Ci, usuario.Password, usuario.Rol);

                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int ci)
        {
            if (Session["rol"] == null)
                return Redirect("/Home/Index");

            if (Session["rol"].ToString() != "admin")
                return Redirect("/Home/Index");

            Usuario usuario = FachadaPortLog.BuscarUsuarioPorId(ci);

            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int ci, Usuario usuario)
        {
            try
            {
                FachadaPortLog.BajaUsuario(ci);

                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/List
        [HttpGet]
        public ActionResult List()
        {
            if (Session["rol"] == null)
                return Redirect("/Home/Index");

            if (Session["rol"].ToString() != "admin")
                return Redirect("/Home/Index");

            return View(FachadaPortLog.TraerTodosLosUsuarios());
        }


        public ActionResult GenerarTxt()
        {
            if (Session["rol"] == null)
                return Redirect("/Home/Index");

            ArchivoDelimitado.GuardarUsuariosArchivo("#", "ArchivosTexto", "DatosUsuarios.txt");
            ArchivoDelimitado.GuardarClientesArchivo("#", "ArchivosTexto", "DatosClientes.txt");
            ArchivoDelimitado.GuardarProductosArchivo("#", "ArchivosTexto", "DatosProductos.txt");
            ArchivoDelimitado.GuardarImportacionesArchivo("#", "ArchivosTexto", "DatosImportaciones.txt");

            return Redirect("/Home/Index");
        }



    }
}
