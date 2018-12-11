using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata.Mockist
{
    public class CheckoutCalculator : ICheckoutCalculator
    {
        private readonly IPriceCalculator priceCalculator;

        public CheckoutCalculator(IPriceCalculator priceCalculator)
        {
            this.priceCalculator = priceCalculator;
        }

        public Checkout CalculateCheckout(IEnumerable<SelectedProduct> selection, IEnumerable<Product> products)
        {
            var items = GetItems(selection, products);
            
            return new Checkout
            {
                Items = items.ToArray(),
                Total = items.Sum(s => s.Price)
            };
        }

        private IEnumerable<CheckoutItem> GetItems(IEnumerable<SelectedProduct> selection, IEnumerable<Product> products)
        {
            foreach (var product in products.Where(p => selection.Select(sel => sel.Id).Contains(p.Id)))
            {
                var quantity = selection.FirstOrDefault(s => s.Id == product.Id).Quantity;
                yield return new CheckoutItem 
                {
                    Product = product,
                    Price = priceCalculator.CalculateProductPrice(product, quantity)
                };
            }
        }
    }
}