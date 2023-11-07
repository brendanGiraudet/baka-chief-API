using System.ComponentModel.DataAnnotations;

namespace bakaChiefApplication.API.DatabaseModels
{
    public class Ingredient
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        
        public string Name { get; set; }
        
        public string? ImageUrl { get; set; }
        
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        
        public DateTime? UpdatedDate { get; set; }
        
        public DateTime? DeletedDate { get; set; }

        public ICollection<Nutriment> Nutriments { get; set; } = new HashSet<Nutriment>();
        
        public ICollection<RecipIngredient>? RecipIngredients { get; set; }
    }
}
