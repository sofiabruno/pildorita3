using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio;
using Repositorios;
using WebMVC.ViewModels;
using WebMVC.ServicioImportaciones;

namespace WebMVC.Controllers
{
    public class ImportacionController : Controller
    {
        // GET: Importacion
        public ActionResult Index()
        {
            return View();
        }

        // GET: Importacion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Importacion/Create
        public ActionResult Create()
        {
            if (Session["rol"] == null)
                return Redirect("/Home/Index");

            if (Session["rol"].ToString() == "admin")
                return Redirect("/Home/Index");

            return View();
        }

        // POST: Importacion/Create
        [HttpPost]
        public ActionResult Create(ViewModelImportacion importacion)
        {
            //convierto mis datos del cliente en DTOimportacion

            DTOImportacion import = new DTOImportacion()
            {
                FechaIngreso= importacion.FechaIngreso,
                SalidaPrevista = importacion.SalidaPrevista,
                IdProducto = importacion.IdProducto,
                Cantidad = importacion.Cantidad,
                PrecioUnitario = importacion.PrecioUnitario                

            };

            //consumo mi servicio importaciones
            ServicioImportacionClient proxy = new ServicioImportacionClient();
                        
            try
            {
                bool ret = proxy.AltaImportacion(import);

                if (ret)
                {
                    return Redirect("/Importacion/List");
                }
                else
                {
                    ViewBag.Mensaje = "Ha ocurrido un error al ingresar la importacion";

                    return View(importacion);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Importacion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Importacion/Edit/5
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

        // GET: Importacion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Importacion/Delete/5
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

        // GET: Importacion/List
        [HttpGet]
        public ActionResult List()
        {
            if (Session["rol"] == null)
                return Redirect("/Home/Index");


            return View(FachadaPortLog.TraerTodasLasImportaciones());
        }
    }
}
