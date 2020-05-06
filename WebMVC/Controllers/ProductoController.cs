using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//agregue
using Dominio;
using Repositorios;
using WebMVC.ViewModels;
using WebMVC.WFCProducto;

namespace WebMVC.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            return View();
        }

        //GET: Producto/Details/5
        //public ActionResult Details(int id)
        //{
        //    ViewModelProducto pro = new ViewModelProducto();

        //    ServicioProductosClient proxy = new ServicioProductosClient();

        //    DTOProducto buscado = proxy.BuscarPorId(id);

        //    if (buscado != null)
        //    {
        //        pro = new ViewModelProducto()
        //        {
        //            Codigo = buscado.Codigo,
        //            Nombre = buscado.Nombre
        //        };
        //    }

        //    return View(pro);
        //}

        // GET: Producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
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

        // GET: Producto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Producto/Edit/5
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

        // GET: Producto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Producto/Delete/5
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


        // GET: Producto/List
        [HttpGet]
        public ActionResult List()
        {
            if (Session["rol"] == null)
                return Redirect("/Home/Index");

            ServicioProductosClient proxy = new ServicioProductosClient();

            
            //List<Producto> lista = proxy.TraerTodo();

            proxy.Close(); 
            //en la clase dijo q era importante cerrarlo

            return View(FachadaPortLog.TraerTodosLosProductos());
        }

    }
}
