using Microsoft.EntityFrameworkCore;

namespace Lab14.Models
{
    public class SchoolContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = LAB1504-19\\SQLEXPRESS;Initial Catalog = SchoolDB;User Id = user01;Password = 12345678; trustservercertificate=True");
        }
    }
}
