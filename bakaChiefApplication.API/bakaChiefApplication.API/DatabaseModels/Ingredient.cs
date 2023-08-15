using System.ComponentModel.DataAnnotations;

namespace bakaChiefApplication.API.DatabaseModels
{
    public class Ingredient
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        
        public string Name { get; set; }
        
        public string Image { get; set; }

        public ICollection<NutrimentType>? NutrimentTypes { get; set; }
    }
}
