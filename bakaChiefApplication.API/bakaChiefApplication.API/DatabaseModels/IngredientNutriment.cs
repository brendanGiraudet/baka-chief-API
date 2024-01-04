namespace bakaChiefApplication.API.DatabaseModels;

public class IngredientNutriment
{
    public Nutriment? Nutriment { get; set; } = new();
    public string NutrimentId { get; set; } = string.Empty;
    
    public Ingredient? Ingredient { get; set; } = new();
    public string IngredientId { get; set; } = string.Empty;

    public double Quantity { get; set; }
}