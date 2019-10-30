using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EmployeeTracker.Models
{
    public partial class EmployeeTrackerContext : DbContext
    {
        public EmployeeTrackerContext()
        {
        }

        public EmployeeTrackerContext(DbContextOptions<EmployeeTrackerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Office> Office { get; set; }
        public virtual DbSet<Position> Position { get; set; }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseSqlServer("Server=localhost;Database=EmployeeTracker;Trusted_Connection=True;");
        //            }
        //        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                ///To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EmployeeTracker;Trusted_Connection=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(100);

                entity.Property(e => e.OfficeId).HasColumnName("office_id");

                entity.Property(e => e.PositionId).HasColumnName("position_id");

                entity.Property(e => e.Salary)
                    .HasColumnName("salary")
                    .HasColumnType("money");

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasColumnName("sex")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedUtc).HasColumnName("updated_utc");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_employee_office_id");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_employee_position_id");
            });

            modelBuilder.Entity<Office>(entity =>
            {
                entity.ToTable("office");

                entity.Property(e => e.OfficeId).HasColumnName("office_id");

                entity.Property(e => e.OfficeName)
                    .IsRequired()
                    .HasColumnName("office")
                    .HasMaxLength(100);

                entity.Property(e => e.UpdatedUtc).HasColumnName("updated_utc");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("position");

                entity.Property(e => e.PositionId).HasColumnName("position_id");

                entity.Property(e => e.PositionName)
                    .IsRequired()
                    .HasColumnName("position")
                    .HasMaxLength(100);

                entity.Property(e => e.UpdatedUtc).HasColumnName("updated_utc");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
