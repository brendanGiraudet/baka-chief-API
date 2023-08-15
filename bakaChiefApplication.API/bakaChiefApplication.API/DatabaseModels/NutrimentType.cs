﻿using System.ComponentModel.DataAnnotations;

namespace bakaChiefApplication.API.DatabaseModels
{
    public class NutrimentType
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; }

        public HashSet<IngredientNutrimentType> Ingredients { get; set; }
    }
}
