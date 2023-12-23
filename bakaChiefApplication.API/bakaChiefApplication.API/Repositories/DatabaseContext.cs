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

            modelBuilder.Entity<ProductInfo>().HasMany(i => i.RecipProductInfos).WithOne(j => j.ProductInfo).OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Recip>().HasMany(i => i.RecipProductInfos).WithOne(j => j.Recip).OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Recip>().HasMany(i => i.RecipSteps).WithOne(j => j.Recip).OnDelete(DeleteBehavior.Cascade);
        }


        /// <summary>
        /// Gets or sets the <see cref="DbSet{RecipProductInfo}"/>.
        /// </summary>
        public virtual DbSet<RecipProductInfo> RecipProductInfos { get; set; }
        
        /// <summary>
        /// Gets or sets the <see cref="DbSet{Recip}"/>.
        /// </summary>
        public virtual DbSet<Recip> Recips { get; set; }
        
        /// <summary>
        /// Gets or sets the <see cref="DbSet{RecipStep}"/>.
        /// </summary>
        public virtual DbSet<RecipStep> RecipSteps { get; set; }
        
        /// <summary>
        /// Gets or sets the <see cref="DbSet{ProductInfo}"/>.
        /// </summary>
        public virtual DbSet<ProductInfo> Products { get; set; }
    }
}