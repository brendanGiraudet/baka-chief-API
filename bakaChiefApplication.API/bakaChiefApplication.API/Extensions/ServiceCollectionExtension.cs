using bakaChiefApplication.API.Options;
using bakaChiefApplication.API.Repositories;
using bakaChiefApplication.API.Repositories.IngredientsRepository;
using bakaChiefApplication.API.Repositories.NutrimentsRepository;
using bakaChiefApplication.API.Repositories.ProductInfoRepository;
using bakaChiefApplication.API.Repositories.RecipsRepository;
using bakaChiefApplication.API.Services.IngredientsService;
using bakaChiefApplication.API.Services.NutrimentsService;
using bakaChiefApplication.API.Services.ProductInfoService;
using bakaChiefApplication.API.Services.RecipsService;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;

namespace bakaChiefApplication.API.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<INutrimentsRepository, NutrimentsRepository>();
        services.AddTransient<IIngredientsRepository, IngredientsRepository>();
        services.AddTransient<IRecipsRepository, RecipsRepository>();
        services.AddTransient<IProductInfoRepository, ProductInfoRepository>();
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<INutrimentsService, NutrimentsService>();
        services.AddTransient<IIngredientsService, IngredientsService>();
        services.AddTransient<IRecipsService, RecipsService>();
        services.AddTransient<IProductInfoService, ProductInfoService>();
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