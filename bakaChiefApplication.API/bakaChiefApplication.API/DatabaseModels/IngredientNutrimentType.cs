using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bakaChiefApplication.API.DatabaseModels
{
    public class IngredientNutrimentType
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [ForeignKey("Ingredient")]
        public string IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }

        [ForeignKey("NutrimentType")]
        public string NutrimentTypeId { get; set; }
        public NutrimentType NutrimentType { get; set; }
    }
}
