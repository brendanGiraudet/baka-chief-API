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

            modelBuilder.Entity<Nutriment>().HasMany(i => i.Ingredients).WithMany(j => j.Nutriments).UsingEntity<IngredientNutriment>();
            
            modelBuilder.Entity<Ingredient>().HasMany(i => i.Recips).WithMany(j => j.Ingredients).UsingEntity<RecipIngredient>();
            
            modelBuilder.Entity<Recip>().HasMany(i => i.RecipSteps).WithOne(j => j.Recip).OnDelete(DeleteBehavior.Cascade);
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
        /// Gets or sets the <see cref="DbSet{RecipStep}"/>.
        /// </summary>
        public virtual DbSet<RecipStep> RecipSteps { get; set; }
    }
}