using System;
using DemoExamenTest.Models;
using Microsoft.EntityFrameworkCore;


namespace DemoExamenTest.Data;

public class PartnerDbContext : DbContext
{
    public DbSet<Partner> Partners { get; set; }
    public DbSet<PartnerType> PartnerTypes { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }
    public DbSet<ProductInfo> ProductInfos { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=demo;Username=postgres;Password=postgres");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Partner>().ToTable("partners");
        modelBuilder.Entity<Product>().ToTable("products");
        modelBuilder.Entity<PartnerType>().ToTable("partner_types");
        modelBuilder.Entity<ProductType>().ToTable("product_types");
        modelBuilder.Entity<ProductInfo>().ToTable("product_infos");

        modelBuilder.Entity<Partner>()
            .HasOne<PartnerType>(p => p.PartnerType)
            .WithMany(p => p.Partners)
            .HasForeignKey(p => p.PartnerTypeId);
        
        modelBuilder.Entity<Product>()
            .HasOne<ProductInfo>(p => p.ProductInfo)
            .WithMany(p => p.Products)
            .HasForeignKey(p => p.ProductInfoId);
        
        modelBuilder.Entity<ProductInfo>()
            .HasOne<ProductType>(p => p.ProductType)
            .WithMany(p => p.ProductInfos)
            .HasForeignKey(p => p.ProductTypeId);
        
        modelBuilder.Entity<Product>()
            .HasOne<Partner>(p => p.Partner)
            .WithMany(p => p.Products)
            .HasForeignKey(p => p.PartnerId);
    }
}