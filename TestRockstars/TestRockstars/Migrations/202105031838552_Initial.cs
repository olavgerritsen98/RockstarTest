namespace TestRockstars.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Year = c.Int(nullable: false),
                        Artist = c.String(nullable: false, maxLength: 255),
                        Shortname = c.String(nullable: false, maxLength: 255),
                        Bpm = c.Int(),
                        Duration = c.Int(nullable: false),
                        Genre = c.String(nullable: false, maxLength: 255),
                        SpotifyId = c.String(maxLength: 255),
                        Album = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Songs");
            DropTable("dbo.Artists");
        }
    }
}
