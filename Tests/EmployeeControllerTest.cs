using HandsOnWebAPI.Controllers;
using HandsOnWebAPI.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace HandsOnWebAPI.Tests.Controllers
{
    [TestFixture]
    public class EmployeeControllerTest
    {
        [Test]
        public void BasicResultTesting()
        {
            EmployeesController controller = new EmployeesController();

            List<Employee> result = controller.GetEmployees();

            Assert.IsNotNull(result);
            Assert.AreEqual("Sindhuja", result.ToArray()[0].FirstName);
            Assert.AreEqual("Steve", result.ToArray()[3].FirstName);
        }
    }
}