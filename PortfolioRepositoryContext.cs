using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TestCatalogue.Database.SQLModels;

namespace TestCatalogue;

public partial class PortfolioRepositoryContext : DbContext
{
    public PortfolioRepositoryContext()
    {
    }

    public PortfolioRepositoryContext(DbContextOptions<PortfolioRepositoryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CategorySpecificationsField> CategorySpecificationsFields { get; set; }

    public virtual DbSet<Good> Goods { get; set; }

    public virtual DbSet<GoodsContent> GoodsContents { get; set; }

    public virtual DbSet<Specification> Specifications { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=PortfolioRepository;User ID=sa;Password=Lorgar17;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Category");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<CategorySpecificationsField>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Good>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<GoodsContent>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("GoodsContent");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Specification>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Specification");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
