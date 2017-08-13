using System;
using Xunit;
using Moq;
using Shouldly;
using System.Collections.Generic;

namespace CheckoutKata.Mockist.Tests
{
    public class CheckoutCalculatorTests
    {
        Mock<IPriceCalculator> priceCalculatorMock;
        ICheckoutCalculator sut;

        public CheckoutCalculatorTests()
        {
            priceCalculatorMock = new Mock<IPriceCalculator>(MockBehavior.Strict);

            sut = new CheckoutCalculator(priceCalculatorMock.Object);
        }

        [Fact]
        public void CalculateCheckout_WithProducts_ShouldReturnTheItemsAndTheSumOfPricesAsTotal()
        {
            var products = new List<Product>
            {
                new Product { Id = 1,  Name = "t-shirt" },
                new Product { Id = 2,  Name = "hat" }
            };

            var selection = new List<SelectedProduct>
            {
                new SelectedProduct { Id = 1, Quantity = 1 },
                new SelectedProduct { Id = 2, Quantity = 1 }
            };
           
            priceCalculatorMock.Setup(r => r.CalculateProductPrice(It.IsAny<Product>(), It.IsAny<int>()))
                .Returns(10f)
                .Verifiable();
                        
            var actual = sut.CalculateCheckout(selection, products);

            actual.Items.ShouldNotBeEmpty();
            actual.Total.ShouldBe(20f);
            actual.Items.Length.ShouldBe(2);

            actual.Items[0].Price.ShouldBe(10f);
            actual.Items[0].Product.Id.ShouldBe(1);
            actual.Items[0].Product.Name.ShouldBe("t-shirt");

            actual.Items[1].Price.ShouldBe(10f);
            actual.Items[1].Product.Id.ShouldBe(2);
            actual.Items[1].Product.Name.ShouldBe("hat");

            priceCalculatorMock.Verify();
        }

        [Fact]
        public void CalculateCheckout_ProductsListDoesntContainTheEntireSelection_ShouldReturnOnlyTheExistingProductAsItems()
        {
            var products = new List<Product>
            {
                new Product { Id = 1,  Name = "t-shirt" }
            };

            var selection = new List<SelectedProduct>
            {
                new SelectedProduct { Id = 1, Quantity = 1 },
                new SelectedProduct { Id = 2, Quantity = 1 },
            };
           
            priceCalculatorMock.Setup(r => r.CalculateProductPrice(It.IsAny<Product>(), It.IsAny<int>()))
                .Returns(10f)
                .Verifiable();
                        
            var actual = sut.CalculateCheckout(selection, products);

            actual.Items.ShouldNotBeEmpty();
            actual.Total.ShouldBe(10f);
            actual.Items.Length.ShouldBe(1);

            actual.Items[0].Price.ShouldBe(10f);
            actual.Items[0].Product.Id.ShouldBe(1);
            actual.Items[0].Product.Name.ShouldBe("t-shirt");

            priceCalculatorMock.Verify();
        }

        [Fact]
        public void CalculateCheckout_ProductsListContainsNotSelectedProducts_ShouldReturnOnlySelectedProducts()
        {
            var products = new List<Product>
            {
                new Product { Id = 1,  Name = "t-shirt" },
                new Product { Id = 2,  Name = "hat" }
            };

            var selection = new List<SelectedProduct>
            {
                new SelectedProduct { Id = 1, Quantity = 2 },
            };
           
            priceCalculatorMock.Setup(r => r.CalculateProductPrice(It.IsAny<Product>(), It.IsAny<int>()))
                .Returns(10f)
                .Verifiable();
                        
            var actual = sut.CalculateCheckout(selection, products);

            actual.Items.ShouldNotBeEmpty();
            actual.Total.ShouldBe(10f);
            actual.Items.Length.ShouldBe(1);

            actual.Items[0].Price.ShouldBe(10f);
            actual.Items[0].Product.Id.ShouldBe(1);
            actual.Items[0].Product.Name.ShouldBe("t-shirt");

            priceCalculatorMock.Verify();
        }
    }
}
