using bakaChiefApplication.API.DatabaseModels;

namespace bakaChiefApplication.API.Extensions;

public static class ProductInfoMapperExtension
{
    public static ProductInfoLight ToProductInfoLight(this ProductInfo productInfo)
    {
        return new ProductInfoLight
        {
            Id = productInfo.code,
            ImageUrl = productInfo.image_url,
            Name = productInfo.product_name,
            NutriScoreLevel = productInfo.nutriscore_grade
        };
    }
    
    public static IEnumerable<ProductInfoLight> ToProductInfosLight(this IEnumerable<ProductInfo> productInfos) => productInfos.Select(p => p.ToProductInfoLight());
}