using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace bakaChiefApplication.API.DatabaseModels;

public class Ingredient
{
    [JsonPropertyName("id")]
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [Required]
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [JsonPropertyName("imageUrl")]
    public string ImageUrl { get; set; } = string.Empty;

    [JsonPropertyName("kcalNumber")]
    public double KcalNumber { get; set; }

    [JsonPropertyName("ingredientNutriments")]
    public ICollection<IngredientNutriment> IngredientNutriments { get; set; } = new HashSet<IngredientNutriment>();

    [JsonPropertyName("recipIngredients")]
    public ICollection<RecipIngredient> RecipIngredients { get; set; } = new HashSet<RecipIngredient>();
}