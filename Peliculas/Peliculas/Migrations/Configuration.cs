namespace Peliculas.Migrations
{
    using Peliculas.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Peliculas.Models.PeliculasDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Peliculas.Models.PeliculasDataContext";
        }

        protected override void Seed(Peliculas.Models.PeliculasDataContext context)
        {
            for (int index = 0; index < 100; index++)
            {
                context.Peliculas.AddOrUpdate(i => i.id,
                   new Pelicula
                   {
                       Nombre = "Star Wars " + index.ToString(),
                       Fecha = DateTime.Parse("2000-1-11"),                                              
                       Descripcion = "aventura en el espacio..."
                   });

            }
           
        }
    }
}
