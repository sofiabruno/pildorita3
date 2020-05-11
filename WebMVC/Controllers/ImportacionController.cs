﻿using System;
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
        public ActionResult Create(string codProd)
        {
            if (Session["rol"] == null)
                return Redirect("/Home/Index");

            if (Session["rol"].ToString() == "admin")
                return Redirect("/Home/Index");

            //info del producto
            Producto prod = FachadaPortLog.BuscarProductoPorCod(codProd);

            ViewBag.codigo = prod.Codigo;
            ViewBag.nombre = prod.Nombre;
            ViewBag.peso = prod.Peso;
            ViewBag.rut = prod.Cliente.Rut;
       
            
            return View();
        }

        // POST: Importacion/Create
        [HttpPost]
        public ActionResult Create(ViewModelImportacion importacion)
        {

            //Verificar la fecha de salida
            if (importacion.SalidaPrevista > importacion.FechaIngreso)
            {
                //convierto mis datos del cliente en DTOimportacion
                DTOImportacion import = new DTOImportacion()
                {
                    FechaIngreso = importacion.FechaIngreso,
                    SalidaPrevista = importacion.SalidaPrevista,
                    CodigoProd = importacion.Codigo,
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
                        proxy.Close();
                        return Redirect("/Importacion/List");
                    }
                    else
                    {
                        ViewBag.Mensaje = "Ha ocurrido un error al ingresar la importacion";
                        proxy.Close();
                        return View(importacion);
                    }
                }
                catch
                {
                    proxy.Close();
                    return View();
                }
            }
            else
            {
                Producto prod = FachadaPortLog.BuscarProductoPorCod(importacion.Codigo);

                ViewBag.codigo = prod.Codigo;
                ViewBag.nombre = prod.Nombre;
                ViewBag.peso = prod.Peso;
                ViewBag.rut = prod.Cliente.Rut;


                ViewBag.MensajeDeErrorEnFechas = "La fecha de salida no puede ser anterior a la de ingreso";
                return View(importacion);
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
