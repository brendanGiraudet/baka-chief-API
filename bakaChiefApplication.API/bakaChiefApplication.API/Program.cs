using bakaChiefApplication.API.Extensions;
using Login.Extensions;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using bakaChiefApplication.API.DatabaseModels;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<Nutriment>("Nutriments");
modelBuilder.EntitySet<Ingredient>("Ingredients");
modelBuilder.EntitySet<Recip>("Recips");

builder.Services.AddControllers()
    .AddOData(
        options => options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(100).AddRouteComponents(
            "odata",
            modelBuilder.GetEdmModel())
    )
    .AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});



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

bool enableSwagger;
if (!bool.TryParse(builder.Configuration["EnableFeatures:IsEnableSwagger"], out enableSwagger))
{
    enableSwagger = false;
}

if (enableSwagger)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
