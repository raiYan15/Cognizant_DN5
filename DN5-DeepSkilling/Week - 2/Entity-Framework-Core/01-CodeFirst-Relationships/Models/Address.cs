namespace StudentManagement.CodeFirst.Models
{
    // One-to-One with Student: each Student has exactly one Address.
    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string PinCode { get; set; } = string.Empty;

        // Foreign key back to Student (Address is the dependent side)
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;
    }
}
