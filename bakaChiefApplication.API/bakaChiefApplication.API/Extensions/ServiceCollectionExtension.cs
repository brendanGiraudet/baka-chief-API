﻿using bakaChiefApplication.API.Options;
using bakaChiefApplication.API.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

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
}