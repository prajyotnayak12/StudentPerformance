using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Students.Entity.Model;

public partial class StudentContext : DbContext
{
    public StudentContext()
    {
    }

    public StudentContext(DbContextOptions<StudentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MarkSheet> MarkSheets { get; set; }

    public virtual DbSet<StudentMaster> StudentMasters { get; set; }
    public IEnumerable<object> Students { get; set; }
    public object Student { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-LM2DC8T;Initial Catalog=STUDENT;User Id=sa; password=abcd1234;Persist Security Info=False;Integrated Security=false;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MarkSheet>(entity =>
        {
            entity.HasKey(e => e.MarkSheetId).HasName("PK__MarkShee__719B6DB283BA8796");

            entity.ToTable("MarkSheet");

            entity.Property(e => e.MarkSheetId).ValueGeneratedNever();
            entity.Property(e => e.MarksObtained).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Subject).HasMaxLength(50);
            entity.Property(e => e.TotalMark)
                .HasDefaultValue(100m)
                .HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Student).WithMany(p => p.MarkSheets)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__MarkSheet__Stude__3D5E1FD2");
        });

        modelBuilder.Entity<StudentMaster>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__StudentM__32C52B99693489A8");

            entity.ToTable("StudentMaster");

            entity.Property(e => e.StudentId).ValueGeneratedNever();
            entity.Property(e => e.StudentName).HasMaxLength(150);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
