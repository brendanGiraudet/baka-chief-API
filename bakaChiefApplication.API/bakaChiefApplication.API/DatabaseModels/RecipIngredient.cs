namespace bakaChiefApplication.API.DatabaseModels;

public class RecipIngredient
{
    public string IngredientId { get; set; } = string.Empty;

    public string RecipId { get; set; } = string.Empty;

    public double Quantity { get; set; }

    public string MeasureUnit { get; set; } = string.Empty;
}