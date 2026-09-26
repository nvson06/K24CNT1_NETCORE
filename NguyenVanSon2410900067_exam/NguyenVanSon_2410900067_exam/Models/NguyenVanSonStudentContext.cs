using Microsoft.EntityFrameworkCore;

namespace NguyenVanSon_2410900067_exam.Models;

public partial class NguyenVanSonStudentContext : DbContext
{
    public NguyenVanSonStudentContext(
        DbContextOptions<NguyenVanSonStudentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<NguyenVanSonStudent> NguyenVanSonStudents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NguyenVanSonStudent>(entity =>
        {
            entity.ToTable("NguyenVanSonStudent");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.NguyenVanSonName)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(e => e.NguyenVanSonGender)
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(e => e.NguyenVanSonBirthday)
                .HasColumnType("date")
                .IsRequired();

            entity.Property(e => e.NguyenVanSonEmail)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(e => e.NguyenVanSonPhone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsRequired();

            entity.Property(e => e.NguyenVanSonActive)
                .HasDefaultValue(true);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}