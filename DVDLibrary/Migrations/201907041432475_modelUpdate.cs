namespace DVDLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DVDs", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.DVDs", "Director", c => c.String(nullable: false));
            AlterColumn("dbo.DVDs", "Rating", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DVDs", "Rating", c => c.String());
            AlterColumn("dbo.DVDs", "Director", c => c.String());
            AlterColumn("dbo.DVDs", "Title", c => c.String());
        }
    }
}
