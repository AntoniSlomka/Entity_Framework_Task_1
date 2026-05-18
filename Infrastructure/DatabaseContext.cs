using EFCodeFirstTask1.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCodeFirstTask1.Infrastructure
{
    public class DatabaseContext(DbContextOptions opt) : DbContext(opt) 
    {
        public DbSet<Component> Components { get; set; }
        public DbSet<PC> PCs { get; set; }
        public DbSet<PCComponent> PCComponents { get; set; }
        public DbSet<ComponentManufacturer> ComponentManufacturers { get; set; }
        public DbSet<ComponentType> ComponentTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // PC Configuration
            modelBuilder.Entity<PC>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<PC>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<PC>()
                .Property(p => p.Weight)
                .IsRequired()
                .HasMaxLength(5);

            // Component Configuration
            modelBuilder.Entity<Component>()
                .HasKey(c => c.Code);

            modelBuilder.Entity<Component>()
                .Property(c => c.Code)
                .HasMaxLength(10);

            modelBuilder.Entity<Component>()
                .Property(c => c.Name)
                .HasMaxLength(300);

            modelBuilder.Entity<Component>()
                .HasOne(c => c.ComponentManufacturer)
                .WithMany(m => m.Components)
                .HasForeignKey(c => c.ComponentManufacturerId);

            modelBuilder.Entity<Component>()
                .HasOne(c => c.ComponentType)
                .WithMany(t => t.Components)
                .HasForeignKey(c => c.ComponentTypeId);

            // PCComponent Configuration
            modelBuilder.Entity<PCComponent>()
                .HasKey(p => new {p.PCId, p.ComponentCode});

            modelBuilder.Entity<PCComponent>()
                .HasOne(p => p.PC)
                .WithMany(pc => pc.PCComponents)
                .HasForeignKey(p => p.PCId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PCComponent>()
                .HasOne(p => p.Component)
                .WithMany(c => c.PCComponents)
                .HasForeignKey(p => p.ComponentCode);

            // ComponentManufacturers Configuration
            modelBuilder.Entity<ComponentManufacturer>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<ComponentManufacturer>()
                .Property(m => m.Abbreviation)
                .IsRequired()
                .HasMaxLength(30);

            modelBuilder.Entity<ComponentManufacturer>()
                .Property(m => m.FullName)
                .IsRequired()
                .HasMaxLength(300);

            // ComponentTypes Configuraiton
            modelBuilder.Entity<ComponentType>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<ComponentType>()
                .Property(t => t.Abbreviation)
                .IsRequired()
                .HasMaxLength(30);

            modelBuilder.Entity<ComponentType>()
                .Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(150);

            // Seed Types
            modelBuilder.Entity<ComponentType>().HasData(
                    new ComponentType { Id = 1, Abbreviation = "RAM", Name = "Random Access Memory" },
                    new ComponentType { Id = 2, Abbreviation = "CPU", Name = "Central Proccesing Unit" },
                    new ComponentType { Id = 3, Abbreviation = "GPU", Name = "Graphics Proccesing Unit" },
                    new ComponentType { Id = 4, Abbreviation = "SSD", Name = "Solid State Drive" }
                );

            // Seed Manufactures

            modelBuilder.Entity<ComponentManufacturer>().HasData(
                new ComponentManufacturer { Id = 1, Abbreviation = "NVIDIA", FullName = "NVIDIA Corporation", FoundationDate = new DateTime(1993, 10, 10) },
                new ComponentManufacturer { Id = 2, Abbreviation = "Intel", FullName = "Intel Corporation", FoundationDate = new DateTime(1968, 7, 18) },
                new ComponentManufacturer { Id = 3, Abbreviation = "AMD", FullName = "Advanced Micro Devices, Inc.", FoundationDate = new DateTime(1969, 5, 1) },
                new ComponentManufacturer { Id = 4, Abbreviation = "Samsung", FullName = "Samsung Electronics Co., Ltd.", FoundationDate = new DateTime(1969, 1, 13) }
            );

            // Seed Components

            modelBuilder.Entity<Component>().HasData(
                new Component
                {
                    Code = "R75800X",
                    Name = "AMD Ryzen 7 5800X",
                    Description = "8-core, 16-thread desktop processor with 3.8 GHz base clock.",
                    ComponentManufacturerId = 3,   // AMD
                    ComponentTypeId = 2            // CPU
                },
                new Component
                {
                    Code = "RTX4090",
                    Name = "NVIDIA GeForce RTX 4090",
                    Description = "Ada Lovelace flagship GPU with 24 GB GDDR6X VRAM.",
                    ComponentManufacturerId = 1,   // NVIDIA
                    ComponentTypeId = 3            // GPU
                },
                new Component
                {
                    Code = "DDR532G",
                    Name = "Samsung 32 GB DDR5-6000",
                    Description = "Single 32 GB DDR5 DIMM running at 6000 MT/s.",
                    ComponentManufacturerId = 4,   // Samsung
                    ComponentTypeId = 1            // RAM
                },
                new Component
                {
                    Code = "990PRO2T",
                    Name = "Samsung 990 Pro 2 TB NVMe",
                    Description = "PCIe 4.0 NVMe SSD with sequential read up to 7450 MB/s.",
                    ComponentManufacturerId = 4,   // Samsung
                    ComponentTypeId = 4            // SSD
                }
            );

            // Seed PCs

            modelBuilder.Entity<PC>().HasData(
                new PC { Id = 1, Name = "UltraDesk Pro", Weight = 8.5f, Warranty = 24, CreatedAt = new DateTime(2023, 1, 15), Stock = 12 },
                new PC { Id = 2, Name = "GamerRig X", Weight = 11.2f, Warranty = 12, CreatedAt = new DateTime(2023, 4, 22), Stock = 7 },
                new PC { Id = 3, Name = "WorkStation Z", Weight = 14.0f, Warranty = 36, CreatedAt = new DateTime(2022, 11, 3), Stock = 3 },
                new PC { Id = 4, Name = "CompactMini 500", Weight = 3.8f, Warranty = 12, CreatedAt = new DateTime(2024, 2, 10), Stock = 20 }
            );

            // Seed PCComponents

            modelBuilder.Entity<PCComponent>().HasData(
                new PCComponent { PCId = 1, ComponentCode = "R75800X", Amount = 1 },
                new PCComponent { PCId = 1, ComponentCode = "DDR532G", Amount = 2 },
                new PCComponent { PCId = 2, ComponentCode = "RTX4090", Amount = 1 },
                new PCComponent { PCId = 2, ComponentCode = "990PRO2T", Amount = 2 },
                new PCComponent { PCId = 3, ComponentCode = "R75800X", Amount = 1 },
                new PCComponent { PCId = 3, ComponentCode = "990PRO2T", Amount = 4 },
                new PCComponent { PCId = 4, ComponentCode = "DDR532G", Amount = 1 },
                new PCComponent { PCId = 4, ComponentCode = "RTX4090", Amount = 1 }
            );
        }
    }
}
