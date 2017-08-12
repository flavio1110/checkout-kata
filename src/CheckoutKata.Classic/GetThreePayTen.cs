using System;

namespace CheckoutKata.Classic
{
    public class GetThreePayTen : IPromotion
    {
        public string Name => "Get 3 pay 10";

        public float CalculatePrice(float unitPrice, int quantity)
        {
            const int promotionQuantity = 3;

            var promotion = quantity / promotionQuantity;
            var itemsOutOfPromotion = quantity % promotionQuantity;

            return promotion * 10 + itemsOutOfPromotion * unitPrice;
        }
    }
}
