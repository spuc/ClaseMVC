using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Peliculas.Models;
    
namespace Peliculas.Controllers
{
    public class PeliculaController : Controller
    {
        private PeliculasDataContext db = new PeliculasDataContext();

        //
        // GET: /Pelicula/

        public ActionResult Index()
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
        public ActionResult Edit(Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
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

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}