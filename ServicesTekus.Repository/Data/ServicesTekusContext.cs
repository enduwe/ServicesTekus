using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ServicesTekus.Core.Entities;

#nullable disable

namespace ServicesTekus.Repository.Data
{
    public partial class ServicesTekusContext : DbContext
    {
        public ServicesTekusContext()
        {
        }

        public ServicesTekusContext(DbContextOptions<ServicesTekusContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<DynamicField> DynamicFields { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<ServiceCountry> ServiceCountries { get; set; }

     /*   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=ServicesTekus; Integrated Security = true;");
            }
        }
     */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("COUNTRY", "ISS");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<DynamicField>(entity =>
            {
                entity.ToTable("DYNAMIC_FIELDS", "ISS");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Enable)
                    .IsRequired()
                    .HasColumnName("ENABLE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IdProvider)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("ID_PROVIDER");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("NAME");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("VALUE");

                entity.HasOne(d => d.IdProviderNavigation)
                    .WithMany(p => p.DynamicFields)
                    .HasForeignKey(d => d.IdProvider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DYNAMIC_FIELDS_PROVIDER");
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.ToTable("PROVIDER", "ISS");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("NAME");

                entity.Property(e => e.Nit)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("NIT");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("SERVICE", "ISS");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.IdProvider)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("ID_PROVIDER");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("NAME");

                entity.Property(e => e.PricePerHour)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("PRICE_PER_HOUR");

                entity.HasOne(d => d.IdProviderNavigation)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.IdProvider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SERVICE_PROVIDER");
            });

            modelBuilder.Entity<ServiceCountry>(entity =>
            {
                entity.ToTable("SERVICE_COUNTRY", "ISS");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Enable)
                    .IsRequired()
                    .HasColumnName("ENABLE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IdCountry)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("ID_COUNTRY");

                entity.Property(e => e.IdService)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("ID_SERVICE");

                entity.HasOne(d => d.IdCountryNavigation)
                    .WithMany(p => p.ServiceCountries)
                    .HasForeignKey(d => d.IdCountry)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SERVICE_COUNTRY_COUNTRY");
              

                entity.HasOne(d => d.IdServiceNavigation)
                    .WithMany(p => p.ServiceCountries)
                    .HasForeignKey(d => d.IdService)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SERVICE_COUNTRY_SERVICE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
