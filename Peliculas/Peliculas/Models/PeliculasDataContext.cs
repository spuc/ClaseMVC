using System.Data.Entity;

namespace Peliculas.Models
{
    public class PeliculasDataContext : DbContext
    {
        public PeliculasDataContext()
            : base("PeliculasConnection")
        {
        }
        public DbSet<Pelicula> Peliculas { get; set; }

    }
}