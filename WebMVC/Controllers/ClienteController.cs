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
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            if (Session["rol"] == null)
                return Redirect("/Home/Index");

            if (Session["rol"].ToString() != "deposito")
                return Redirect("/Home/Index");

            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(ViewModelCliente cliente)
        {
            try
            {
                bool ret = FachadaPortLog.AltaCliente(cliente.Nombre, cliente.Rut, cliente.Antiguedad);

                if (ret)
                {
                    ViewBag.Mensaje = "El cliente se ha ingresado con exito";
                    // Como mostrar este mensaje al usuario unos segundos?
                }

                return Redirect("/Home/Index");
            }
            catch
            {
                ViewBag.Mensaje = "Ha ocurrido un error al ingresar el cliente";

                return View(cliente);
            }
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cliente/Edit/5
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

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cliente/Delete/5
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

        // GET: Cliente/List
        [HttpGet]
        public ActionResult List()
        {
            if (Session["rol"] == null)
                return Redirect("/Home/Index");

            if (Session["rol"].ToString() != "deposito")
                return Redirect("/Home/Index");

            return View(FachadaPortLog.TraerTodosLosClientes());
        }




    }
}
