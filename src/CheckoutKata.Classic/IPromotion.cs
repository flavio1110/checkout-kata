using System;

namespace CheckoutKata.Classic
{
    public interface IPromotion
    {
        string Name { get; }
        float CalculatePrice(float unityPrice, int quantity);
    }
}
