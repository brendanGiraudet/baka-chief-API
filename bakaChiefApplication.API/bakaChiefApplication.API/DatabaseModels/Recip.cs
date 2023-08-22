using System.ComponentModel.DataAnnotations;

namespace bakaChiefApplication.API.DatabaseModels
{
    public class Recip
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; }
        
        public int  PersonsNumber { get; set; }
        
        public string? ImageFilePath { get; set; }
        
        public ICollection<RecipIngredient> RecipIngredients { get; set; }
        
        public ICollection<RecipStep> RecipSteps { get; set; }
    }
}
