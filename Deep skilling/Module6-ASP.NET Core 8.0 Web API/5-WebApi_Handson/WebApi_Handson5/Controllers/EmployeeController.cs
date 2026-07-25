using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi_Handson5.Models;

namespace WebApi_Handson5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private static readonly List<Employee> Employees =
            new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "Thanuja",
                    Salary = 50000,
                    Department = "Software Development"
                },
                new Employee
                {
                    Id = 2,
                    Name = "Veda",
                    Salary = 55000,
                    Department = "Data Science"
                },
                new Employee
                {
                    Id = 3,
                    Name = "Rahul",
                    Salary = 45000,
                    Department = "Testing"
                }
            };

        [HttpGet]
        [ProducesResponseType(
            typeof(List<Employee>),
            StatusCodes.Status200OK)]
        [ProducesResponseType(
            StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(
            StatusCodes.Status403Forbidden)]
        public ActionResult<List<Employee>> GetEmployees()
        {
            return Ok(Employees);
        }
    }
}