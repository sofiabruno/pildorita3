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
            return View();
        }

        // POST: Importacion/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
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
    }
}
