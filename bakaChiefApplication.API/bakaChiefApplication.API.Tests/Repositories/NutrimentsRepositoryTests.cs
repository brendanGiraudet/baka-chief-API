using bakaChiefApplication.API.DatabaseModels;
using bakaChiefApplication.API.Repositories;
using bakaChiefApplication.API.Repositories.NutrimentsRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace bakaChiefApplication.API.Tests.Repositories
{
    public class NutrimentsRepositoryTests
    {
        private DbContextOptions<DatabaseContext> _options;
        private DatabaseContext _dbContext;

        public NutrimentsRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .ConfigureWarnings(warnings => warnings.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;
        }

        private void InitializeDbContext()
        {
            _dbContext = new DatabaseContext(_options);
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();
        }

        private INutrimentsRepository GetNutrimentRepository()
        {
            InitializeDbContext();
            return new NutrimentsRepository(_dbContext);
        }

        [Fact]
        public async Task CreateNutriment_ShouldAddNewNutriment()
        {
            // Arrange
            var repository = GetNutrimentRepository();
            var nutriment = new Nutriment
            {
                Name = "Vitamin C"
            };

            // Act
            await repository.CreateNutrimentAsync(nutriment);

            // Assert
            Assert.Equal(1, _dbContext.Nutriments.Count());
        }

        [Fact]
        public async Task GetNutrimentById_ShouldReturnCorrectNutriment()
        {
            // Arrange
            var repository = GetNutrimentRepository();
            var nutriment = new Nutriment
            {
                Name = "Protein"
            };
            _dbContext.Nutriments.Add(nutriment);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await repository.GetNutrimentByIdAsync(nutriment.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(nutriment.Name, result.Name);
        }

        [Fact]
        public async Task GetAllNutriments_ShouldReturnAllNutriments()
        {
            // Arrange
            var repository = GetNutrimentRepository();
            var nutriment1 = new Nutriment
            {
                Name = "Fiber"
            };
            var nutriment2 = new Nutriment
            {
                Name = "Calcium"
            };
            _dbContext.Nutriments.AddRange(nutriment1, nutriment2);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await repository.GetNutrimentsAsync();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Contains(result, n => n.Name == "Fiber");
            Assert.Contains(result, n => n.Name == "Calcium");
        }

        [Fact]
        public async Task UpdateNutriment_ShouldUpdateNutriment()
        {
            // Arrange
            var repository = GetNutrimentRepository();
            var nutriment = new Nutriment
            {
                Name = "Iron"
            };
            _dbContext.Nutriments.Add(nutriment);
            await _dbContext.SaveChangesAsync();

            // Act
            nutriment.Name = "Zinc";
            await repository.UpdateNutrimentAsync(nutriment);

            // Assert
            var updatedNutriment = await _dbContext.Nutriments.FindAsync(nutriment.Id);
            Assert.NotNull(updatedNutriment);
            Assert.Equal("Zinc", updatedNutriment.Name);
        }

        [Fact]
        public async Task DeleteNutriment_ShouldDeleteNutriment()
        {
            // Arrange
            var repository = GetNutrimentRepository();
            var nutriment = new Nutriment
            {
                Name = "Vitamin A"
            };
            _dbContext.Nutriments.Add(nutriment);
            await _dbContext.SaveChangesAsync();

            // Act
            await repository.DeleteNutrimentAsync(nutriment.Id);

            // Assert
            var deletedNutriment = await _dbContext.Nutriments.FindAsync(nutriment.Id);
            Assert.Null(deletedNutriment);
        }
    }
}
