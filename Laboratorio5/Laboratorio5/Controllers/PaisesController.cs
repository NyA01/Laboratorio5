using Laboratorio5.Handlers;
using Laboratorio5.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio5.Controllers
{
    public class PaisesController : Controller
    {
        public IActionResult Index()
        {
            PaisesHandler paisesHandler = new PaisesHandler();
            var paises = paisesHandler.ObtenerPaises();
            ViewBag.MaintTitle = "Lista de paises";
            return View(paises);    
        }



        [HttpGet]
        public ActionResult CrearPais()
        {
            return View;
        }

        [HttpPost]
        public ActionResult CrearPais(PaisModel pais)
        {
            ViewBag.ExitoAlCrear = false;
            try
            {
                if (ModelState.IsValid)
                {
                    PaisesHandler paisesHandler = new PaisesHandler();
                    ViewBag.ExitoAlCrear = paisesHandler.CrearPais(pais);
                    if (ViewBag.ExitoAlCrear)
                    {
                        ViewBag.Message = "El país" + " " + pais.Nombre + " fue creado con éxito";
                        ModelState.Clear();
                    }


                }
                return View();
            }
            catch 
            {
                ViewBag.Message = "Algo salió mal y no fue posible crear el país";
                return View();
            }
        }
    }
}