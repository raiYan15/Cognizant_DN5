using Microsoft.EntityFrameworkCore;
using StudentManagement.CodeFirst.Models;

namespace StudentManagement.CodeFirst.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }

        public DbSet<Student> Students => Set<Student>();
        public DbSet<Address> Addresses => Set<Address>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Enrollment> Enrollments => Set<Enrollment>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ---- One-to-One: Student <-> Address ----
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Address)
                .WithOne(a => a.Student)
                .HasForeignKey<Address>(a => a.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            // ---- One-to-Many: Department -> Students ----
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Department)
                .WithMany(d => d.Students)
                .HasForeignKey(s => s.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // ---- Many-to-Many: Student <-> Course via Enrollment (composite key) ----
            modelBuilder.Entity<Enrollment>()
                .HasKey(e => new { e.StudentId, e.CourseId });

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId);

            // Seed a couple of departments so FK constraints are satisfiable out of the box
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Computer Science" },
                new Department { Id = 2, Name = "Electronics" }
            );
        }
    }
}
