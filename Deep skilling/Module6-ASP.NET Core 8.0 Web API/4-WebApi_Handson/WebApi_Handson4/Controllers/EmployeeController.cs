using Microsoft.AspNetCore.Mvc;
using WebApi_Handson4.Models;

namespace WebApi_Handson4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
                    Permanent = true,
                    Department = "Software Development",
                    DateOfBirth = new DateTime(2003, 5, 10)
                },

                new Employee
                {
                    Id = 2,
                    Name = "Veda",
                    Salary = 55000,
                    Permanent = true,
                    Department = "Data Science",
                    DateOfBirth = new DateTime(2002, 8, 20)
                },

                new Employee
                {
                    Id = 3,
                    Name = "Rahul",
                    Salary = 45000,
                    Permanent = false,
                    Department = "Testing",
                    DateOfBirth = new DateTime(2001, 12, 15)
                }
            };

        // READ all employees
        [HttpGet]
        [ProducesResponseType(
            typeof(List<Employee>),
            StatusCodes.Status200OK)]
        public ActionResult<List<Employee>> GetAllEmployees()
        {
            return Ok(Employees);
        }

        // READ one employee
        [HttpGet("{id}")]
        [ProducesResponseType(
            typeof(Employee),
            StatusCodes.Status200OK)]
        [ProducesResponseType(
            StatusCodes.Status400BadRequest)]
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid employee id");
            }

            Employee? employee =
                Employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return BadRequest("Invalid employee id");
            }

            return Ok(employee);
        }

        // CREATE employee
        [HttpPost]
        [ProducesResponseType(
            typeof(Employee),
            StatusCodes.Status201Created)]
        [ProducesResponseType(
            StatusCodes.Status400BadRequest)]
        public ActionResult<Employee> AddEmployee(
            [FromBody] Employee employee)
        {
            if (employee.Id <= 0)
            {
                return BadRequest("Invalid employee id");
            }

            bool employeeExists =
                Employees.Any(e => e.Id == employee.Id);

            if (employeeExists)
            {
                return BadRequest("Employee id already exists");
            }

            Employees.Add(employee);

            return CreatedAtAction(
                nameof(GetEmployeeById),
                new { id = employee.Id },
                employee
            );
        }

        // UPDATE employee
        [HttpPut("{id}")]
        [ProducesResponseType(
            typeof(Employee),
            StatusCodes.Status200OK)]
        [ProducesResponseType(
            StatusCodes.Status400BadRequest)]
        public ActionResult<Employee> UpdateEmployee(
            int id,
            [FromBody] Employee updatedEmployee)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid employee id");
            }

            Employee? employee =
                Employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return BadRequest("Invalid employee id");
            }

            employee.Name = updatedEmployee.Name;
            employee.Salary = updatedEmployee.Salary;
            employee.Permanent = updatedEmployee.Permanent;
            employee.Department = updatedEmployee.Department;
            employee.DateOfBirth = updatedEmployee.DateOfBirth;

            return Ok(employee);
        }

        // DELETE employee
        [HttpDelete("{id}")]
        [ProducesResponseType(
            StatusCodes.Status204NoContent)]
        [ProducesResponseType(
            StatusCodes.Status400BadRequest)]
        public IActionResult DeleteEmployee(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid employee id");
            }

            Employee? employee =
                Employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return BadRequest("Invalid employee id");
            }

            Employees.Remove(employee);

            return NoContent();
        }
    }
}