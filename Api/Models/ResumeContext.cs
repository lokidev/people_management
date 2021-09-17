using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace QuickTechApi.Models
{
    public partial class ResumeContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ResumeContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ResumeContext(DbContextOptions<ResumeContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public virtual DbSet<Tech> Teches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetSection("SqlConnection").Get<string>());
                // Use when running outside of docker
                // optionsBuilder.UseSqlServer("Server=localhost,5434;Database=Resume;User ID=sa;Password=Yukon900;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Tech>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Tech");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IsCurrent).HasColumnName("isCurrent");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
