using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Models;

namespace DAL
{
    public class CarDetailsContext: DbContext
    {
        public CarDetailsContext() : base(@"Data Source=.\SQLSERVER;Initial Catalog=CarDetails;Integrated Security=True")
        {
        }

        public DbSet<Cars> Cars { get; set; }
        public DbSet<Details> Details { get; set; }
        public DbSet<Manufacturers> Manufacturers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cars>()
                .ToTable("Cars")
                .HasKey(x => x.Id)
                .Property(x => x.Name)
                .HasMaxLength(20);

            modelBuilder.Entity<Cars>()
                .HasMany(x => x.Details)
                .WithRequired(x => x.Car)
                .HasForeignKey(x => x.CarsId);

            modelBuilder.Entity<Details>()
                .ToTable("Details")
                .HasKey(x => x.Id)
                .Property(x => x.NameDetail)
                .HasMaxLength(20);

            modelBuilder.Entity<Manufacturers>()
                .ToTable("Manufacturers")
                .HasKey(x => x.Id)
                .Property(x => x.Name)
                .HasMaxLength(20);

            modelBuilder.Entity<Manufacturers>()
                .HasMany(x => x.Cars)
                .WithRequired(x => x.Manufacturer)
                .HasForeignKey(x => x.ManufacturerId);

            modelBuilder.Entity<Manufacturers>()
                .HasMany(x => x.Details)
                .WithRequired(x => x.Manufacturer)
                .HasForeignKey(x => x.ManufacturerId);
        }
    }
}
