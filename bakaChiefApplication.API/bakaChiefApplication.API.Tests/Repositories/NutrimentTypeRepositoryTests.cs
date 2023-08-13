using bakaChiefApplication.API.DatabaseModels;
using bakaChiefApplication.API.Repositories;
using bakaChiefApplication.API.Repositories.NutrimentTypeRepository;
using Microsoft.EntityFrameworkCore;

namespace bakaChiefApplication.API.Tests.Repositories
{
    public class NutrimentTypeRepositoryTests
    {
        private DbContextOptions<DatabaseContext> _options;
        private DatabaseContext _dbContext;
        private INutrimentTypeRepository _repository;

        public NutrimentTypeRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        }

        private void InitializeDbContext()
        {
            _dbContext = new DatabaseContext(_options);
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            _repository = new NutrimentTypeRepository(_dbContext);
        }

        [Fact]
        public async Task CreateNutrimentType_ShouldAddNewNutrimentType()
        {
            // Arrange
            InitializeDbContext();
            var nutrimentType = new NutrimentType
            {
                Name = "Vitamin C"
            };

            // Act
            await _repository.CreateNutrimentTypeAsync(nutrimentType);

            // Assert
            Assert.Equal(1, _dbContext.NutrimentTypes.Count());
        }

        [Fact]
        public async Task GetNutrimentTypeById_ShouldReturnCorrectNutrimentType()
        {
            // Arrange
            InitializeDbContext();
            var nutrimentType = new NutrimentType
            {
                Name = "Protein"
            };
            _dbContext.NutrimentTypes.Add(nutrimentType);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _repository.GetNutrimentTypeByIdAsync(nutrimentType.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(nutrimentType.Name, result.Name);
        }

        [Fact]
        public async Task GetAllNutrimentTypes_ShouldReturnAllNutrimentTypes()
        {
            // Arrange
            InitializeDbContext();
            var nutrimentType1 = new NutrimentType
            {
                Name = "Fiber"
            };
            var nutrimentType2 = new NutrimentType
            {
                Name = "Calcium"
            };
            _dbContext.NutrimentTypes.AddRange(nutrimentType1, nutrimentType2);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _repository.GetAllNutrimentTypesAsync();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains(result, n => n.Name == "Fiber");
            Assert.Contains(result, n => n.Name == "Calcium");
        }

        [Fact]
        public async Task UpdateNutrimentType_ShouldUpdateNutrimentType()
        {
            // Arrange
            InitializeDbContext();
            var nutrimentType = new NutrimentType
            {
                Name = "Iron"
            };
            _dbContext.NutrimentTypes.Add(nutrimentType);
            await _dbContext.SaveChangesAsync();

            // Act
            nutrimentType.Name = "Zinc";
            await _repository.UpdateNutrimentTypeAsync(nutrimentType);

            // Assert
            var updatedNutrimentType = await _dbContext.NutrimentTypes.FindAsync(nutrimentType.Id);
            Assert.NotNull(updatedNutrimentType);
            Assert.Equal("Zinc", updatedNutrimentType.Name);
        }

        [Fact]
        public async Task DeleteNutrimentType_ShouldDeleteNutrimentType()
        {
            // Arrange
            InitializeDbContext();
            var nutrimentType = new NutrimentType
            {
                Name = "Vitamin A"
            };
            _dbContext.NutrimentTypes.Add(nutrimentType);
            await _dbContext.SaveChangesAsync();

            // Act
            await _repository.DeleteNutrimentTypeAsync(nutrimentType.Id);

            // Assert
            var deletedNutrimentType = await _dbContext.NutrimentTypes.FindAsync(nutrimentType.Id);
            Assert.Null(deletedNutrimentType);
        }
    }
}
