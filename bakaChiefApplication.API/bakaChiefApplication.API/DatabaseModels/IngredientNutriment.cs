namespace bakaChiefApplication.API.DatabaseModels;

public class IngredientNutriment
{
    public string NutrimentId { get; set; } = string.Empty;
    
    public string IngredientId { get; set; } = string.Empty;

    public double Quantity { get; set; }
}