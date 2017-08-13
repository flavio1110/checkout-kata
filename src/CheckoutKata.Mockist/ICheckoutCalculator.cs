using System.Collections.Generic;

namespace CheckoutKata.Mockist
{
    public interface ICheckoutCalculator
    {
        Checkout CalculateCheckout(IEnumerable<SelectedProduct> selection, IEnumerable<Product> products);
    }
}