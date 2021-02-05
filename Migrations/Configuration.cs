namespace HandsOnWebAPI.Migrations
{
    using HandsOnWebAPI.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HandsOnWebAPIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HandsOnWebAPIContext context)
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

            context.Departments.AddOrUpdate(
                new Department { Id = 100, Name = "HR" },
                new Department { Id = 101, Name = "Technical" }

                );

            context.Employees.AddOrUpdate(
            new Employee { Id = 1, FirstName = "Santhosh", LastName = "Kumar", DepartmentId = 101, Salary = 30000 },
            new Employee { Id = 2, FirstName = "Sindhuja", LastName = "G", DepartmentId = 100, Salary = 20000 },
            new Employee { Id = 3, FirstName = "Sankar", LastName = "Narayanan", DepartmentId = 101, Salary = 20000 },
            new Employee { Id = 4, FirstName = "Steve", LastName = "Rogers", DepartmentId = 100, Salary = 20000 }
            );


            context.Students.AddOrUpdate(
                new Student() { Id = 1, FirstName = "Jerome", LastName = "Smith", Gender = "Male", Address = "13" },
                new Student() { Id = 2, FirstName = "Peter", LastName = "Cruise", Gender = "Male", Address = "12" },
                new Student() { Id = 3, FirstName = "Sam", LastName = "Allen", Gender = "Female", Address = "13" }
                );
        }
    }
}