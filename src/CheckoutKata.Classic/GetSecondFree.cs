using System;

namespace CheckoutKata.Classic
{
    public class GetSecondFree : IPromotion
    {
        public string Name => "Get 2 pay 1";

        public float CalculatePrice(float unitPrice, int quantity)
        {
            const int promotionQuantity = 2;

            var pairs = quantity / promotionQuantity;
            var itemsOutOfPromotion = quantity % promotionQuantity;

            return pairs * unitPrice + itemsOutOfPromotion * unitPrice;
        }
    }
}
