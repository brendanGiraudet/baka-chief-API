using System.Text.Json.Serialization;

namespace bakaChiefApplication.API.DatabaseModels;

public class IngredientNutriment
{
    [JsonPropertyName("nutriment")]
    public Nutriment? Nutriment { get; set; } = new();

    [JsonPropertyName("nutrimentId")]
    public string NutrimentId { get; set; } = string.Empty;

    [JsonPropertyName("ingredient")]
    public Ingredient? Ingredient { get; set; } = new();

    [JsonPropertyName("ingredientId")]
    public string IngredientId { get; set; } = string.Empty;

    [JsonPropertyName("quantity")]
    public double? Quantity { get; set; }
}