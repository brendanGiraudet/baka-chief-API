﻿using System.ComponentModel.DataAnnotations;

namespace bakaChiefApplication.API.DatabaseModels
{
    public class Recip
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string Name { get; set; } = string.Empty;

        public int PersonsNumber { get; set; }

        public string? ImageUrl { get; set; }

        public HashSet<RecipIngredient>? RecipIngredients { get; set; }

        public HashSet<RecipStep> RecipSteps { get; set; } = new();
    }
}
