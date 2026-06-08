using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace backend.Entities;

public partial class AlumniDBContext : DbContext
{
    public AlumniDBContext()
    {
    }

    public AlumniDBContext(DbContextOptions<AlumniDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

//     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//         => optionsBuilder.UseSqlServer("Server=tcp:tsu-alumni-sql.database.windows.net,1433;Initial Catalog=AlumniWebsite;Persist Security Info=False;User ID=alumniadmin;Password=jiz@Dq8wDTSuWdr;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC1F8D1E89");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.HashedPassword)
                .HasMaxLength(255)
                .HasColumnName("hashedPassword");
            entity.Property(e => e.LastLoginAt).HasColumnType("datetime");
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.LockedUntil).HasColumnType("datetime");
            entity.Property(e => e.PersonalId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PersonalID");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.RoleId)
                .HasDefaultValue(2, "DF__Users__RoleID__1C5231C2")
                .HasColumnName("RoleID");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
