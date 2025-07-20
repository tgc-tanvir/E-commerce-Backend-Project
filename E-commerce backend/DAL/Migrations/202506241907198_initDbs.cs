namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDbs : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Pname", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Description", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Products", "Pname", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
