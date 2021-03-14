using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Data
{
    //tinfo200:[2021-02-22-hufsar06-dykstra1] - This class creates a school context - it creates a requirement for a student, course, and enrollment, and names each table 
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        //tinfo200:[2021-02-22-hufsar06-dykstra1] - The Dbset properties create a requirement for a student, course, and enrollment
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }

        //tinfo200:[2021-02-22-hufsar06-dykstra1] - This method names each table 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");
        }
    }
}
