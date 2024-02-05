using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace bakaChiefApplication.API.DatabaseModels;

public class MeasureUnit
{
    [Key]
    [JsonPropertyName("id")]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [Required]
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("recipIngredients")]
    public ICollection<RecipIngredient> RecipIngredients { get; set; } = new HashSet<RecipIngredient>();
}
