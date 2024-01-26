﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace bakaChiefApplication.API.DatabaseModels;

public class Recip
{
    [Key]
    [JsonPropertyName("id")]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [Required]
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("personsNumber")]
    public int PersonsNumber { get; set; }

    [JsonPropertyName("imageUrl")]
    public string? ImageUrl { get; set; }

    [JsonPropertyName("recipIngredients")]
    public ICollection<RecipIngredient> RecipIngredients { get; set; } = new HashSet<RecipIngredient>();

    [JsonPropertyName("recipSteps")]
    public ICollection<RecipStep> RecipSteps { get; set; }= new HashSet<RecipStep>();
    
    [JsonPropertyName("selectedRecipHistories")]
    public ICollection<SelectedRecipHistory> SelectedRecipHistories { get; set; }= new HashSet<SelectedRecipHistory>();
}
