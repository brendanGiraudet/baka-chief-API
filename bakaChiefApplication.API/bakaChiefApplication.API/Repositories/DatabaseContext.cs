using bakaChiefApplication.API.DatabaseModels;
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

            // NUTRIMENT
            modelBuilder.Entity<Nutriment>()
                .HasMany(i => i.IngredientNutriments)
                .WithOne(j => j.Nutriment)
                .HasForeignKey(e => e.NutrimentId)
                .OnDelete(DeleteBehavior.Cascade);

            // INGREDIENT NUTRIMENT
            modelBuilder.Entity<IngredientNutriment>().HasKey(e => new { e.IngredientId, e.NutrimentId });

            // INGREDIENT
            modelBuilder.Entity<Ingredient>()
                .HasMany(i => i.IngredientNutriments)
                .WithOne(j => j.Ingredient)
                .HasForeignKey(e => e.IngredientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Ingredient>()
                .HasMany(i => i.RecipIngredients)
                .WithOne(j => j.Ingredient)
                .HasForeignKey(e => e.IngredientId)
                .OnDelete(DeleteBehavior.Cascade);

            // INGREDIENT RECIP
            modelBuilder.Entity<RecipIngredient>().HasKey(e => new { e.IngredientId, e.RecipId });

            // RECIP
            modelBuilder.Entity<Recip>()
                .HasMany(i => i.RecipIngredients)
                .WithOne(j => j.Recip)
                .HasForeignKey(e => e.RecipId)
                .OnDelete(DeleteBehavior.Cascade);

            // SELECTEDRECIPHISTORY    
            modelBuilder.Entity<SelectedRecipHistory>()
                .HasMany(i => i.Recips)
                .WithMany(j => j.SelectedRecipHistories);
        }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{Nutriment}"/>.
        /// </summary>
        public virtual DbSet<Nutriment> Nutriments { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{IngredientNutriment}"/>.
        /// </summary>
        public virtual DbSet<IngredientNutriment> IngredientNutriments { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{Ingredient}"/>.
        /// </summary>
        public virtual DbSet<Ingredient> Ingredients { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{RecipIngredient}"/>.
        /// </summary>
        public virtual DbSet<RecipIngredient> RecipIngredients { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{Recip}"/>.
        /// </summary>
        public virtual DbSet<Recip> Recips { get; set; }
        
        /// <summary>
        /// Gets or sets the <see cref="DbSet{SelectedRecipHistory}"/>.
        /// </summary>
        public virtual DbSet<SelectedRecipHistory> SelectedRecipHistories { get; set; }
    }
}