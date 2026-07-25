using Microsoft.AspNetCore.Mvc;
using WebApi_Handson2.Models;

namespace WebApi_Handson2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private static readonly List<Employee> Employees =
        [
            new Employee
            {
                Id = 1,
                Name = "Thanuja",
                Department = "Software Development",
                Salary = 50000
            },
            new Employee
            {
                Id = 2,
                Name = "Veda",
                Department = "Data Science",
                Salary = 55000
            },
            new Employee
            {
                Id = 3,
                Name = "Rahul",
                Department = "Testing",
                Salary = 45000
            }
        ];

        [HttpGet]
        public ActionResult<List<Employee>> GetAllEmployees()
        {
            return Ok(Employees);
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            Employee? employee =
                Employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return NotFound("Employee not found");
            }

            return Ok(employee);
        }

        [HttpPost]
        public ActionResult<Employee> AddEmployee(Employee employee)
        {
            Employees.Add(employee);

            return CreatedAtAction(
                nameof(GetEmployeeById),
                new { id = employee.Id },
                employee
            );
        }

        [HttpPut("{id}")]
        public ActionResult<Employee> UpdateEmployee(
            int id,
            Employee updatedEmployee)
        {
            Employee? employee =
                Employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return NotFound("Employee not found");
            }

            employee.Name = updatedEmployee.Name;
            employee.Department = updatedEmployee.Department;
            employee.Salary = updatedEmployee.Salary;

            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            Employee? employee =
                Employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return NotFound("Employee not found");
            }

            Employees.Remove(employee);

            return NoContent();
        }
    }
}