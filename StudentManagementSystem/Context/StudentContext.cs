using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Context
{
    public class StudentContext : DbContext
    { 
        public StudentContext(DbContextOptions<StudentContext> options):base(options)
        {

        }

        public DbSet<StudentModel> Students { get; set; }
        public DbSet<CourseModel> Courses { get; set; }
        public DbSet<StudentCourseModel> StudentCourses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourseModel>()
                 .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<StudentCourseModel>()
               .HasOne(sc => sc.Students)
               .WithMany(s => s.StudentCourses)
               .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentCourseModel>()
               .HasOne(sc => sc.Courses)
               .WithMany(c => c.StudentCourses)
               .HasForeignKey(sc => sc.CourseId);

        }
    }
}
