﻿using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            

        }
        public DbSet<Category> Categories { get; set; }  //the physical DB table will be name Categories
        public DbSet<Manufacturer> Manufacturers { get; set; }


        //inserting seed data when Model is physically created in the DB the first time
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Non-Alcoholic Beverages", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Wine", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Snacks", DisplayOrder = 3 }
               );

            modelBuilder.Entity<Manufacturer>().HasData(
                new Manufacturer { Id = 1, Name = "Coca Cola"},
                new Manufacturer { Id = 2, Name = "Yellow Tail"},
                new Manufacturer { Id = 3, Name = "Trinchero Family Estates" },
                new Manufacturer { Id = 4, Name = "Doritos"},
                new Manufacturer { Id = 5, Name = "Cheetos" }
                );
        }



    }

}
