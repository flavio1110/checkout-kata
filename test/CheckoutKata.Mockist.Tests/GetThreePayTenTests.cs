using System;
using Xunit;
using Shouldly;

namespace CheckoutKata.Mockist.Tests
{
    public class GetThreePayTenTests
    {
        IPromotion sut;

        public GetThreePayTenTests()
        {
            sut = new GetThreePayTen();
        }

        [Fact]
        public void CalculatePrice_WithOneUnit_ShouldReturnTheUnitPrice()
        {
            var unitPrice = 5f;

            var actual = sut.CalculatePrice(unitPrice, 1);

            actual.ShouldBe(unitPrice);
        }

        [Fact]
        public void CalculatePrice_WithTwoUnits_ShouldReturnTheTwoTimesTheUnitPrice()
        {
            var unitPrice = 5f;

            var actual = sut.CalculatePrice(unitPrice, 2);

            actual.ShouldBe(2 * unitPrice);
        }

        [Fact]
        public void CalculatePrice_WithThreeUnits_ShouldReturn10()
        {
            var unitPrice = 5f;

            var actual = sut.CalculatePrice(unitPrice, 3);

            actual.ShouldBe(10f);
        }

        [Fact]
        public void CalculatePrice_WithFourUnits_ShouldReturnTenPlusTheUnitPrice()
        {
            var unitPrice = 5f;

            var actual = sut.CalculatePrice(unitPrice, 4);

            actual.ShouldBe(10f + unitPrice);
        }
    }
}
