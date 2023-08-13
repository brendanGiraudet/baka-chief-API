using bakaChiefApplication.API.Options;
using bakaChiefApplication.Extensions;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddConfigurations(builder.Configuration);

var app = builder.Build();

bool enableFeaturesConfiguration;
if(!bool.TryParse(builder.Configuration["EnableFeatures:IsEnableSwagger"], out enableFeaturesConfiguration))
{
    enableFeaturesConfiguration = false;
}

// Configure the HTTP request pipeline.
if (enableFeaturesConfiguration)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
