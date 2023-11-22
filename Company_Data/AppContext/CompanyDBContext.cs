using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Company_Models.Model;

namespace Company_Data.AppContext
{
    public partial class CompanyDBContext : DbContext
    {
        public CompanyDBContext()
        {
        }

        public CompanyDBContext(DbContextOptions<CompanyDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Dependent> Dependents { get; set; } = null!;
        public virtual DbSet<DeptLocation> DeptLocations { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<WorksOn> WorksOns { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DEVELOPER-07\\SQLEXPRESS;Initial Catalog=CompanyDB; Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.Dnumber)
                    .HasName("pk_Department");

                entity.ToTable("DEPARTMENT");

                entity.HasIndex(e => e.Dname, "uk_dname")
                    .IsUnique();

                entity.Property(e => e.Dnumber).ValueGeneratedNever();

                entity.Property(e => e.Dname)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.MgrSsn)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("Mgr_ssn")
                    .IsFixedLength();

                entity.Property(e => e.MgrStartDate)
                    .HasColumnType("date")
                    .HasColumnName("Mgr_start_date");
            });

            modelBuilder.Entity<Dependent>(entity =>
            {
                entity.HasKey(e => new { e.Essn, e.DependentName })
                    .HasName("pk_Essn_Dependent_name");

                entity.ToTable("DEPENDENT");

                entity.Property(e => e.Essn)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DependentName)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Dependent_name");

                entity.Property(e => e.Bdate).HasColumnType("date");

                entity.Property(e => e.Relationship)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Sex)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.EssnNavigation)
                    .WithMany(p => p.Dependents)
                    .HasForeignKey(d => d.Essn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Dependent_employee");
            });

            modelBuilder.Entity<DeptLocation>(entity =>
            {
                entity.HasKey(e => new { e.Dnumber, e.Dlocation })
                    .HasName("pk_dept_locations");

                entity.ToTable("DEPT_LOCATIONS");

                entity.Property(e => e.Dlocation)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.DnumberNavigation)
                    .WithMany(p => p.DeptLocations)
                    .HasForeignKey(d => d.Dnumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_deptlocations_department");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Ssn)
                    .HasName("pk_employee");

                entity.ToTable("EMPLOYEE");

                entity.Property(e => e.Ssn)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Bdate).HasColumnType("date");

                entity.Property(e => e.Fname)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Lname)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Minit)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Salary).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Sex)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SuperSsn)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("Super_ssn")
                    .IsFixedLength();

                entity.HasOne(d => d.DnoNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Dno)
                    .HasConstraintName("fk_employee_department");

                entity.HasOne(d => d.SuperSsnNavigation)
                    .WithMany(p => p.InverseSuperSsnNavigation)
                    .HasForeignKey(d => d.SuperSsn)
                    .HasConstraintName("fk_employee_employee");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.Pnumber)
                    .HasName("ok_project");

                entity.ToTable("PROJECT");

                entity.HasIndex(e => e.Pname, "uc_Pnumber")
                    .IsUnique();

                entity.Property(e => e.Pnumber).ValueGeneratedNever();

                entity.Property(e => e.Plocation)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Pname)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.DnumNavigation)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.Dnum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_project_department");
            });

            modelBuilder.Entity<WorksOn>(entity =>
            {
                entity.HasKey(e => new { e.Essn, e.Pno })
                    .HasName("pk_worksOn");

                entity.ToTable("WORKS_ON");

                entity.Property(e => e.Essn)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Hours).HasColumnType("decimal(4, 1)");

                entity.HasOne(d => d.EssnNavigation)
                    .WithMany(p => p.WorksOns)
                    .HasForeignKey(d => d.Essn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_workson_employee");

                entity.HasOne(d => d.PnoNavigation)
                    .WithMany(p => p.WorksOns)
                    .HasForeignKey(d => d.Pno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_workson_project");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
