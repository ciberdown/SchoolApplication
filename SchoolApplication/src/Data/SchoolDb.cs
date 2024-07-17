using Microsoft.EntityFrameworkCore;
using SchoolApplication.src.Models;

namespace SchoolApplication.src.Data
{
    public class SchoolDb : DbContext
    {
        public DbSet<Course> courses { get; set; }
        public DbSet<Scholarship> Scholarships { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        public SchoolDb(DbContextOptions options) : base(options){}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<School>()
                .HasIndex(sc => sc.Name)
                .IsUnique(true);

            builder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });
            builder.Entity<StudentCourse>()
                .HasOne(s => s.Course)
                .WithMany(c => c.EnrolledStudents)
                .HasForeignKey(s => s.CourseId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<StudentCourse>()
                .HasOne(s => s.Student)
                .WithMany(c => c.Courses)
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Course>()
                .HasOne(c => c.EventPlaceSchool)
                .WithMany(s => s.Courses)
                .HasForeignKey(c => c.SchoolId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Course>()
                .HasIndex(c => c.Name)
                .IsUnique();

            builder.Entity<Scholarship>()
                .HasKey(ss => new { ss.StudentId, ss.AimSchoolId });
            builder.Entity<Scholarship>()
                .HasOne(ss => ss.Student)
                .WithOne(s => s.Scholarship)
                .HasForeignKey<Scholarship>(s => s.StudentId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Scholarship>()
                .HasOne(ss => ss.School)
                .WithMany(s => s.TakedScholarships)
                .HasForeignKey(ss => ss.AimSchoolId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.Entity<Student>()
                .HasOne(s => s.School)
                .WithMany(s => s.Students)
                .HasForeignKey(s => s.SchoolId);



        }

    }
}
