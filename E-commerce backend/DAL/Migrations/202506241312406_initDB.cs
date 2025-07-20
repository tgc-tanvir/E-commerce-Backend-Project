namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CusId = c.Int(nullable: false),
                        PId = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CusId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.PId, cascadeDelete: true)
                .Index(t => t.CusId)
                .Index(t => t.PId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                        Address = c.String(nullable: false, maxLength: 30),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Pname = c.String(nullable: false, maxLength: 20),
                        Description = c.String(nullable: false, maxLength: 30),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false),
                        StatusId = c.Int(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CusId = c.Int(nullable: false),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CusId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.StatusId)
                .Index(t => t.CusId)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Email = c.String(nullable: false, maxLength: 30),
                        Address = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 20),
                        Type = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                        UserType = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OId = c.Int(nullable: false),
                        PId = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.PId, cascadeDelete: true)
                .Index(t => t.OId)
                .Index(t => t.PId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "PId", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "OId", "dbo.Orders");
            DropForeignKey("dbo.Carts", "PId", "dbo.Products");
            DropForeignKey("dbo.Orders", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Orders", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Orders", "CusId", "dbo.Customers");
            DropForeignKey("dbo.Carts", "CusId", "dbo.Customers");
            DropIndex("dbo.OrderDetails", new[] { "PId" });
            DropIndex("dbo.OrderDetails", new[] { "OId" });
            DropIndex("dbo.Orders", new[] { "Product_Id" });
            DropIndex("dbo.Orders", new[] { "CusId" });
            DropIndex("dbo.Orders", new[] { "StatusId" });
            DropIndex("dbo.Carts", new[] { "PId" });
            DropIndex("dbo.Carts", new[] { "CusId" });
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Logins");
            DropTable("dbo.Employees");
            DropTable("dbo.Status");
            DropTable("dbo.Orders");
            DropTable("dbo.Products");
            DropTable("dbo.Customers");
            DropTable("dbo.Carts");
        }
    }
}
