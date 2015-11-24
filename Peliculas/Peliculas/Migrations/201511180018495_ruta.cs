namespace Peliculas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ruta : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Peliculas", "ruta", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Peliculas", "ruta");
        }
    }
}
