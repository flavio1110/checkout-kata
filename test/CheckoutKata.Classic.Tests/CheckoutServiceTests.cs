using System;
using Xunit;
using Shouldly;
using Moq;
using System.Collections.Generic;
using CheckoutKata.Classic;

namespace CheckoutKata.Classic.Tests
{
    public class CheckoutServiceTests
    {
        Mock<IProductRepository> repositoryMock;
        CheckoutService sut;

        public CheckoutServiceTests()
        {
            repositoryMock = new Mock<IProductRepository>();
            sut = new CheckoutService(repositoryMock.Object);
        }

        [Fact]
        public void GetCheckoutInfo_WithProductsWithoutPromotion_ShouldReturnThePriceTimesQuantity()
        {
            var products = new List<Product>
            {
                new Product { Id = 1,  Name = "t-shirt", Promotion = null, Price = 2f },
                new Product { Id = 2, Name = "hat", Promotion = null, Price = 6f },
            };
            
            repositoryMock.Setup(r => r.ListProductsByIds(It.IsAny<IEnumerable<int>>()))
                .Returns(products)
                .Verifiable();

            var selection = new List<SelectedProduct>
            {
                new SelectedProduct { Id = 1, Quantity = 3 },
                new SelectedProduct { Id = 2, Quantity = 2 },
            };

            var actual = sut.GetCheckoutInfo(selection);

            actual.Items[0].Product.Id.ShouldBe(1);
            actual.Items[0].Product.Name.ShouldBe("t-shirt");
            actual.Items[0].Product.Promotion.ShouldBeNull();
            actual.Items[0].Product.Price.ShouldBe(2f);
            actual.Items[0].Price.ShouldBe(6f);

            actual.Items[1].Product.Id.ShouldBe(2);
            actual.Items[1].Product.Name.ShouldBe("hat");
            actual.Items[1].Product.Promotion.ShouldBeNull();
            actual.Items[1].Product.Price.ShouldBe(6f);
            actual.Items[1].Price.ShouldBe(12f);

            repositoryMock.Verify();
        }

        [Fact]
        public void GetCheckoutInfo_WithProductsWithPromotion_ShouldReturnPriceWithPromotionApplied()
        {
            var products = new List<Product>
            {
                new Product { Id = 1,  Name = "t-shirt", Promotion = new SecondFree(), Price = 2f },
                new Product { Id = 2, Name = "hat", Promotion = new GetThreePayTen(), Price = 5f },
            };
            
            repositoryMock.Setup(r => r.ListProductsByIds(It.IsAny<IEnumerable<int>>()))
                .Returns(products)
                .Verifiable();

            var selection = new List<SelectedProduct>
            {
                new SelectedProduct { Id = 1, Quantity = 2 },
                new SelectedProduct { Id = 2, Quantity = 3 },
            };

            var actual = sut.GetCheckoutInfo(selection);

            actual.Items[0].Product.Id.ShouldBe(1);
            actual.Items[0].Product.Name.ShouldBe("t-shirt");
            actual.Items[0].Product.Promotion.ShouldBeOfType<SecondFree>();
            actual.Items[0].Product.Price.ShouldBe(2f);
            actual.Items[0].Price.ShouldBe(2f);

            actual.Items[1].Product.Id.ShouldBe(2);
            actual.Items[1].Product.Name.ShouldBe("hat");
            actual.Items[1].Product.Promotion.ShouldBeOfType<GetThreePayTen>();
            actual.Items[1].Product.Price.ShouldBe(5f);
            actual.Items[1].Price.ShouldBe(10f);

            repositoryMock.Verify();
        }
    }
}
