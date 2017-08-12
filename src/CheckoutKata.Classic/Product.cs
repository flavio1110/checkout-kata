using System;

namespace CheckoutKata.Classic
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public IPromotion Promotion { get; set; }
    }
}
