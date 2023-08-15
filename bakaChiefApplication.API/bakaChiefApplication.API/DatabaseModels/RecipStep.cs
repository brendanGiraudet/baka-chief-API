using System.ComponentModel.DataAnnotations;

namespace bakaChiefApplication.API.DatabaseModels
{
    public class RecipStep
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public int Number { get; set; }
        
        public string Description { get; set; }

        public Recip Recip { get; set; }
    }
}
