using System;
using Xunit;
using Shouldly;

namespace CheckoutKata.Classic.Tests
{
    public class CalculatePriceTests
    {
        IPromotion sut;

        public CalculatePriceTests()
        {
            sut = new GetSecondFree();
        }

        [Fact]
        public void CalculatePrice_WithOneUnit_ShouldReturnTheUnitPrice()
        {
            var unitPrice = 5f;

            var actual = sut.CalculatePrice(unitPrice, 1);

            actual.ShouldBe(unitPrice);
        }

        [Fact]
        public void CalculatePrice_WithTwoUnits_ShouldReturnTheUnitPrice()
        {
            var unitPrice = 5f;

            var actual = sut.CalculatePrice(unitPrice, 2);

            actual.ShouldBe(unitPrice);
        }

        [Fact]
        public void CalculatePrice_WithThreeUnits_ShouldReturnThePriceOfTwoUnits()
        {
            var unitPrice = 5f;

            var actual = sut.CalculatePrice(unitPrice, 3);

            actual.ShouldBe(unitPrice * 2);
        }

        [Fact]
        public void CalculatePrice_WithFourUnits_ShouldReturnThePriceOfTwoUnits()
        {
            var unitPrice = 5f;

            var actual = sut.CalculatePrice(unitPrice, 3);

            actual.ShouldBe(unitPrice * 2);
        }
    }
}
