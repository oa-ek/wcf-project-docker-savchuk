using DockerProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DockerProject.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Phone> Phones { get; set; }
        public DbSet<Company> Company { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasData(new List<Company>
            {
                new Company {Id = 1, Name = "Lenovo"},
                new Company {Id = 2, Name = "Samsung"},
                new Company {Id = 3, Name = "Apple"},
                new Company {Id = 4, Name = "Xiaomi"},
            });
            modelBuilder.Entity<Phone>().HasData(new List<Phone>
            {
                new Phone {Id = 1, CompanyId = 2, Price=15000, Title = "Galaxy M51"},
                new Phone {Id = 2, CompanyId = 2, Price=17500, Title = "Galaxy A51"},
                new Phone {Id = 3, CompanyId = 3, Price=19000, Title = "Iphone X"},
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
