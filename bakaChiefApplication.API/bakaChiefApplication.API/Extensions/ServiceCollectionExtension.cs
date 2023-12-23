using bakaChiefApplication.API.Options;
using bakaChiefApplication.API.Repositories;
using bakaChiefApplication.API.Repositories.ProductInfoRepository;
using bakaChiefApplication.API.Repositories.RecipsRepository;
using bakaChiefApplication.API.Services.ProductInfoService;
using bakaChiefApplication.API.Services.RecipsService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace bakaChiefApplication.API.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IRecipsRepository, RecipsRepository>();
        services.AddTransient<IProductInfoRepository, ProductInfoRepository>();
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<IRecipsService, RecipsService>();
        services.AddTransient<IProductInfoService, ProductInfoService>();

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
}