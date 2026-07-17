namespace StudentManagement.CodeFirst.Models
{
    // Explicit join entity for the Student <-> Course many-to-many relationship.
    // Used (instead of a plain skip-navigation) because it carries extra data: Grade.
    public class Enrollment
    {
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;

        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;

        public string Grade { get; set; } = string.Empty;
        public DateTime EnrolledOnUtc { get; set; } = DateTime.UtcNow;
    }
}
