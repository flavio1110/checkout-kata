using System;
using Xunit;
using Moq;
using Shouldly;
using System.Collections.Generic;

namespace CheckoutKata.Mockist.Tests
{
    public class CheckoutServiceTests
    {
        Mock<IProductRepository> repositoryMock;
        Mock<ICheckoutCalculator> checkoutCalculatorMock;
        CheckoutService sut;

        public CheckoutServiceTests()
        {
            repositoryMock = new Mock<IProductRepository>(MockBehavior.Strict);
            checkoutCalculatorMock = new Mock<ICheckoutCalculator>(MockBehavior.Strict);

            sut = new CheckoutService(repositoryMock.Object, checkoutCalculatorMock.Object);
        }

        [Fact]
        public void CheckoutService_WithSelection_ShouldReturnCheckout()
        {
            var products = new List<Product>
            {
                new Product { Id = 1,  Name = "t-shirt" }
            };

            var selection = new List<SelectedProduct>
            {
                new SelectedProduct { Id = 1, Quantity = 3 }
            };

            var expected = new Checkout
            {
                Total = 10f,
                Items = new CheckoutItem[]{ new CheckoutItem()}
            };
            
            repositoryMock.Setup(r => r.ListProductsByIds(It.IsAny<IEnumerable<int>>()))
                .Returns(products)
                .Verifiable();
            
            checkoutCalculatorMock.Setup(c => c.CalculateCheckout(selection, products))
                .Returns(expected);

            var actual = sut.GetCheckoutInfo(selection);
        }
    }
}
