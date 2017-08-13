namespace CheckoutKata.Mockist
{
    public interface IPriceCalculator
    {
        float CalculateProductPrice(Product product, int quantity);
    }
}