using bakaChiefApplication.API.DatabaseModels;
using bakaChiefApplication.API.Repositories;
using bakaChiefApplication.API.Repositories.IngredientsRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace bakaChiefApplication.API.Tests.Repositories
{
    public class IngredientsRepositoryTests
    {
        private DbContextOptions<DatabaseContext> _options;
        private DatabaseContext _dbContext;

        public IngredientsRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .ConfigureWarnings(warnings => warnings.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;
        }

        private void InitializeDbContext()
        {
            _dbContext = new DatabaseContext(_options);
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();
        }

        private IIngredientsRepository GetRepository()
        {
            InitializeDbContext();
            return new IngredientsRepository(_dbContext);
        }

        [Fact]
        public async Task CreateIngredientAsync_ShouldAddNewIngredient()
        {
            // Arrange
            var repository = GetRepository();

            var nutriment1 = new Nutriment
            {
                Id = "nutri1",
                Name = "Testnutri1"
            };

            var nutriment2 = new Nutriment
            {
                Id = "nutri2",
                Name = "Testnutri2"
            };

            await _dbContext.SaveChangesAsync();

            var ingredient = new Ingredient
            {
                Name = "IngredientName",
                ImageUrl = "ImageURL",
                Nutriments = new[] { 
                    nutriment1,
                    nutriment2
                }
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
                ImageUrl = "ImageURL"
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

            var nutriment1 = new Nutriment
            {
                Id = "nutri1",
                Name = "Testnutri1"
            };

            var nutriment2 = new Nutriment
            {
                Id = "nutri2",
                Name = "Testnutri2"
            };

            await _dbContext.SaveChangesAsync();

            _dbContext.Nutriments.AddRange(nutriment1, nutriment2);

            var ingredient1 = new Ingredient
            {
                Id = "test1",
                Name = "Ingredient1",
                ImageUrl = "ImageURL1",
                Nutriments = new List<Nutriment>()
                {
                    nutriment1,
                    nutriment2
                }
            };
            var ingredient2 = new Ingredient
            {
                Name = "Ingredient2",
                ImageUrl = "ImageURL2"
            };
            _dbContext.Ingredients.AddRange(ingredient1, ingredient2);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await repository.GetIngredientsAsync();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains(result, i => i.Name == "Ingredient1");
            Assert.Contains(result, i => i.Name == "Ingredient2");

            var ingredient = result.Find(f => f.Id == "test1");
            Assert.NotEmpty(ingredient.Nutriments);
            Assert.Contains(ingredient.Nutriments, i => i.Name == "Testnutri1");
            Assert.Contains(ingredient.Nutriments, i => i.Name == "Testnutri2");
        }

        [Fact]
        public async Task UpdateIngredientAsync_ShouldUpdateIngredient()
        {
            // Arrange
            var repository = GetRepository();
            var ingredient = new Ingredient
            {
                Name = "OldName",
                ImageUrl = "OldImage"
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
                ImageUrl = "ImageURL"
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
