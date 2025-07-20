namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Models.ECommerceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.Models.ECommerceContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            /*
            for(int i=1; i <= 5; i++)
            {
                context.Customers.AddOrUpdate(new Models.Customer
                {
                    Id = i,
                    Name = Guid.NewGuid().ToString().Substring(0, 10),
                    Email= Guid.NewGuid().ToString().Substring(0, 15),
                    Password= Guid.NewGuid().ToString().Substring(0, 10),
                    Address= Guid.NewGuid().ToString().Substring(0, 15),
                    CreatedAt= DateTime.Now,
                });
            }
            Random random = new Random();
            for (int i=1; i <= 5; i++)
            {
                context.Products.AddOrUpdate(new Models.Product
                {
                    Id= i,
                    Pname= Guid.NewGuid().ToString().Substring(0, 10),
                    Description= Guid.NewGuid().ToString().Substring(0, 15),
                    Price= random.Next(100,5000),
                    Qty= random.Next(1,50),
                    CreatedAt=DateTime.Now,
                });
            } 
            for (int i = 1; i <= 5; i++)
            {
                context.Orders.AddOrUpdate(new Models.Order
                {
                    Id = i,
                    Time = DateTime.Now,
                    StatusId= random.Next(1,3),
                    Total= random.Next(1,5),
                    CusId=random.Next(1,5),
                });
            }
            for (int i = 1; i <= 5; i++)
            {
                context.OrderDetails.AddOrUpdate(new Models.OrderDetail
                {
                    Id = i,
                    OId= random.Next(1,5),
                    PId= random.Next(1,5),
                    Qty = random.Next(1, 50),
                    Price = random.Next(500,5000),
                });
            }
            for (int i = 1; i <= 5; i++)
            {
                context.Employees.AddOrUpdate(new Models.Employee
                {
                    Id = i,
                    Name = Guid.NewGuid().ToString().Substring(0, 10),
                    Email = Guid.NewGuid().ToString().Substring(0, 15),
                    Address = Guid.NewGuid().ToString().Substring(0, 15),
                    Password = Guid.NewGuid().ToString().Substring(0, 10),
                    Type = "General",
                    CreatedAt = DateTime.Now,
                    CreatedBy= 1,
                    UpdatedAt= null,
                    UpdatedBy= null,
                });
            } 
            for (int i = 1; i <= 3; i++)
            {
                context.Statuses.AddOrUpdate(new Models.Status
                {
                    Id = i,
                    Name = "Processing",
                });
            } 
            for (int i = 1; i <= 5; i++)
            {
                context.Carts.AddOrUpdate(new Models.Cart
                {
                    Id = i,
                    CusId= random.Next(1,5),
                    PId= random.Next(1,5),
                    Qty = random.Next(1, 6),
                    CreatedAt = DateTime.MaxValue,
                });
            } */
        }
    }
}
