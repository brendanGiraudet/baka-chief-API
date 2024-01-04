using System.ComponentModel.DataAnnotations;

namespace bakaChiefApplication.API.DatabaseModels;

public class Nutriment
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [Required]
    public string Name { get; set; } = string.Empty;

    public HashSet<IngredientNutriment>? IngredientNutriments { get; set; }
}