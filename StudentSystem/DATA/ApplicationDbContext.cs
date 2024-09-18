using Microsoft.EntityFrameworkCore;
using StudentSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.DATA
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; } 
        public DbSet<Course> Courses { get; set; } 
        public DbSet<Resource> Resources { get; set; } 
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-7UDBE6D;Initial Catalog=StudentSystem;Integrated Security=True;" +
                "TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<Student>()
                .Property(s => s.Name)
                .IsUnicode()
                .HasMaxLength(100);

            modelBuilder.Entity<Student>()
                .Property(s => s.PhoneNumber)
                .IsFixedLength()
                .HasMaxLength(10)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(c => c.Name)
                .IsUnicode()
                .HasMaxLength(80);

            modelBuilder.Entity<Course>()
                .Property(c => c.Description)
                .IsUnicode();

            modelBuilder.Entity<Resource>()
                .Property(r => r.Name)
                .IsUnicode()
                .HasMaxLength(50);

            modelBuilder.Entity<Resource>()
                .Property(r => r.Url)
                .IsUnicode(false);

            modelBuilder.Entity<Homework>()
                .Property(h => h.Content)
                .IsUnicode(false);
        }
    }
}
