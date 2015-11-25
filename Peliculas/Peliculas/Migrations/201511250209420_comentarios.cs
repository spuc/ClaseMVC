namespace Peliculas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comentarios : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comentarios",
                c => new
                    {
                        ComentarioID = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        UserName = c.String(),
                        Subject = c.String(nullable: false, maxLength: 250),
                        Body = c.String(),
                        pelicula_id = c.Int(),
                    })
                .PrimaryKey(t => t.ComentarioID)
                .ForeignKey("dbo.Peliculas", t => t.pelicula_id)
                .Index(t => t.pelicula_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comentarios", "pelicula_id", "dbo.Peliculas");
            DropIndex("dbo.Comentarios", new[] { "pelicula_id" });
            DropTable("dbo.Comentarios");
        }
    }
}
