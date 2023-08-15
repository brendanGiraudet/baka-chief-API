﻿using bakaChiefApplication.API.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace bakaChiefApplication.API.Repositories
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
       : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ingredient>().HasMany(i => i.NutrimentTypes).WithMany(j => j.Ingredients);
        }


        /// <summary>
        /// Gets or sets the <see cref="DbSet{NutrimentType}"/>.
        /// </summary>
        public virtual DbSet<NutrimentType> NutrimentTypes { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{Ingredient}"/>.
        /// </summary>
        public virtual DbSet<Ingredient> Ingredients { get; set; }
    }
}