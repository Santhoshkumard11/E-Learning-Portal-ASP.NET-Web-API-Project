namespace HandsOnWebAPI.Migrations
{
    using HandsOnWebAPI.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HandsOnWebAPI.Models.HandsOnWebAPIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HandsOnWebAPI.Models.HandsOnWebAPIContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Employees.AddOrUpdate(
            new Employee { Id = 1, FirstName = "Santhosh", LastName = "Kumar", DepartmentId = 101, Salary = 30000 },
            new Employee { Id = 2, FirstName = "Sindhuja", LastName = "Kumar", DepartmentId = 100, Salary = 20000 }
            );
        }
    }
}
