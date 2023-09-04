using System.ComponentModel.DataAnnotations;

namespace bakaChiefApplication.API.DatabaseModels
{
    public class Nutriment
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; }

        public string? ImageUrl { get; set; }

        public ICollection<Ingredient>? Ingredients { get; set; }
    }
}