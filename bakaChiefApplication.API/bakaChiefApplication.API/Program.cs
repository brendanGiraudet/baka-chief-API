using bakaChiefApplication.API.Extensions;
using Login.Extensions;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using bakaChiefApplication.API.DatabaseModels;

var builder = WebApplication.CreateBuilder(args);

var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<ProductInfo>("ProductInfos");

builder.Services.AddControllers().AddOData(
    options => options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(100).AddRouteComponents(
        "odata",
        modelBuilder.GetEdmModel()));

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
