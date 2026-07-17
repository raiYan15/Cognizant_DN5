using Microsoft.AspNetCore.Mvc;
using SwaggerWebApi.Models;

namespace SwaggerWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class EmployeesController : ControllerBase
    {
        private static readonly List<Employee> Employees = new()
        {
            new Employee { Id = 1, Name = "Sadwik", Department = "Engineering", Salary = 45000 },
            new Employee { Id = 2, Name = "Kranthi", Department = "QA", Salary = 40000 }
        };

        /// <summary>
        /// Gets the list of all employees.
        /// </summary>
        /// <returns>A list of employees.</returns>
        /// <response code="200">Returns the employee list.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Employee>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Employee>> GetAll() => Ok(Employees);

        /// <summary>
        /// Gets a single employee by id.
        /// </summary>
        /// <param name="id">Employee id.</param>
        /// <response code="200">Employee found.</response>
        /// <response code="404">Employee not found.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Employee> GetById(int id)
        {
            var employee = Employees.FirstOrDefault(e => e.Id == id);
            return employee is null ? NotFound() : Ok(employee);
        }

        /// <summary>
        /// Creates a new employee record.
        /// </summary>
        /// <param name="employee">Employee payload.</param>
        /// <response code="201">Employee created.</response>
        [HttpPost]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status201Created)]
        public ActionResult<Employee> Create([FromBody] Employee employee)
        {
            employee.Id = Employees.Max(e => e.Id) + 1;
            Employees.Add(employee);
            return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);
        }
    }
}
