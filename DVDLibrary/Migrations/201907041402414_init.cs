namespace DVDLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DVDs",
                c => new
                    {
                        DVDId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        ReleaseYear = c.Int(nullable: false),
                        Director = c.String(nullable: false, maxLength: 50),
                        Rating = c.String(nullable: false, maxLength: 5),
                        Notes = c.String(nullable: true, maxLength: 255),
                    })
                .PrimaryKey(t => t.DVDId);
        }
        
        public override void Down()
        {
            DropTable("dbo.DVDs");
        }
    }
}
