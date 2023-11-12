namespace bakaChiefApplication.API.DatabaseModels;

public class ProductInfoLight
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string? ImageUrl { get; set; }
    public string? NutriScoreLevel { get; set; }
}