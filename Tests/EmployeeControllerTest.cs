using HandsOnWebAPI.Controllers;
using HandsOnWebAPI.Models;
using NUnit.Framework;
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

            IQueryable<Employee> result = controller.GetEmployees();

            Assert.IsNotNull(result);
            Assert.AreEqual("Santhosh", result.ToArray()[0]);
            Assert.AreEqual("Santhosh", result.ElementAt(1));
        }
    }
}