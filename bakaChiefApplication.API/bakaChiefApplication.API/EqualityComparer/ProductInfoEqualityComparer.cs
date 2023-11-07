using System.Diagnostics.CodeAnalysis;
using bakaChiefApplication.API.DatabaseModels;

namespace bakaChiefApplication.API.EqualityComparer;

public class ProductInfoEqualityComparer : IEqualityComparer<ProductInfo>
{
    public bool Equals(ProductInfo? x, ProductInfo? y)
    {
        return x?.code == y?.code;
    }

    public int GetHashCode([DisallowNull] ProductInfo obj)
    {
        return base.GetHashCode();
    }
}