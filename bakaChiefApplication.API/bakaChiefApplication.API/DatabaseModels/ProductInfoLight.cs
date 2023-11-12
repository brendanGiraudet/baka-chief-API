using System.ComponentModel.DataAnnotations;

namespace bakaChiefApplication.API.DatabaseModels;

public class ProductInfoLight
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
    public string? ImageUrl { get; set; }
    public string? NutriScoreLevel { get; set; }
}