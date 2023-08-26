using bakaChiefApplication.Extensions;
using Login.Extensions;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddConfigurations(builder.Configuration);

builder.Services.AddCors(c =>
{
    c.AddDefaultPolicy(pol =>
    {
        pol.AllowAnyMethod();
        pol.AllowAnyHeader();
        pol.AllowAnyOrigin();
    });
});

var app = builder.Build();

// apply migrations
app.ApplyDatabaseMigrations();

app.UseCors();

bool enableFeaturesConfiguration;
if (!bool.TryParse(builder.Configuration["EnableFeatures:IsEnableSwagger"], out enableFeaturesConfiguration))
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
