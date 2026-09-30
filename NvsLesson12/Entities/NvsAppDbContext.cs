using Microsoft.EntityFrameworkCore;
using NvsLesson12.Models;

namespace NvsLesson12.Entities
{
    public class NvsAppDbContext : DbContext
    {
        public NvsAppDbContext(DbContextOptions<NvsAppDbContext> options)
            : base(options)
        {
        }

        // Bài cũ
        public DbSet<NvsCategory> Categories { get; set; }
        public DbSet<NvsProduct> Products { get; set; }
        public DbSet<NvsBanner> Banners { get; set; }

        // Bài 5 - Student Manager
        public DbSet<NvsStdClass> StdClasses { get; set; }
        public DbSet<NvsStudent> Students { get; set; }
        public DbSet<NvsSubject> Subjects { get; set; }
        public DbSet<NvsMark> Marks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Khóa chính kép của bảng Marks
            modelBuilder.Entity<NvsMark>()
                .HasKey(x => new
                {
                    x.SubjectId,
                    x.StudentId
                });

            // StdClass 1 - nhiều Student
            modelBuilder.Entity<NvsStudent>()
                .HasOne(s => s.StdClass)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.ClassId)
                .OnDelete(DeleteBehavior.Restrict);

            // Student 1 - nhiều Mark
            modelBuilder.Entity<NvsMark>()
                .HasOne(m => m.Student)
                .WithMany(s => s.Marks)
                .HasForeignKey(m => m.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Subject 1 - nhiều Mark
            modelBuilder.Entity<NvsMark>()
                .HasOne(m => m.Subject)
                .WithMany(s => s.Marks)
                .HasForeignKey(m => m.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}