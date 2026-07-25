using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi_Handson3.Filters;
using WebApi_Handson3.Models;

namespace WebApi_Handson3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [CustomAuthFilter]
    [CustomExceptionFilter]
    public class EmployeeController : ControllerBase
    {
        private static readonly List<Employee> Employees =
            GetStandardEmployeeList();

        private static List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "Thanuja",
                    Salary = 50000,
                    Permanent = true,

                    Department = new Department
                    {
                        Id = 1,
                        Name = "Software Development"
                    },

                    Skills = new List<Skill>
                    {
                        new Skill
                        {
                            Id = 1,
                            Name = "C#"
                        },
                        new Skill
                        {
                            Id = 2,
                            Name = "ASP.NET Core"
                        }
                    },

                    DateOfBirth = new DateTime(2003, 5, 10)
                },

                new Employee
                {
                    Id = 2,
                    Name = "Veda",
                    Salary = 55000,
                    Permanent = true,

                    Department = new Department
                    {
                        Id = 2,
                        Name = "Data Science"
                    },

                    Skills = new List<Skill>
                    {
                        new Skill
                        {
                            Id = 3,
                            Name = "Python"
                        },
                        new Skill
                        {
                            Id = 4,
                            Name = "Machine Learning"
                        }
                    },

                    DateOfBirth = new DateTime(2002, 8, 20)
                }
            };
        }

        [HttpGet]
        [ProducesResponseType(
            typeof(List<Employee>),
            StatusCodes.Status200OK)]
        [ProducesResponseType(
            StatusCodes.Status400BadRequest)]
        public ActionResult<List<Employee>> GetStandard()
        {
            return Ok(Employees);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(
            typeof(Employee),
            StatusCodes.Status200OK)]
        [ProducesResponseType(
            StatusCodes.Status404NotFound)]
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
        [AllowAnonymous]
        [ProducesResponseType(
            typeof(Employee),
            StatusCodes.Status201Created)]
        [ProducesResponseType(
            StatusCodes.Status400BadRequest)]
        public ActionResult<Employee> AddEmployee(
            [FromBody] Employee employee)
        {
            Employees.Add(employee);

            return CreatedAtAction(
                nameof(GetEmployeeById),
                new { id = employee.Id },
                employee
            );
        }

        [HttpPut("{id}")]
        [ProducesResponseType(
            typeof(Employee),
            StatusCodes.Status200OK)]
        [ProducesResponseType(
            StatusCodes.Status404NotFound)]
        public ActionResult<Employee> UpdateEmployee(
            int id,
            [FromBody] Employee updatedEmployee)
        {
            Employee? employee =
                Employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return NotFound("Employee not found");
            }

            employee.Name = updatedEmployee.Name;
            employee.Salary = updatedEmployee.Salary;
            employee.Permanent = updatedEmployee.Permanent;
            employee.Department = updatedEmployee.Department;
            employee.Skills = updatedEmployee.Skills;
            employee.DateOfBirth = updatedEmployee.DateOfBirth;

            return Ok(employee);
        }

        [HttpGet("exception")]
        [ProducesResponseType(
            StatusCodes.Status500InternalServerError)]
        public IActionResult ThrowException()
        {
            throw new Exception(
                "Custom exception occurred in Employee controller"
            );
        }
    }
}