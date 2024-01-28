using System.Text.Json.Serialization;
using bakaChiefApplication.API.DatabaseModels;
using bakaChiefApplication.API.Options;
using bakaChiefApplication.API.Repositories;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.OData.ModelBuilder;

namespace bakaChiefApplication.API.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddRepositories(this IServiceCollection services)
    {
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IMemoryCache, MemoryCache>();
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

    public static void AddOData(this IServiceCollection services)
    {
        var modelBuilder = new ODataConventionModelBuilder();
        modelBuilder.EntitySet<Nutriment>("Nutriments");
        modelBuilder.EntitySet<Ingredient>("Ingredients");
        modelBuilder.EntitySet<Recip>("Recips");
        modelBuilder.EntitySet<SelectedRecipHistory>("SelectedRecipHistories");
        modelBuilder.EntitySet<RecipType>("RecipTypes");

        services.AddControllers()
            .AddOData(
                options => options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(100).AddRouteComponents(
                    "odata",
                    modelBuilder.GetEdmModel())
            )
            .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });
    }
}