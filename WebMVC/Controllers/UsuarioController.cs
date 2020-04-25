using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio;
using Repositorios;
using WebMVC.ViewModels;

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
                return RedirectToAction("Login", new { mensaje = "El usuario no existe" });
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
        public ActionResult Details(int id)
        {
            return View();
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
                bool ret = FachadaPortLog.AltaUsuario(usuario.Ci, usuario.Password, usuario.Rol);

                if (ret)
                {
                    ViewBag.Mensaje = "El usuario se ha ingresado con exito";
                    // Como mostrar este mensaje al usuario unos segundos?
                }

                return Redirect("/Home/Index");
            }
            catch
            {
                ViewBag.Mensaje = "Ha ocurrido un error al ingresar el usuario";

                return View(usuario);
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
