using bakaChiefApplication.API.DatabaseModels;
using bakaChiefApplication.API.Repositories;
using bakaChiefApplication.API.Repositories.IngredientRepository;
using Microsoft.EntityFrameworkCore;

namespace bakaChiefApplication.API.Tests.Repositories
{
    public class IngredientRepositoryTests
    {
        private DbContextOptions<DatabaseContext> _options;
        private DatabaseContext _dbContext;

        public IngredientRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }

        private void InitializeDbContext()
        {
            _dbContext = new DatabaseContext(_options);
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();
        }

        private IIngredientRepository GetRepository()
        {
            InitializeDbContext();
            return new IngredientRepository(_dbContext);
        }

        [Fact]
        public async Task CreateIngredientAsync_ShouldAddNewIngredient()
        {
            // Arrange
            var repository = GetRepository();
            var ingredient = new Ingredient
            {
                Name = "IngredientName",
                Image = "ImageURL"
            };

            // Act
            await repository.CreateIngredientAsync(ingredient);

            // Assert
            Assert.Equal(1, _dbContext.Ingredients.Count());
        }

        [Fact]
        public async Task GetIngredientByIdAsync_ShouldReturnCorrectIngredient()
        {
            // Arrange
            var repository = GetRepository();
            var ingredient = new Ingredient
            {
                Name = "IngredientName",
                Image = "ImageURL"
            };
            _dbContext.Ingredients.Add(ingredient);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await repository.GetIngredientByIdAsync(ingredient.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ingredient.Name, result.Name);
        }

        [Fact]
        public async Task GetAllIngredientsAsync_ShouldReturnAllIngredients()
        {
            // Arrange
            var repository = GetRepository();
            var ingredient1 = new Ingredient
            {
                Name = "Ingredient1",
                Image = "ImageURL1"
            };
            var ingredient2 = new Ingredient
            {
                Name = "Ingredient2",
                Image = "ImageURL2"
            };
            _dbContext.Ingredients.AddRange(ingredient1, ingredient2);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await repository.GetAllIngredientsAsync();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains(result, i => i.Name == "Ingredient1");
            Assert.Contains(result, i => i.Name == "Ingredient2");
        }

        [Fact]
        public async Task UpdateIngredientAsync_ShouldUpdateIngredient()
        {
            // Arrange
            var repository = GetRepository();
            var ingredient = new Ingredient
            {
                Name = "OldName",
                Image = "OldImage"
            };
            _dbContext.Ingredients.Add(ingredient);
            await _dbContext.SaveChangesAsync();

            // Act
            ingredient.Name = "NewName";
            await repository.UpdateIngredientAsync(ingredient);

            // Assert
            var updatedIngredient = await _dbContext.Ingredients.FindAsync(ingredient.Id);
            Assert.NotNull(updatedIngredient);
            Assert.Equal("NewName", updatedIngredient.Name);
        }

        [Fact]
        public async Task DeleteIngredientAsync_ShouldDeleteIngredient()
        {
            // Arrange
            var repository = GetRepository();
            var ingredient = new Ingredient
            {
                Name = "IngredientToDelete",
                Image = "ImageURL"
            };
            _dbContext.Ingredients.Add(ingredient);
            await _dbContext.SaveChangesAsync();

            // Act
            await repository.DeleteIngredientAsync(ingredient.Id);

            // Assert
            var deletedIngredient = await _dbContext.Ingredients.FindAsync(ingredient.Id);
            Assert.Null(deletedIngredient);
        }
    }
}
