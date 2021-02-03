using HandsOnWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HandsOnWebAPI.DAL
{
    public class EmployeeInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<HandsOnWebAPIContext>
    {


        protected override void Seed(HandsOnWebAPIContext context)
        {

            var employee = new List<Employee>
            { 
                new Employee {Id =1, FirstName= "Santhosh",LastName= "Kumar", DepartmentId= 101, Salary=30000},
                new Employee {Id =2, FirstName= "Sindhuja",LastName= "Kumar", DepartmentId= 100, Salary=20000}

            };

            context.Employees.AddRange(employee);




        }

    }
}