using bakaChiefApplication.API.Extensions;
using Login.Extensions;
using Microsoft.AspNetCore.OData;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOData();

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
