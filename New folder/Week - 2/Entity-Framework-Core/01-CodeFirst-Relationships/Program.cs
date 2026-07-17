using Microsoft.EntityFrameworkCore;
using StudentManagement.CodeFirst.Data;
using StudentManagement.CodeFirst.Models;

var options = new DbContextOptionsBuilder<SchoolContext>()
    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=StudentManagementDb;Trusted_Connection=True;")
    .Options;

using var context = new SchoolContext(options);

// Applies any pending migrations and creates the DB if it doesn't exist.
context.Database.Migrate();

// ---- Create a Student with a one-to-one Address ----
var student = new Student
{
    Name = "Sadwik",
    Email = "sadwik@example.com",
    DepartmentId = 1,
    Address = new Address { City = "Guntur", State = "Andhra Pradesh", PinCode = "522001" }
};
context.Students.Add(student);

// ---- Create Courses and enroll the student (many-to-many with payload) ----
var course = new Course { Title = "Data Structures", Credits = 4 };
context.Courses.Add(course);

context.SaveChanges(); // Ids get generated here

context.Enrollments.Add(new Enrollment
{
    StudentId = student.Id,
    CourseId = course.Id,
    Grade = "A"
});
context.SaveChanges();

// ---- Query back with relationships loaded ----
var loadedStudent = context.Students
    .Include(s => s.Address)
    .Include(s => s.Department)
    .Include(s => s.Enrollments)
        .ThenInclude(e => e.Course)
    .First(s => s.Id == student.Id);

Console.WriteLine($"{loadedStudent.Name} | Dept: {loadedStudent.Department.Name} | City: {loadedStudent.Address?.City}");
foreach (var enrollment in loadedStudent.Enrollments)
{
    Console.WriteLine($" - {enrollment.Course.Title}: {enrollment.Grade}");
}
