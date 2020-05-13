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
            if (Session["rol"] == null)
                return Redirect("/Home/Index");

            if (Session["rol"].ToString() != "admin")
                return Redirect("/Home/Index");

            Cliente cliente = FachadaPortLog.BuscarClientePorId(id);

            return View(cliente);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            if (Session["rol"] == null)
                return Redirect("/Home/Index");

            if (Session["rol"].ToString() != "admin")
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
                }

                return Redirect("/Cliente/List");
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
            if (Session["rol"] == null)
                return Redirect("/Home/Index");

            if (Session["rol"].ToString() != "admin")
                return Redirect("/Home/Index");

            Cliente cliente = FachadaPortLog.BuscarClientePorId(id);

            return View(cliente);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Cliente cliente)
        {
            try
            {
                FachadaPortLog.ModificacionCliente(cliente.Id, cliente.Nombre, cliente.Rut, cliente.Antiguedad);

                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["rol"] == null)
                return Redirect("/Home/Index");

            if (Session["rol"].ToString() != "admin")
                return Redirect("/Home/Index");

            Cliente cliente = FachadaPortLog.BuscarClientePorId(id);

            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Cliente cliente)
        {
            try
            {
                FachadaPortLog.BajaCliente(id);

                return RedirectToAction("List");
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

            if (Session["rol"].ToString() != "admin")
                return Redirect("/Home/Index");

            return View(FachadaPortLog.TraerTodosLosClientes());
        }


        //Ganancia estimada

        // GET: Cliente/Ganancia
        public ActionResult Ganancia(long rut)
        {
            if (Session["rol"] == null)
                return Redirect("/Home/Index");

            if (Session["rol"].ToString() != "admin")
                return Redirect("/Home/Index");

            Cliente cliente = FachadaPortLog.BuscarClientePorRut(rut);

            

            double ganancia = FachadaPortLog.EstimarGanancia(cliente);

            ViewBag.Ganancia = ganancia;

            List<Importacion> lista = FachadaPortLog.TraerLasImpDeUnCliente(rut);

            List<Importacion> listaQueGeneranGanancia = new List<Importacion>();
            DateTime fchHoy = DateTime.Today;

            ViewBag.lista = listaQueGeneranGanancia;

            foreach (Importacion i in lista)
            {
                if (i.FechaIngreso <= fchHoy && i.SalidaPrevista >= fchHoy)
                {
                    listaQueGeneranGanancia.Add(i);
                }
            }
                                          

            return View(cliente);
        }

      




    }
}
