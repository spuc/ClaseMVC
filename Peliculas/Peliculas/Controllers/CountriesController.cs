using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Peliculas.Controllers
{
    public class CountriesController : Controller
    {
        //
        // GET: /Countries/

        public ActionResult NorthAmerica(string pais)
        {
            ViewBag.Pais = pais;
            //return View();
            //return Content("Pais = " + pais);
            //return File(Server.MapPath("~/content/site.css"), "text/css");
            //return Json(new { pais = pais }, JsonRequestBehavior.AllowGet);
           // return RedirectToRoute("europa", new { Controller="home", Action="about"});

            return RedirectToAction("about", "home", new { pais=pais});
        }
        public ActionResult Europa(string pais)
        {
            ViewBag.Pais = pais;
            return View();

            //return RedirectToAction("about", "home");
        }
        public ActionResult Otros(string pais)
        {
            ViewBag.Pais = pais;
            return View();

            //return RedirectToAction("about", "home");
        }

        //
        // GET: /Countries/Details/5
        [Authorize]
        [ActionName ("detalles")]
        public ActionResult Details(int id=0)
        {
            ViewBag.id = id;
            return View();
        }

        //
        // GET: /Countries/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Countries/Create

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

        //
        // GET: /Countries/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Countries/Edit/5

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

        //
        // GET: /Countries/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Countries/Delete/5

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
