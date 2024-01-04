namespace bakaChiefApplication.API.DatabaseModels;

public class RecipIngredient
{
    public Ingredient? Ingredient { get; set; }
    public string IngredientId { get; set; } = string.Empty;

    public Recip? Recip { get; set; }
    public string RecipId { get; set; } = string.Empty;

    public double Quantity { get; set; }

    public string MeasureUnit { get; set; } = string.Empty;
}