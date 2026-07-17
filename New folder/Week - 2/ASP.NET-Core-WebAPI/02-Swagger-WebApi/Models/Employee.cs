namespace SwaggerWebApi.Models
{
    /// <summary>
    /// Represents an employee record.
    /// </summary>
    public class Employee
    {
        /// <summary>Unique identifier of the employee.</summary>
        public int Id { get; set; }

        /// <summary>Full name of the employee.</summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>Department the employee belongs to.</summary>
        public string Department { get; set; } = string.Empty;

        /// <summary>Monthly salary in INR.</summary>
        public decimal Salary { get; set; }
    }
}
