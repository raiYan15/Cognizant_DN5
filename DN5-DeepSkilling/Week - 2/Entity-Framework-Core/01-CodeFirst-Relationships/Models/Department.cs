namespace StudentManagement.CodeFirst.Models
{
    // One-to-Many with Student: one Department has many Students.
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
