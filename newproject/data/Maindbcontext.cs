using Microsoft.EntityFrameworkCore;
using newproject.Models;

namespace newproject.data
{
    public class Maindbcontext: DbContext
    {
        public Maindbcontext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Enrollment>()
           .HasKey(e => new { e.StudentId, e.CourseId });

            // Configure relationships
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId);
        }
public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<LogEntry> LogEntriesww { get; set; }

    }
}
