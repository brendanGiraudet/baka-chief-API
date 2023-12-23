using System.ComponentModel.DataAnnotations;

namespace bakaChiefApplication.API.DatabaseModels
{
    public class RecipProductInfo
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public ProductInfo ProductInfo { get; set; }
        
        public int Quantity { get; set; }
        
        public string MeasureUnit { get; set; }

        public Recip? Recip { get; set; }
    }
}
