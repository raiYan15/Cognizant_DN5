namespace StudentManagement.CodeFirst.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // One-to-One navigation
        public Address? Address { get; set; }

        // Many-to-One: a Student belongs to one Department
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;

        // Many-to-Many navigation via the Enrollment join entity
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
