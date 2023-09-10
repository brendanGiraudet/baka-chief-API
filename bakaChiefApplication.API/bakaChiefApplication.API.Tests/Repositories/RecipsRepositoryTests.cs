﻿using bakaChiefApplication.API.DatabaseModels;
using bakaChiefApplication.API.Repositories;
using bakaChiefApplication.API.Repositories.RecipsRepository;
using Microsoft.EntityFrameworkCore;

namespace bakaChiefApplication.API.Tests.Repositories
{
    public class RecipsRepositoryTests
    {
        private DbContextOptions<DatabaseContext> _options;

        public RecipsRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }

        private IRecipsRepository GetRepository()
        {
            InitializeDbContext(); // Reset the database
            return new RecipsRepository(new DatabaseContext(_options));
        }

        private void InitializeDbContext()
        {
            using var dbContext = new DatabaseContext(_options);
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
        }

        [Fact]
        public async Task GetAllRecipsAsync_ShouldReturnAllRecips()
        {
            var repository = GetRepository();

            // Arrange
            var recip1 = new Recip { Name = "Recip 1" };
            var recip2 = new Recip { Name = "Recip 2" };
            await repository.CreateRecipAsync(recip1);
            await repository.CreateRecipAsync(recip2);

            // Act
            var result = await repository.GetRecipsAsync();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Contains(result, r => r.Name == "Recip 1");
            Assert.Contains(result, r => r.Name == "Recip 2");
        }

        [Fact]
        public async Task GetRecipByIdAsync_ShouldReturnCorrectRecip()
        {
            var repository = GetRepository();

            // Arrange
            var recip = new Recip { Name = "Test Recip" };
            repository.CreateRecipAsync(recip);

            // Act
            var result = await repository.GetRecipByIdAsync(recip.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test Recip", result.Name);
        }

        [Fact]
        public async Task UpdateRecipAsync_ShouldUpdateRecip()
        {
            var repository = GetRepository();

            // Arrange
            var recip = new Recip { Name = "Old Name" };
            await repository.CreateRecipAsync(recip);

            // Act
            recip.Name = "New Name";
            await repository.UpdateRecipAsync(recip);
            var updatedRecip = await repository.GetRecipByIdAsync(recip.Id);

            // Assert
            Assert.Equal("New Name", updatedRecip.Name);
        }

        [Fact]
        public async Task DeleteRecipAsync_ShouldDeleteRecip()
        {
            var repository = GetRepository();

            // Arrange
            var recip = new Recip { Name = "Recip to Delete" };
            await repository.CreateRecipAsync(recip);

            // Act
            await repository.DeleteRecipAsync(recip.Id);
            var deletedRecip = await repository.GetRecipByIdAsync(recip.Id);

            // Assert
            Assert.Null(deletedRecip);
        }
    }
}
