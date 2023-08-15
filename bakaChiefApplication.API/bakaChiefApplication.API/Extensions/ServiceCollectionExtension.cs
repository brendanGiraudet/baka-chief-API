﻿using bakaChiefApplication.API.Options;
using bakaChiefApplication.API.Repositories;
using bakaChiefApplication.API.Repositories.IngredientRepository;
using bakaChiefApplication.API.Repositories.NutrimentTypeRepository;
using bakaChiefApplication.API.Services.IngredientService;
using bakaChiefApplication.API.Services.NutrimentTypeService;
using Microsoft.EntityFrameworkCore;

namespace bakaChiefApplication.Extensions
{
    public static class ServiceCollectionExtension
    {

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<INutrimentTypeRepository, NutrimentTypeRepository>();
            services.AddTransient<IIngredientRepository, IngredientRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<INutrimentTypeService, NutrimentTypeService>();
            services.AddTransient<IIngredientService, IngredientService>();
        }

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database");
            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlite(connectionString));
        }
        
        public static void AddConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EnableFeaturesConfiguration>(configuration.GetSection("EnableFeatures"));
        }
    }
}
