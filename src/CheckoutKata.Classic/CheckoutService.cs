using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata.Classic
{
    public class CheckoutService
    {
        private readonly IProductRepository productRepository;
        public CheckoutService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public Checkout GetCheckoutInfo(IEnumerable<SelectedProduct> selection)
        {
            var products = productRepository.ListProductsByIds(selection.Select(sp => sp.Id));

            return new Checkout(selection, products);
        }        
    }
}
