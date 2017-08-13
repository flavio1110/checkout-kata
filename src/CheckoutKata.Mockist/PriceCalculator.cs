using System;

namespace CheckoutKata.Mockist
{
    public class PriceCalculator : IPriceCalculator
    {
        public float CalculateProductPrice(Product product, int quantity)
        {
            return product.Promotion == null
                ? product.Price * quantity
                : product.Promotion.CalculatePrice(product.Price, quantity);
        }
    }
}