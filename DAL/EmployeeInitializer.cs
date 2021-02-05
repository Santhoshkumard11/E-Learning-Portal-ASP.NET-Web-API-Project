using HandsOnWebAPI.Models;
using System.Collections.Generic;

namespace HandsOnWebAPI.DAL
{
    public class EmployeeInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<HandsOnWebAPIContext>
    {
        protected override void Seed(HandsOnWebAPIContext context)
        {
            var employeeList = new List<Employee>
            {
                new Employee {Id =1, FirstName= "Santhosh",LastName= "Kumar", DepartmentId= 101, Salary=30000},
                new Employee {Id =2, FirstName= "Sindhuja",LastName= "Kumar", DepartmentId= 100, Salary=20000}
            };

            context.Employees.AddRange(employeeList);

            var studentList = new List<Student>
            {
                new Student(){Id=1, FirstName="Jerome", LastName="Smith",Gender="Male",Address="13"},
                new Student(){Id=2, FirstName="Peter", LastName="Cruise",Gender="Male",Address="12"},
                new Student(){Id=3, FirstName="Sam", LastName="Allen",Gender="Female",Address="13"}
            };

            context.Students.AddRange(studentList);
        }
    }
}