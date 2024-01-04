using System.ComponentModel.DataAnnotations;

namespace bakaChiefApplication.API.DatabaseModels;

public class Ingredient
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string ImageUrl { get; set; } = string.Empty;

    public double KcalNumber { get; set; }

    public HashSet<IngredientNutriment>? IngredientNutriments { get; set; }

    public HashSet<RecipIngredient>? RecipIngredients { get; set; }
}