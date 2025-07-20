namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imgDbadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ImagePath");
        }
    }
}
