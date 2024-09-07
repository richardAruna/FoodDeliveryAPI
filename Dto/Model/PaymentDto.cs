namespace FoodDeliveryAPI.Dto.Model
{
    public record struct PaymentDto
    (
        int id,
        string CardName, string CardNumber, string ExpiryDate, string CVC);
}
