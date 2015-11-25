using Peliculas.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Peliculas.Controllers
{
    public class ComentarioController : Controller
    {
       private PeliculasDataContext db = new PeliculasDataContext();

        //
        // GET: A Partial View for displaying in the Photo Details view
       [ChildActionOnly] //This attribute means the action cannot be accessed from the browser's address bar
        public PartialViewResult _ComentariosForMovie(int id = 0)
        {
            //The Comentarios for a particular photo have been requested. Get those Comentarios.
            var Comentarios = from c in db.Comentarios
                           where c.MovieId == id
                           select c;
            //Save the MovieId in the ViewBag because we'll need it in the view
            ViewBag.MovieId = id;
            return PartialView(Comentarios.ToList());
        }

        //
        //POST: This action creates the Comentario when the AJAX Comentario create tool is used
        [HttpPost]
        public PartialViewResult _ComentariosForMovie(Comentario Comentario, int id = 0)
        {

            //Save the new Comentario
            Comentario.MovieId = id;
            db.Comentarios.Add(Comentario);
            db.SaveChanges();

            //Get the updated list of Comentarios
            var Comentarios = from c in db.Comentarios
                           where c.MovieId == id
                           select c;
            //Save the MovieId in the ViewBag because we'll need it in the view
            ViewBag.MovieId = id;
            //Return the view with the new list of Comentarios
            return PartialView("_ComentariosForMovie", Comentarios.ToList());
        }

        //
        // GET: /Comentario/_Create. A Partial View for displaying the create Comentario tool as a AJAX partial page update
        [Authorize]
        public PartialViewResult _Create(int id = 0)
        {
            //Create the new Comentario
            Comentario newComentario = new Comentario();
            newComentario.MovieId = id;
            newComentario.UserName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(User.Identity.Name);

            ViewBag.MovieId = id;
            return PartialView("_CreateAComentario");
        }



        //
        // GET: /Comentario/Delete/5
        [Authorize]
        public ActionResult Delete(int id = 0)
        {
            Comentario Comentario = db.Comentarios.Find(id);
            Pelicula pelicula = db.Peliculas.Find(Comentario.MovieId);
            Comentario.pelicula = pelicula;


            ViewBag.MovieId = Comentario.MovieId;
            if (Comentario == null)
            {
                return HttpNotFound();
            }
            return View(Comentario);
        }

        //
        // POST: /Comentario/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Comentario Comentario = db.Comentarios.Find(id);
           
            // var query = from c in db.Comentarios
            //join p in db.peliculas on c.MovieId equals p.id
            //select new { c.MovieId, p.Name, c.Subject, c.Body };

            // var query1 = from c in db.Comentarios
            //             join p in db.peliculas on c.MovieId equals p.id
            //              select new Comentario { Subject = c.Subject, Body = c.Body, ComentarioID = c.ComentarioID, MovieId = c.MovieId, pelicula = new Pelicula() { Name = p.Name } };

           
            db.Comentarios.Remove(Comentario);
            db.SaveChanges();
            return RedirectToAction("details", "pelicula", new { id = Comentario.MovieId });
           
        }

    }

}

