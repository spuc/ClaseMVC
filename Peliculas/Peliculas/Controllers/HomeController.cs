using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Peliculas.Controllers
{
      [Authorize]
    public class HomeController : Controller
    {
          [AllowAnonymous]
          public ActionResult Index()
          {
              ViewBag.mensaje = "Bienvenido a Peliculas Luis";

              return View();
          }

          [AllowAnonymous]
          [HttpPost]
          public ActionResult Index(string u, string c)
          {
              ViewBag.mensaje = "Bienvenido " + Request.Form["usuario"] + " pwd " + Request.Form["contrasena"];

              return View();
          }

        public ActionResult About(string pais)
        {
            ViewBag.Pais = pais;
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {

            ViewBag.Message = "Your contact page.";

            return View();
        }
          [AllowAnonymous]
        public ActionResult Error(string error)
        {

            ViewBag.Error = error;

            return View();
        }
    }
}
