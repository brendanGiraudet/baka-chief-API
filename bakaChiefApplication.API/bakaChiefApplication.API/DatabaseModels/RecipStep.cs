using System.ComponentModel.DataAnnotations;

namespace bakaChiefApplication.API.DatabaseModels
{
    public class RecipStep
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public int Number { get; set; }
        
        [Required]
        public string Description { get; set; } = string.Empty;

        public Recip Recip { get; set; } = new();
    }
}
