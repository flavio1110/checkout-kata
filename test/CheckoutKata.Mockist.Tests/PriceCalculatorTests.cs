using System;
using Xunit;
using Moq;
using Shouldly;
using System.Collections.Generic;

namespace CheckoutKata.Mockist.Tests
{
    public class PriceCalculatorTests
    {
        const float priceFromPromotion = 100f;
        Mock<IPromotion> promotionMock;
        IPriceCalculator sut;

        public PriceCalculatorTests()
        {
            promotionMock = new Mock<IPromotion>(MockBehavior.Strict);
            promotionMock.Setup(p => p.CalculatePrice(It.IsAny<float>(), It.IsAny<int>()))
                .Returns(priceFromPromotion);

            sut = new PriceCalculator();
        }

        [Fact]
        public void CalculateProductPrice_ProductWithoutPromotion_ShouldBeQuantityTimeUnitPrice()
        {
            var product = new Product 
            {
                Id = 1,
                Name = "t-shirt",
                Price = 10,
                Promotion = null
            };

            var actual = sut.CalculateProductPrice(product, 2);

            actual.ShouldBe(20);
        }

        [Fact]
        public void CalculateProductPrice_ProductWithPromotion_ShouldBePromotionPrice()
        {
            var product = new Product 
            {
                Id = 1,
                Name = "t-shirt",
                Price = 10,
                Promotion = promotionMock.Object
            };

            var actual = sut.CalculateProductPrice(product, 2);

            actual.ShouldBe(priceFromPromotion);
        }
    }
}
