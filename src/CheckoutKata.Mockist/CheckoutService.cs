using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata.Mockist
{
    public class CheckoutService
    {
        private readonly IProductRepository productRepository;
        private readonly ICheckoutCalculator checkoutCalculator;
        public CheckoutService(IProductRepository productRepository, ICheckoutCalculator checkoutCalculator)
        {
            this.productRepository = productRepository;
            this.checkoutCalculator = checkoutCalculator;
        }

        public Checkout GetCheckoutInfo(IEnumerable<SelectedProduct> selection)
        {
            var products = productRepository.ListProductsByIds(selection.Select(s => s.Id));

            return checkoutCalculator.CalculateCheckout(selection, products);
        }        
    }
}
