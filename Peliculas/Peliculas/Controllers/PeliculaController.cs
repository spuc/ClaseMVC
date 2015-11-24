using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Peliculas.Models;
using System.Web;
using System.IO;
using PagedList;
    
namespace Peliculas.Controllers
{
    public class PeliculaController : Controller
    {
        private PeliculasDataContext db = new PeliculasDataContext();
        int filas = 5;
        //
        // GET: /Pelicula/

        public ActionResult Index(int pagina=1)
        {
            var lista = db.Peliculas.ToList().ToPagedList(pagina, filas);
            return View(lista);
        }

        public ActionResult IndexAjax(int pagina = 1)
        {
            var lista = db.Peliculas.ToList().ToPagedList(pagina, filas);
            return View(lista);
        }

        public ActionResult IndexImagenes(int pagina = 1)
        {
            var lista = db.Peliculas.ToList().ToPagedList(pagina, 18);
            return View(lista);
        }

        public ActionResult Todas()
        {
            return View(db.Peliculas.ToList());
        }

        private List<Pelicula> CargarLista()
        {
            List<Pelicula> modelo = new List<Pelicula>();
            modelo.Add(new Pelicula { Nombre = "Iron Man", Descripcion = "la vida Iron Man" });
            modelo.Add(new Pelicula { Nombre = "Iron Man 2", Descripcion = "la continuacion" });
            modelo.Add(new Pelicula { Nombre = "Spider man", Descripcion = "el hombre araña" });
            return modelo;
        }


        //
        // GET: /Pelicula/Details/5

        public ActionResult Details(int id = 0)
        {
            Pelicula pelicula = db.Peliculas.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        //
        // GET: /Pelicula/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Pelicula/Create

        [HttpPost]
        public ActionResult Create(Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                db.Peliculas.Add(pelicula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pelicula);
        }

        //
        // GET: /Pelicula/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Pelicula pelicula = db.Peliculas.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        //
        // POST: /Pelicula/Edit/5

        [HttpPost]
        public ActionResult Edit(Pelicula pelicula, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(
                        Server.MapPath("~/Content/imagenes"),
                        fileName);

                    file.SaveAs(path);

                    path = "/content/imagenes/" + fileName;
                    pelicula.ruta = path;
                }
                db.Entry(pelicula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pelicula);
        }

        //
        // GET: /Pelicula/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Pelicula pelicula = db.Peliculas.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        //
        // POST: /Pelicula/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Pelicula pelicula = db.Peliculas.Find(id);
            db.Peliculas.Remove(pelicula);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Calificar(int id, int rate)
        {
            int userId = 142;
            bool success = false;
            string error = "";
            try
            {
                success = CalificarPelicula(userId, id, rate);
            }
            catch (System.Exception ex)
            {
                // get last error
                if (ex.InnerException != null)
                    while (ex.InnerException != null)
                        ex = ex.InnerException;
                error = ex.Message;
            }

            return Json(new { error = error, success = success, pid = id },
                JsonRequestBehavior.AllowGet);
        }

        public bool CalificarPelicula(int userId, int id, int calificacion)
        {
            Pelicula pelicula = db.Peliculas.Find(id);
            if (pelicula == null)
            {
                return false;
            }
            pelicula.Rate = calificacion;
            db.Entry(pelicula).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}