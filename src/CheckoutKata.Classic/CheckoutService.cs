using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata.Classic
{
    public class CheckoutService
    {
        IProductRepository productRepository;
        public CheckoutService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public Checkout GetCheckoutInfo(IEnumerable<SelectedProduct> selection)
        {
            var products = productRepository.ListProductsByIds(selection.Select(sp => sp.Id));
            var checkoutItems = GetItems(selection, products);

            return new Checkout
            {
                Items = checkoutItems.ToArray(),
                Total = checkoutItems.Sum(item => item.Price)
            };
        }

        private IEnumerable<CheckoutItem> GetItems(IEnumerable<SelectedProduct> selection, IEnumerable<Product> products)
        {
            foreach (var product in products)
                yield return new CheckoutItem 
                {
                    Product = product,
                    Price = product.Price * selection.FirstOrDefault(s => s.Id == product.Id).Quantity
                };
        }

    }
}
