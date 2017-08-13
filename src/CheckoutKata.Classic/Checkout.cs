using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata.Classic
{
    public class Checkout
    {
        public Checkout(IEnumerable<SelectedProduct> selection, IEnumerable<Product> products)
        {
            var checkoutItems = GetItems(selection, products);
            
            Items = checkoutItems.ToArray();
            Total = checkoutItems.Sum(item => item.Price);
        }
        
        public CheckoutItem[] Items { get; }
        public float Total { get; }

        private IEnumerable<CheckoutItem> GetItems(IEnumerable<SelectedProduct> selection, IEnumerable<Product> products)
        {
            foreach (var product in products.Where(p => selection.Select(sel => sel.Id).Contains(p.Id)))
            {
                var quantity = selection.FirstOrDefault(s => s.Id == product.Id).Quantity;
                yield return new CheckoutItem 
                {
                    Product = product,
                    Price = product.Promotion != null 
                        ? product.Promotion.CalculatePrice(product.Price, quantity)
                        : product.Price * quantity
                };
            }
        }
    }
}
