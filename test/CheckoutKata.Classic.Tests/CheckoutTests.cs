using System;
using Xunit;
using Shouldly;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata.Classic.Tests
{
    public class CheckoutTests
    {
        Checkout sut;

        [Fact]
        public void Ctor_EmptyListOfProducts_EmptyListOfItem()
        {
            var selection = new List<SelectedProduct>
            {
                new SelectedProduct { Id = 1, Quantity = 2 }
            };

            var products = new List<Product>();

            sut = new Checkout(selection, products);

            sut.Total.ShouldBe(0);
            sut.Items.ShouldBeEmpty();
        }

        [Fact]
        public void Ctor_EmptyListOfSelection_EmptyListOfItem()
        {
            var selection = new List<SelectedProduct>();

            var products = new List<Product>()
            {
                new Product()
            };

            sut = new Checkout(selection, products);

            sut.Total.ShouldBe(0);
            sut.Items.ShouldBeEmpty();
        }

        [Fact]
        public void Ctor_AllSelectedProductsInProductList_AllProductsAsItems()
        {
            var selection = new List<SelectedProduct>
            {
                new SelectedProduct { Id = 1 },
                new SelectedProduct { Id = 2 },
            };

            var products = new List<Product>()
            {
                new Product { Id = 1 },
                new Product { Id = 2 }
            };

            sut = new Checkout(selection, products);

            sut.Items.ShouldNotBeEmpty();
            
            sut.Items.All(item => selection.Select(s => s.Id).Contains(item.Product.Id));
        }

        [Fact]
        public void Ctor_NotAllSelectedProductsInProductList_OnlyExistingProductsAsItems()
        {
            var selection = new List<SelectedProduct>
            {
                new SelectedProduct { Id = 1 },
                new SelectedProduct { Id = 2 },
                new SelectedProduct { Id = 3 },
            };

            var products = new List<Product>()
            {
                new Product { Id = 1 },
                new Product { Id = 3 }
            };

            sut = new Checkout(selection, products);

            sut.Items.ShouldNotBeEmpty();
            
            sut.Items.All(item => products.Select(p => p.Id).Contains(item.Product.Id));
        }

        [Fact]
        public void Ctor_WhenProductHasPriceAndNoPromotion_TheItemPriceShouldBeQuantityTimesPrice()
        {
            var selection = new List<SelectedProduct>
            {
                new SelectedProduct { Id = 1, Quantity = 2 },
                new SelectedProduct { Id = 2,  Quantity = 3 },
            };

            var products = new List<Product>()
            {
                new Product { Id = 1, Price = 2 },
                new Product { Id = 2, Price = 3 }
            };

            sut = new Checkout(selection, products);

            sut.Items.ShouldNotBeEmpty();
            sut.Items[0].Price.ShouldBe(4f);
            sut.Items[1].Price.ShouldBe(9f);
            
        }

        [Fact]
        public void Ctor_WhenProductHasPriceAndPromotion_TheItemPriceShouldBeThePromotionPrice()
        {
            var selection = new List<SelectedProduct>
            {
                new SelectedProduct { Id = 1, Quantity = 2 },
                new SelectedProduct { Id = 2,  Quantity = 3 },
            };

            var products = new List<Product>()
            {
                new Product { Id = 1, Price = 2, Promotion = new GetSecondFree() },
                new Product { Id = 2, Price = 4, Promotion = new GetThreePayTen() }
            };

            sut = new Checkout(selection, products);

            sut.Items.ShouldNotBeEmpty();
            sut.Items[0].Price.ShouldBe(2f);
            sut.Items[1].Price.ShouldBe(10f);
            
        }

        // [Fact]
        // public void Ctor_WhenItemsHasPrice_TotalShouldBeTheSumOfAllItems()
        // {
        //     var selection = new List<SelectedProduct>
        //     {
        //         new SelectedProduct { Id = 1, Quantity = 2 },
        //         new SelectedProduct { Id = 2,  Quantity = 3 },
        //     };

        //     var products = new List<Product>()
        //     {
        //         new Product { Id = 1, Price = 2 },
        //         new Product { Id = 2, Price = 3 }
        //     };

        //     sut = new Checkout(selection, products);

        //     sut.Items.ShouldNotBeEmpty();
            
        //     sut.Items.All(item => products.Select(p => p.Id).Contains(item.Product.Id));
        // }
    }
}
