using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SkillBilAuth.Services;

namespace SkillBilAuth.Models
{
    public partial class SkillbillDbContext : DbContext
    {
        public SkillbillDbContext()
        {
        }

        public SkillbillDbContext(DbContextOptions<SkillbillDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Areas { get; set; } = null!;
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<CatalogSkill> CatalogSkills { get; set; } = null!;
        public virtual DbSet<CatalogSkillHistory> CatalogSkillHistories { get; set; } = null!;
        public virtual DbSet<CustomerSkillHistory> CustomerSkillHistories { get; set; } = null!;
        public virtual DbSet<CustomersSkill> CustomersSkills { get; set; } = null!;
        public virtual DbSet<Education> Educations { get; set; } = null!;
        public virtual DbSet<Grade> Grades { get; set; } = null!;
        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<ViewCatalogSkillsAktiv> ViewCatalogSkillsAktivs { get; set; } = null!;
        public virtual DbSet<ViewCatalogSkillsInaktiv> ViewCatalogSkillsInaktivs { get; set; } = null!;
        public virtual DbSet<ViewCustomer> ViewCustomers { get; set; } = null!;
        public virtual DbSet<ViewGroup> ViewGroups { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationService.connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>(entity =>
            {
                entity.HasIndex(e => e.SubjectId, "IX_Areas_SubjectId");

                entity.Property(e => e.AreaName).HasMaxLength(50);

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Areas)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Areas_Subjects");
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Description).HasMaxLength(30);

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.GroupId, "IX_AspNetUsers_GroupId");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(30);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.PhoneNumber).HasMaxLength(100);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_AspNetUsers_Group");

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.ClaimType).HasMaxLength(255);

                entity.Property(e => e.ClaimValue).HasMaxLength(255);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(225);

                entity.Property(e => e.ProviderKey).HasMaxLength(225);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(112);

                entity.Property(e => e.Name).HasMaxLength(112);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<CatalogSkill>(entity =>
            {
                entity.HasIndex(e => e.AreaId, "IX_CatalogSkills_AreaId");

                entity.Property(e => e.SkillName).HasMaxLength(4000);

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.CatalogSkills)
                    .HasForeignKey(d => d.AreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CatalogSkills_Areas");
            });

            modelBuilder.Entity<CatalogSkillHistory>(entity =>
            {
                entity.HasIndex(e => e.AreaId, "IX_CatalogSkillHistories_AreaId");

                entity.HasIndex(e => e.EditedBy, "IX_CatalogSkillHistories_EditedBy");

                entity.HasIndex(e => e.CatalogSkillId, "IX_CatalogSkillHistories_SkillId");

                entity.Property(e => e.EditedOn)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SkillName).HasMaxLength(4000);

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.CatalogSkillHistories)
                    .HasForeignKey(d => d.AreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CatalogSkillHistories_Areas");

                entity.HasOne(d => d.CatalogSkill)
                    .WithMany(p => p.CatalogSkillHistories)
                    .HasForeignKey(d => d.CatalogSkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CatalogSkillHistories_CatalogSkills");

                entity.HasOne(d => d.EditedByNavigation)
                    .WithMany(p => p.CatalogSkillHistories)
                    .HasForeignKey(d => d.EditedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CatalogSkillHistories_AspNetUsers");
            });

            modelBuilder.Entity<CustomerSkillHistory>(entity =>
            {
                entity.HasIndex(e => e.CustomersSkillId, "IX_CustomerSkillHistories_CustomerSkillCardsId");

                entity.HasIndex(e => e.EditedBy, "IX_CustomerSkillHistories_EditedBy");

                entity.HasIndex(e => e.GradeId, "IX_CustomerSkillHistories_GradeId");

                entity.Property(e => e.EditedOn)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SkillName).HasMaxLength(4000);

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.CustomerSkillHistories)
                    .HasForeignKey(d => d.AreaId)
                    .HasConstraintName("FK_CustomerSkillsHistories_Areas");

                entity.HasOne(d => d.CustomersSkill)
                    .WithMany(p => p.CustomerSkillHistories)
                    .HasForeignKey(d => d.CustomersSkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerSkillsHistories_CustomersSkills");

                entity.HasOne(d => d.EditedByNavigation)
                    .WithMany(p => p.CustomerSkillHistories)
                    .HasForeignKey(d => d.EditedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerSkillsHistories_AspNetUsers");

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.CustomerSkillHistories)
                    .HasForeignKey(d => d.GradeId)
                    .HasConstraintName("FK_CustomerSkillsHistories_Grades");
            });

            modelBuilder.Entity<CustomersSkill>(entity =>
            {
                entity.HasIndex(e => e.AreaId, "IX_CustomersSkills_AreaId");

                entity.HasIndex(e => e.CatalogSkillId, "IX_CustomersSkills_CatalogSkillId");

                entity.HasIndex(e => e.CustomerId, "IX_CustomersSkills_CustomerId");

                entity.HasIndex(e => e.GradeId, "IX_CustomersSkills_GradeId");

                entity.Property(e => e.SkillName).HasMaxLength(4000);

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.CustomersSkills)
                    .HasForeignKey(d => d.AreaId)
                    .HasConstraintName("FK_CustomersSkills_Areas");

                entity.HasOne(d => d.CatalogSkill)
                    .WithMany(p => p.CustomersSkills)
                    .HasForeignKey(d => d.CatalogSkillId)
                    .HasConstraintName("FK_CustomersSkills_CatalogSkills");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomersSkills)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomersSkills_AspNetUsers_Customer");

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.CustomersSkills)
                    .HasForeignKey(d => d.GradeId)
                    .HasConstraintName("FK_CustomersSkills_GradeId");
            });

            modelBuilder.Entity<Education>(entity =>
            {
                entity.Property(e => e.EducationName).HasMaxLength(50);
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.Property(e => e.GradeName).HasMaxLength(100);
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasIndex(e => e.EducationId, "IX_Groups_EducationId");

                entity.Property(e => e.BeginAktOn).HasColumnType("date");

                entity.Property(e => e.EndAktOn).HasColumnType("date");

                entity.Property(e => e.GroupName).HasMaxLength(30);

                entity.HasOne(d => d.Education)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.EducationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Groups_Educations");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasIndex(e => e.GroupId, "IX_Subjects_GroupId");

                entity.Property(e => e.SubjectName).HasMaxLength(50);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_Subjects_Groups");
            });

            modelBuilder.Entity<ViewCatalogSkillsAktiv>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_CatalogSkills_Aktiv");

                entity.Property(e => e.Bereich).HasMaxLength(50);

                entity.Property(e => e.Fach).HasMaxLength(50);

                entity.Property(e => e.Skill).HasMaxLength(4000);
            });

            modelBuilder.Entity<ViewCatalogSkillsInaktiv>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_CatalogSkills_Inaktiv");

                entity.Property(e => e.Bereich).HasMaxLength(50);

                entity.Property(e => e.Fach).HasMaxLength(50);

                entity.Property(e => e.Skill).HasMaxLength(4000);
            });

            modelBuilder.Entity<ViewCustomer>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Customers");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Gruppe).HasMaxLength(30);

                entity.Property(e => e.Nachname).HasMaxLength(30);

                entity.Property(e => e.Telefonnummer).HasMaxLength(100);

                entity.Property(e => e.Vorname).HasMaxLength(50);
            });

            modelBuilder.Entity<ViewGroup>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Groups");

                entity.Property(e => e.AktBeginn)
                    .HasColumnType("date")
                    .HasColumnName("AKT Beginn");

                entity.Property(e => e.AktEnde)
                    .HasColumnType("date")
                    .HasColumnName("AKT Ende");

                entity.Property(e => e.Ausbildung).HasMaxLength(50);

                entity.Property(e => e.Gruppe).HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
