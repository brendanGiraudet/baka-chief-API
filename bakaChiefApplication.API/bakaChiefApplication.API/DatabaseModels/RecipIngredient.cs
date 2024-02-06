using System.Text.Json.Serialization;

namespace bakaChiefApplication.API.DatabaseModels;

public class RecipIngredient
{
    [JsonPropertyName("ingredient")]
    public Ingredient? Ingredient { get; set; }

    [JsonPropertyName("ingredientId")]
    public string IngredientId { get; set; } = string.Empty;

    [JsonPropertyName("recip")]
    public Recip? Recip { get; set; }
    [JsonPropertyName("recipId")]
    public string RecipId { get; set; } = string.Empty;

    [JsonPropertyName("quantity")]
    public double Quantity { get; set; } = default;

    [JsonPropertyName("measureUnitId")]
    public string? MeasureUnitId { get; set; }
    
    [JsonPropertyName("measureUnit")]
    public MeasureUnit? MeasureUnit { get; set; }
}