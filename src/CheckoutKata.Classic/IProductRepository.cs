using System.Collections.Generic;

namespace CheckoutKata.Classic
{
    public interface IProductRepository
    {
        IEnumerable<Product> ListProductsByIds(IEnumerable<int> ids);
    }
}