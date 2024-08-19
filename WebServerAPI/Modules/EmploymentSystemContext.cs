using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebServerAPI.Modules;

public partial class EmploymentSystemContext : DbContext
{
    public EmploymentSystemContext()
    {
    }

    public EmploymentSystemContext(DbContextOptions<EmploymentSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Applicant> Applicants { get; set; }

    public virtual DbSet<Career> Careers { get; set; }

    public virtual DbSet<Education> Educations { get; set; }

    public virtual DbSet<ExperinceRequirment> ExperinceRequirments { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-NH0OL4FO\\SQLEXPRESS;Database=EmploymentSystem;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Applicant>(entity =>
        {
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FatherName).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.GrandFatherName).HasMaxLength(50);
            entity.Property(e => e.Nid)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("NID");
            entity.Property(e => e.PhoneNumber1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber2)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.SurName).HasMaxLength(50);

            entity.HasOne(d => d.Career).WithMany(p => p.Applicants)
                .HasForeignKey(d => d.CareerId)
                .HasConstraintName("FK_Applicants_Careers");
        });

        modelBuilder.Entity<Career>(entity =>
        {
            entity.HasKey(e => e.CareerId).HasName("PK_Jobs");

            entity.Property(e => e.ApplicationExpirationDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.PostionType).HasComment("1- Full-Time\r\n2- Part-Time\r\n3- Contract\r\n4-Temporary\r\n5- Remote\r\n");
            entity.Property(e => e.RefrenceCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Title).HasMaxLength(300);

            entity.HasOne(d => d.ExperienceRequirement).WithMany(p => p.Careers)
                .HasForeignKey(d => d.ExperienceRequirementId)
                .HasConstraintName("FK_Careers_ExperinceRequirments");

            entity.HasOne(d => d.Location).WithMany(p => p.Careers)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("FK_Careers_Locations");
        });

        modelBuilder.Entity<Education>(entity =>
        {
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(250);
        });

        modelBuilder.Entity<ExperinceRequirment>(entity =>
        {
            entity.HasKey(e => e.ExperienceRequirementId);

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(150);
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Descriptions).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(150);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FullName).HasMaxLength(150);
            entity.Property(e => e.LastLoginOn).HasColumnType("datetime");
            entity.Property(e => e.LoginTryAttemptDate).HasColumnType("datetime");
            entity.Property(e => e.Password)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasDefaultValue((short)0)
                .HasComment("1- active \r\n2- not active by confirm his phone number otp \r\n3- suspended , wrong login attempts\r\n0 -rejected\r\n\r\n");
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
