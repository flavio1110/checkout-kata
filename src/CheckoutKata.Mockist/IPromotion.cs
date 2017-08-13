namespace CheckoutKata.Mockist
{
    public interface IPromotion
    {
        string Name { get; }

        float CalculatePrice(float unitPrice, int quantity);
    }
}