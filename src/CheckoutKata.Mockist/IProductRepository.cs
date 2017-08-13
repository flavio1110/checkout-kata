using System.Collections.Generic;

namespace CheckoutKata.Mockist
{
    public interface IProductRepository
    {
        IEnumerable<Product> ListProductsByIds(IEnumerable<int> ids);
    }
}